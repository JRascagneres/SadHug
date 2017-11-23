using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMode {

    private List<Player> players;
    private List<Enemy> enemies;
    private Text playerHealth;
    private Text enemyHealth;
    private Text playerAP;
    private int turnState;
    private GameObject combatCanvas = GameObject.FindGameObjectWithTag("CombatCanvas");
    
    public CombatMode(List<Player> players, List<Enemy> enemies)
    {
        //@Michael put camera change to combat mode in this method
        this.players = players;
        this.enemies = enemies;
        playerHealth = GameObject.FindGameObjectWithTag("Player Health").GetComponent<Text>() as Text;
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy Health").GetComponent<Text>() as Text;
        playerAP = GameObject.FindGameObjectWithTag("Player AP").GetComponent<Text>() as Text;
        updateStatsInfo();

        //Test to dynamically add text
        //GameObject newGO = new GameObject("mytext");
        //newGO.SetActive(true);
        //newGO.transform.SetParent(combatCanvas.transform);
        //Text myText = newGO.AddComponent<Text>();
        //myText.transform.localScale = new Vector2(1, 1);
        //myText.text = "XxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxS";
        //myText.fontSize = 10;
        //myText.useGUILayout = true;
        //myText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

        startCombat();
    }


    void startCombat()
    {
        turnState = 0;
    }

    void turnCheck()
    {
        switch (turnState)
        {
            case (1):
                enemyAttack();
                break;

        }
    }

    void enemyAttack()
    {
        if (enemies[0].getHealth() != 0)
        {
            doDamage(players[0], 5);
            turnState = 0;
        }
    }


    void updateStatsInfo()
    {
        Image playerHealthBar = GameObject.FindGameObjectWithTag("Player Health Bar").GetComponent<Image>() as Image;
        playerHealthBar.fillAmount = (float)players[0].getHealth() / (float)players[0].getMaxHealth();
        playerHealth.text = players[0].getHealth().ToString() + "/" + players[0].getMaxHealth().ToString();

        Image enemyHealthBar = GameObject.FindGameObjectWithTag("Enemy Health Bar").GetComponent<Image>() as Image;
        enemyHealthBar.fillAmount = (float)enemies[0].getHealth() / (float)enemies[0].getMaxHealth();
        enemyHealth.text = enemies[0].getHealth().ToString() + "/" + enemies[0].getMaxHealth().ToString();

        Image playerAPBar = GameObject.FindGameObjectWithTag("Player AP Bar").GetComponent<Image>() as Image;
        playerAPBar.fillAmount = (float)players[0].getCurrentAP() / (float)players[0].getMaxAP();
        playerAP.text = players[0].getCurrentAP().ToString() + "/" + players[0].getMaxAP().ToString();
    }


    public void doDamage(Character character, int damageAmount)
    {
        int newHealth = character.takeDamage(damageAmount);
        if(newHealth <= 0)
        {
            character.setHealth(0);
        }
    }

    public void updateAP(Player player, int AP)
    {
        int currentAP = player.useAP(AP);
    }

    public void useAbility(Player player, Enemy enemy, int abilityIndex)
    {
        Ability ability = player.getAbilities()[abilityIndex];
        doDamage(enemy, ability.damage);
        updateAP(player, ability.apCost);
        updateStatsInfo();
    }

    public void attackButton(int attackButtonNumber)
    {
        if (turnState == 0)
        {
            switch (attackButtonNumber)
            {
                case (1):
                    useAbility(players[0], enemies[0], 0);
                    break;
                case (2):
                    useAbility(players[0], enemies[0], 1);
                    break;
                case (3):
                    useAbility(players[0], enemies[0], 2);
                    break;
                case (4):
                    useAbility(players[0], enemies[0], 3);
                    break;
                default:
                    Debug.Log("BUG");
                    break;
            }
            turnState = 1;
            turnCheck();
        }
    }

    public List<Ability> getPlayerAbilities()
    {
        return players[0].getAbilities();
    }

    
}
