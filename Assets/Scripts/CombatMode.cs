using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMode {

    private List<Player> players;
    private List<Enemy> enemies;
    private Text playerHealth;
    private Text enemyHealth;
    private int turnState;
    private GameObject combatCanvas = GameObject.FindGameObjectWithTag("CombatCanvas");

    public CombatMode(List<Player> players, List<Enemy> enemies, Text playerHealth, Text enemyHealth)
    {
        this.players = players;
        this.enemies = enemies;
        this.playerHealth = playerHealth;
        this.enemyHealth = enemyHealth;
        combatCanvas.SetActive(true);
        updateHealthInfo();

        GameObject newGO = new GameObject("mytext");
        newGO.SetActive(true);
        newGO.transform.SetParent(combatCanvas.transform);
        Text myText = newGO.AddComponent<Text>();
        myText.transform.localScale = new Vector2(1, 1);
        myText.text = "XxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxS";
        myText.fontSize = 10;
        myText.useGUILayout = true;
        myText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

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


    void updateHealthInfo()
    {
        Image playerHealthBar = GameObject.FindGameObjectWithTag("Player Health Bar").GetComponent<Image>() as Image;
        playerHealthBar.fillAmount = (float)players[0].getHealth() / (float)players[0].getMaxHealth();
        playerHealth.text = players[0].getHealth().ToString() + "/" + players[0].getMaxHealth().ToString();

        Image enemyHealthBar = GameObject.FindGameObjectWithTag("Enemy Health Bar").GetComponent<Image>() as Image;
        enemyHealthBar.fillAmount = (float)enemies[0].getHealth() / (float)enemies[0].getMaxHealth();
        enemyHealth.text = enemies[0].getHealth().ToString() + "/" + enemies[0].getMaxHealth().ToString();
    }


    public void doDamage(Character character, int damageAmount)
    {
        int newHealth = character.takeDamage(damageAmount);
        if(newHealth <= 0)
        {
            character.setHealth(0);
        }
        updateHealthInfo();
    }

    public void attackButton(int attackButtonNumber)
    {
        if (turnState == 0)
        {
            switch (attackButtonNumber)
            {
                case (1):
                    doDamage(enemies[0], players[0].getAbilities()[0].damage);
                    break;
                case (2):
                    doDamage(enemies[0], players[0].getAbilities()[1].damage);
                    break;
                case (3):
                    doDamage(enemies[0], players[0].getAbilities()[2].damage);
                    break;
                case (4):
                    doDamage(enemies[0], players[0].getAbilities()[3].damage);
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
