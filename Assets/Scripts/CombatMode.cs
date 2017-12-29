using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMode {

    private List<Player> players;
    private List<Enemy> enemies;
    private int playerIndex;
    private Text playerHealth;
    private Text enemyHealth;
    private Text playerAP;
    private int turnState;
    private GameObject combatCanvas = GameObject.FindGameObjectWithTag("CombatCanvas");
    private bool enemyStunned = false;
    private bool playerStunned = false;
    private GameObject playerSwitchCanvas;
    
    public CombatMode(List<Player> players, List<Enemy> enemies)
    {
        playerSwitchCanvas = GameObject.FindGameObjectWithTag("CombatPlayerSwapCanvas");
        playerSwitchCanvas.SetActive(false);
        playerIndex = 0;
        this.players = players;
        this.enemies = enemies;
        playerHealth = GameObject.FindGameObjectWithTag("Player Health").GetComponent<Text>() as Text;
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy Health").GetComponent<Text>() as Text;
        playerAP = GameObject.FindGameObjectWithTag("Player AP").GetComponent<Text>() as Text;
        updateStatsInfo();
        updateSprite();

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
            doDamage(players[playerIndex], 5);
            updateStatsInfo();
            enemies[0].takeTickingDamage();
            updateStatsInfo();
            if (playerStunned)
            {
                playerStunned = false;
                turnState = 1;
                turnCheck();
            }
            else
            {
                turnState = 0;
            }
        }
    }


    void updateStatsInfo()
    {
        Image playerHealthBar = GameObject.FindGameObjectWithTag("Player Health Bar").GetComponent<Image>() as Image;
        playerHealthBar.fillAmount = (float)players[playerIndex].getHealth() / (float)players[playerIndex].getMaxHealth();
        playerHealth.text = players[playerIndex].getHealth().ToString() + "/" + players[playerIndex].getMaxHealth().ToString();

        Image enemyHealthBar = GameObject.FindGameObjectWithTag("Enemy Health Bar").GetComponent<Image>() as Image;
        enemyHealthBar.fillAmount = (float)enemies[0].getHealth() / (float)enemies[0].getMaxHealth();
        enemyHealth.text = enemies[0].getHealth().ToString() + "/" + enemies[0].getMaxHealth().ToString();

        Image playerAPBar = GameObject.FindGameObjectWithTag("Player AP Bar").GetComponent<Image>() as Image;
        playerAPBar.fillAmount = (float)players[playerIndex].getCurrentAP() / (float)players[playerIndex].getMaxAP();
        playerAP.text = players[playerIndex].getCurrentAP().ToString() + "/" + players[playerIndex].getMaxAP().ToString();
    }

    void updateSprite()
    {
        Sprite enemySprite = enemies[0].getSprite();
        GameObject enemyPlaceHolderObj = GameObject.FindGameObjectWithTag("Enemy Placeholder");
        SpriteRenderer enemyPlaceHolder = enemyPlaceHolderObj.GetComponent<SpriteRenderer>();
        float pixelsPerUnit = enemyPlaceHolder.sprite.pixelsPerUnit;
        enemyPlaceHolder.sprite = enemySprite;
        float newPixelsPerUnit = enemyPlaceHolder.sprite.pixelsPerUnit;

        float pixelRatio = pixelsPerUnit / newPixelsPerUnit;
        enemyPlaceHolder.transform.localScale = new Vector2(enemyPlaceHolder.transform.localScale.x * pixelRatio, enemyPlaceHolder.transform.localScale.y * pixelRatio);

        Sprite playerSprite = players[playerIndex].getSprite();
        GameObject playerPlaceHolderObj = GameObject.FindGameObjectWithTag("Player Placeholder");
        SpriteRenderer playerPlaceHolder = playerPlaceHolderObj.GetComponent<SpriteRenderer>();
        pixelsPerUnit = playerPlaceHolder.sprite.pixelsPerUnit;
        playerPlaceHolder.sprite = playerSprite;

        pixelRatio = pixelsPerUnit / newPixelsPerUnit;
        playerPlaceHolder.transform.localScale = new Vector2(playerPlaceHolder.transform.localScale.x * pixelRatio, playerPlaceHolder.transform.localScale.y * pixelRatio);
    }


    public void doDamage(Character character, int damageAmount)
    {
        int newHealth = character.takeDamage(damageAmount);
        if(newHealth <= 0)
        {
            character.setHealth(0);
        }
    }

    public void doHeal(Character character, int healAmount)
    {
        character.doHeal(healAmount);
    }

    public bool updateAP(Player player, int AP)
    {
        int beforeAP = player.getCurrentAP();
        int currentAP = player.useAP(AP);
        if (currentAP < 0)
        {
            player.setCurrentAP(beforeAP);
            return false;
        }
        return true;
    }

    public bool useAbility(Player player, Enemy enemy, int abilityIndex)
    {
        Ability ability = player.getAbilities()[abilityIndex];
        bool success = updateAP(player, ability.apCost);
        if (success)
        {
            Ability.abilityTypes abilityType = ability.abilityType;
            switch (abilityType)
            {
                case (Ability.abilityTypes.numberDamage):
                    doDamage(enemy, ability.effectMagnitude);
                    break;
                case (Ability.abilityTypes.numberHeal):
                    doHeal(player, ability.effectMagnitude);
                    break;
                case (Ability.abilityTypes.percentCurrentDamage):
                    doDamage(enemy, enemy.getHealth() * ability.effectMagnitude / 100);
                    break;
                case (Ability.abilityTypes.percentTotalDamage):
                    doDamage(enemy, enemy.getMaxHealth() * ability.effectMagnitude / 100);
                    break;
                case (Ability.abilityTypes.groupNumberHeal):
                    for(int i = 0; i < players.Count; i++)
                    {
                        players[i].doHeal(ability.effectMagnitude);
                    }
                    break;
                case (Ability.abilityTypes.enemyStun):
                    enemyStunned = true;
                    break;
                case (Ability.abilityTypes.playerStun):
                    playerStunned = true;
                    break;
                case (Ability.abilityTypes.enemyTickingDamage):
                    enemies[0].setTickingDamage(true);
                    enemies[0].setTickingDamagePerTurn(ability.effectMagnitude);
                    break;
                case (Ability.abilityTypes.playerTickingDamage):
                    players[playerIndex].setTickingDamage(true);
                    players[playerIndex].setTickingDamagePerTurn(ability.effectMagnitude);
                    break;
            }
        }
        updateStatsInfo();
        return success;
        
    }

    public void attackButton(int attackButtonNumber)
    {
        if (turnState == 0)
        {
            bool success = false;
            switch (attackButtonNumber)
            {
                case (1):
                    success = useAbility(players[playerIndex], enemies[0], 0);
                    break;
                case (2):
                    success = useAbility(players[playerIndex], enemies[0], 1);
                    break;
                case (3):
                    success = useAbility(players[playerIndex], enemies[0], 2);
                    break;
                case (4):
                    success = useAbility(players[playerIndex], enemies[0], 3);
                    break;
                default:
                    Debug.Log("BUG");
                    break;
            }
            if (success)
            {
                players[playerIndex].takeTickingDamage();
                updateStatsInfo();
                if (enemyStunned)
                {
                    enemyStunned = false;
                    turnState = 0;
                }
                else
                {
                    turnState = 1;
                    turnCheck();
                }
            }
        }
    }

    public List<Ability> getPlayerAbilities()
    {
        return players[playerIndex].getAbilities();
    }

    public void swapPlayerCanvas(bool active)
    {
        playerSwitchCanvas.SetActive(active);
    }

    public void switchPlayer(int index)
    {
        playerIndex = index - 1;
        updateStatsInfo();
        updateSprite();
        updateButtons();
    }

    public void updateButtons()
    {
        List<Ability> abilityList = getPlayerAbilities();
        GameObject buttonsParent = GameObject.FindGameObjectWithTag("CombatButtons");
        Button[] combatbuttonsObj = buttonsParent.GetComponentsInChildren<Button>();
        combatbuttonsObj[0].GetComponentInChildren<Text>().text = abilityList[0].name;
        combatbuttonsObj[1].GetComponentInChildren<Text>().text = abilityList[1].name;
        combatbuttonsObj[2].GetComponentInChildren<Text>().text = abilityList[2].name;
        combatbuttonsObj[3].GetComponentInChildren<Text>().text = abilityList[3].name;
    }
    
}
