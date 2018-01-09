using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CombatMode {

    // --- Initial Setup Parameters To Be Accessed Globally ---
    private List<Player> players;
    private List<Enemy> enemies;
    private int playerIndex;
    private int enemyIndex;
    private Text playerHealth;
    private Text enemyHealth;
    private Text playerAP;
    private bool playerTurn;
    private GameObject combatCanvas; 
    private bool enemyStunned = false;
    private bool playerStunned = false;
    private GameObject playerSwitchCanvas;
    private GameObject playerPlaceHolderObj;
    private GameObject enemyPlaceHolderObj;
    private Animator playerAnimator;
    private Animator enemyAnimator;
    private AnimationEvent evt;


    public CombatMode(List<Player> players, List<Enemy> enemies)
    {
        //Set reference to the player swapping view and then hide
        playerSwitchCanvas = GameObject.FindGameObjectWithTag("CombatPlayerSwapCanvas");
        playerSwitchCanvas.SetActive(false);

        //Set reference to combatmode canvas
        combatCanvas = GameObject.FindGameObjectWithTag("CombatCanvas");

        //Sets player and enemy index
        playerIndex = 0;
        enemyIndex = 1;

        //Sets reference to the players and enemies in the battle
        this.players = players;
        this.enemies = enemies;

        //Sets reference to player health, enemy health and player abilty point bars
        playerHealth = GameObject.FindGameObjectWithTag("Player Health").GetComponent<Text>() as Text;
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy Health").GetComponent<Text>() as Text;
        playerAP = GameObject.FindGameObjectWithTag("Player AP").GetComponent<Text>() as Text;

        //Sets playerSprite and sprite playerAnimator
        playerPlaceHolderObj = GameObject.FindGameObjectWithTag("Player Placeholder");
        playerAnimator = playerPlaceHolderObj.GetComponent<Animator>();

        //Sets enemyAnimator
        enemyPlaceHolderObj = GameObject.FindGameObjectWithTag("Enemy Placeholder");
        enemyAnimator = enemyPlaceHolderObj.GetComponent<Animator>();

        //Sets stats and sprites
        updateStatsInfo();
        updateSprite();

        //Initialise turns
        startCombat();
    }


    //Starts the turns with player having first turn
    void startCombat()
    {
        playerTurn = true;
    }

    //Checks who's turn, if enemys turn run the attack command
    void turnCheck()
    {
        switch (playerTurn)
        {
            case (false):
                enemyAttack();
                break;

        }
    }

    //Method ran when an enemy attacks
    void enemyAttack()
    {
        if (enemies[enemyIndex].getHealth() != 0)
        {
            doDamage(players[playerIndex], 5);
            playerEnemyCastAnimation();
            updateStatsInfo();
            enemies[enemyIndex].takeTickingDamage();
            updateStatsInfo();
            if (playerStunned)
            {
                playerStunned = false;
                playerTurn = false;
                turnCheck();
            }
            else
            {
                playerTurn = true;
            }
        }
    }

    //Updates UI bars -- Player Health, Enemy Health and Player AP
    void updateStatsInfo()
    {
        Image playerHealthBar = GameObject.FindGameObjectWithTag("Player Health Bar").GetComponent<Image>() as Image;
        playerHealthBar.fillAmount = (float)players[playerIndex].getHealth() / (float)players[playerIndex].getMaxHealth();
        playerHealth.text = players[playerIndex].getHealth().ToString() + "/" + players[playerIndex].getMaxHealth().ToString();

        Image enemyHealthBar = GameObject.FindGameObjectWithTag("Enemy Health Bar").GetComponent<Image>() as Image;
        enemyHealthBar.fillAmount = (float)enemies[enemyIndex].getHealth() / (float)enemies[enemyIndex].getMaxHealth();
        enemyHealth.text = enemies[enemyIndex].getHealth().ToString() + "/" + enemies[enemyIndex].getMaxHealth().ToString();

        Image playerAPBar = GameObject.FindGameObjectWithTag("Player AP Bar").GetComponent<Image>() as Image;
        playerAPBar.fillAmount = (float)players[playerIndex].getCurrentAP() / (float)players[playerIndex].getMaxAP();
        playerAP.text = players[playerIndex].getCurrentAP().ToString() + "/" + players[playerIndex].getMaxAP().ToString();
    }

    //Updates animations depending on which player & enemy has been chosen
    void updateSprite()
    {
        AnimatorOverrideController playerAnimatorOverrideController = new AnimatorOverrideController(playerAnimator.runtimeAnimatorController);
        playerAnimator.runtimeAnimatorController = playerAnimatorOverrideController;
        playerAnimatorOverrideController["PlayerOneIdle"] = players[playerIndex].getIdleAnimation();
        playerAnimatorOverrideController["PlayerOneCast"] = players[playerIndex].getCastAnimation();
        playerAnimatorOverrideController["PlayerOneDeath"] = players[playerIndex].getDeathAnimation();

        AnimatorOverrideController enemyAnimatorOverrideController = new AnimatorOverrideController(enemyAnimator.runtimeAnimatorController);
        enemyAnimator.runtimeAnimatorController = enemyAnimatorOverrideController;
        enemyAnimatorOverrideController["EnemyOneIdle"] = enemies[enemyIndex].getIdleAnimation();
        enemyAnimatorOverrideController["EnemyOneCast"] = enemies[enemyIndex].getCastAnimation();
        enemyAnimatorOverrideController["EnemyOneDeath"] = enemies[enemyIndex].getDeathAnimation();
    }

    //Plays player attack animation
    void playPlayerCastAnimation()
    {
        playerAnimator.SetTrigger("Cast");
    }

    //Plays enemy attack animation
    void playerEnemyCastAnimation()
    {
        enemyAnimator.SetTrigger("Cast");
    }

    //Plays enemy death animation
    void playEnemyDeathAnimation()
    {
        enemyAnimator.SetTrigger("Dead");
    }

    //Takes character and damageAmount and damages the character by that amount - Lower bound set to 0 health
    public void doDamage(Character character, int damageAmount)
    {
        int newHealth = character.takeDamage(damageAmount);
        if(newHealth <= 0)
        {
            character.setHealth(0);
            if(character is Enemy)
            {
                playEnemyDeathAnimation();
            }
            else
            {
                //Player DEATH
            }
        }
    }

    //Takes character and healtAmount and heals the character by that amount
    public void doHeal(Character character, int healAmount)
    {
        character.doHeal(healAmount);
    }

    //Updates AP of player and returns true or false, depending on whether the character has enough AP
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

    //Uses an ability - Pass player, enemy, and index of ability
    public bool useAbility(Player player, Enemy enemy, int abilityIndex)
    {
        //If player has no health no action can be performed so nothing happens
        if (player.getHealth() == 0)
        {
            return false;
        }

        //Get ability being used
        Ability ability = player.getAbilities()[abilityIndex];

        //Check if player has enough AP
        bool success = updateAP(player, ability.apCost);

        //If enough AP
        if (success)
        {
            //For each ability type this tells the program what to do
            Ability.abilityTypes abilityType = ability.abilityType;
            playPlayerCastAnimation();
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
                    enemies[enemyIndex].setTickingDamage(true);
                    enemies[enemyIndex].setTickingDamagePerTurn(ability.effectMagnitude);
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

    //Runs attack depending on which button is pressed
    public void attackButton(int attackButtonNumber)
    {
        //Only perform action on button press if its the players turn and animation is finished
        if (playerTurn)
        {
            //Uses ability depending on button press -- success is whether the ability was able to be ran
            bool success = false;
            switch (attackButtonNumber)
            {
                case (1):
                    success = useAbility(players[playerIndex], enemies[enemyIndex], 0);
                    break;
                case (2):
                    success = useAbility(players[playerIndex], enemies[enemyIndex], 1);
                    break;
                case (3):
                    success = useAbility(players[playerIndex], enemies[enemyIndex], 2);
                    break;
                case (4):
                    success = useAbility(players[playerIndex], enemies[enemyIndex], 3);
                    break;
                default:
                    Debug.Log("BUG");
                    break;
            }

            //if ability was able to be ran
            if (success)
            {
                //Do player ticking damage at end of turn
                players[playerIndex].takeTickingDamage();

                //Update stats bars
                updateStatsInfo();

                //If enemy is stunned jump back to player turn otherwise give enemy a turn
                if (enemyStunned)
                {
                    enemyStunned = false;
                    playerTurn = true;
                }
                else
                {
                    playerTurn = false;
                    turnCheck();
                }
            }
        }
    }

    //Get player abilities of current player
    public List<Ability> getPlayerAbilities()
    {
        return players[playerIndex].getAbilities();
    }

    //Opens swap player canvas
    public void swapPlayerCanvas(bool active)
    {
        playerSwitchCanvas.SetActive(active);
    }

    //Switch player when function is ran, takes player index as an parameter
    public void switchPlayer(int index)
    {
        playerIndex = index - 1;
        updateStatsInfo();
        updateSprite();
        updateButtons();
    }

    //Update button text to ability names
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
