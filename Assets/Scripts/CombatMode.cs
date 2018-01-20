using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombatMode {

    // --- Initial Setup Parameters To Be Accessed Globally ---
    private List<Player> _players;
    private List<Enemy> _enemies;
    private String _prevScene;
    private int _playerIndex;
    private int _enemyIndex;
    private Text _playerHealth;
    private Text _enemyHealth;
    private Text _playerAp;
    private bool _playerTurn;
    private GameObject _combatCanvas; 
    private bool _enemyStunned = false;
    private bool _playerStunned = false;
    private GameObject _playerSwitchCanvas;
    private GameObject _playerPlaceHolderObj;
    private GameObject _enemyPlaceHolderObj;
    private Animator _playerAnimator;
    private Animator _enemyAnimator;
    private AnimationEvent _evt;


    public CombatMode(List<Player> players, List<Enemy> enemies, String prevScene)
    {
        //Sets reference to the players and enemies in the battle
        this._players = players;
        this._enemies = enemies;
        this._prevScene = prevScene;
    }

    //Called when combatmode is started - Ensures the objects are only looked for in the scene once fully initialised
    public void SwitchScene()
    {
        //Set reference to the player swapping view and then hide
        _playerSwitchCanvas = GameObject.FindGameObjectWithTag("CombatPlayerSwapCanvas");
        _playerSwitchCanvas.SetActive(false);

        //Set reference to combatmode canvas
        _combatCanvas = GameObject.FindGameObjectWithTag("CombatCanvas");

        //Sets player and enemy index
        _playerIndex = 0;
        _enemyIndex = 0;

        //Sets reference to player health, enemy health and player abilty point bars
        _playerHealth = GameObject.FindGameObjectWithTag("Player Health").GetComponent<Text>() as Text;
        _enemyHealth = GameObject.FindGameObjectWithTag("Enemy Health").GetComponent<Text>() as Text;
        _playerAp = GameObject.FindGameObjectWithTag("Player AP").GetComponent<Text>() as Text;

        //Sets playerSprite and sprite playerAnimator
        _playerPlaceHolderObj = GameObject.FindGameObjectWithTag("Player Placeholder");
        _playerAnimator = _playerPlaceHolderObj.GetComponent<Animator>();

        //Sets enemyAnimator
        _enemyPlaceHolderObj = GameObject.FindGameObjectWithTag("Enemy Placeholder");
        _enemyAnimator = _enemyPlaceHolderObj.GetComponent<Animator>();

        //Sets stats and sprites
        UpdateStatsInfo();
        UpdateSprite();

        //Initialise turns
        StartCombat();
    }

    //Starts the turns with player having first turn
    void StartCombat()
    {
        _playerTurn = true;
    }

    //Checks who's turn, if enemys turn run the attack command
    void TurnCheck()
    {
        switch (_playerTurn)
        {
            case (false):
                EnemyAttack();
                break;

        }
    }

    //Method ran when an enemy attacks
    void EnemyAttack()
    {
        if (_enemies[_enemyIndex].GetHealth() != 0)
        {
            DoDamage(_players[_playerIndex], 25);
            PlayerEnemyCastAnimation();
            UpdateStatsInfo();
            if (_enemies[_enemyIndex].GetTickingDamage()) { 
                DoDamage(_enemies[_enemyIndex], _enemies[_enemyIndex].GetTickingDamagePerTurn());
            }

        UpdateStatsInfo();
            if (_playerStunned)
            {
                _playerStunned = false;
                _playerTurn = false;
                TurnCheck();
            }
            else
            {
                _playerTurn = true;
            }
        }
    }

    //Updates UI bars -- Player Health, Enemy Health and Player AP
    void UpdateStatsInfo()
    {
        Image playerHealthBar = GameObject.FindGameObjectWithTag("Player Health Bar").GetComponent<Image>() as Image;
        playerHealthBar.fillAmount = (float)_players[_playerIndex].GetHealth() / (float)_players[_playerIndex].GetMaxHealth();
        _playerHealth.text = _players[_playerIndex].GetHealth().ToString() + "/" + _players[_playerIndex].GetMaxHealth().ToString();

        Image enemyHealthBar = GameObject.FindGameObjectWithTag("Enemy Health Bar").GetComponent<Image>() as Image;
        enemyHealthBar.fillAmount = (float)_enemies[_enemyIndex].GetHealth() / (float)_enemies[_enemyIndex].GetMaxHealth();
        _enemyHealth.text = _enemies[_enemyIndex].GetHealth().ToString() + "/" + _enemies[_enemyIndex].GetMaxHealth().ToString();

        Image playerApBar = GameObject.FindGameObjectWithTag("Player AP Bar").GetComponent<Image>() as Image;
        playerApBar.fillAmount = (float)_players[_playerIndex].GetCurrentAp() / (float)_players[_playerIndex].GetMaxAp();
        _playerAp.text = _players[_playerIndex].GetCurrentAp().ToString() + "/" + _players[_playerIndex].GetMaxAp().ToString();
    }

    //Updates animations depending on which player & enemy has been chosen
    void UpdateSprite()
    {
        AnimatorOverrideController playerAnimatorOverrideController = new AnimatorOverrideController(_playerAnimator.runtimeAnimatorController);
        _playerAnimator.runtimeAnimatorController = playerAnimatorOverrideController;
        playerAnimatorOverrideController["PlayerOneIdle"] = _players[_playerIndex].GetIdleAnimation();
        playerAnimatorOverrideController["PlayerOneCast"] = _players[_playerIndex].GetCastAnimation();
        playerAnimatorOverrideController["PlayerOneDeath"] = _players[_playerIndex].GetDeathAnimation();
        playerAnimatorOverrideController["PlayerOneDead"] = _players[_playerIndex].GetDeadAnimation();

        AnimatorOverrideController enemyAnimatorOverrideController = new AnimatorOverrideController(_enemyAnimator.runtimeAnimatorController);
        _enemyAnimator.runtimeAnimatorController = enemyAnimatorOverrideController;
        enemyAnimatorOverrideController["EnemyOneIdle"] = _enemies[_enemyIndex].GetIdleAnimation();
        enemyAnimatorOverrideController["EnemyOneCast"] = _enemies[_enemyIndex].GetCastAnimation();
        enemyAnimatorOverrideController["EnemyOneDeath"] = _enemies[_enemyIndex].GetDeathAnimation();
        enemyAnimatorOverrideController["EnemyOneDead"] = _enemies[_enemyIndex].GetDeadAnimation();
    }

    //Plays player attack animation
    void PlayPlayerCastAnimation()
    {
        _playerAnimator.SetTrigger("Cast");
    }

    //Plays player death animation
    void PlayPlayerDeathAnimation()
    {
        _playerAnimator.SetTrigger("Death");
    }

    //Plays enemy attack animation
    void PlayerEnemyCastAnimation()
    {
        _enemyAnimator.SetTrigger("Cast");
    }

    //Plays enemy death animation
    void PlayEnemyDeathAnimation()
    {
        _enemyAnimator.SetTrigger("Death");
    }

    //Sets enemy state to dead
    void PlayEnemyDeadAnimation()
    {
        _enemyAnimator.SetTrigger("Dead");
    }

    //Sets player state to dead
    void PlayPlayerDeadAnimation()
    {
        _playerAnimator.SetTrigger("Dead");
    }

    //Reset player state to Idle
    void ResetPlayerAnimator()
    {
        _playerAnimator.SetTrigger("UnDead");
    }

    //Reset enemy state to Idle
    void ResetEnemyAnimator()
    {
        _enemyAnimator.SetTrigger("UnDead");
    }

    //Takes character and damageAmount and damages the character by that amount - Lower bound set to 0 health
    public void DoDamage(Character character, int damageAmount)
    {
        int newHealth = character.TakeDamage(damageAmount);
        if(newHealth <= 0)
        {
            character.SetHealth(0);
            if(character is Enemy)
            {
                PlayEnemyDeathAnimation();
                SceneManager.LoadScene(_prevScene);
            }
            else
            {
                PlayPlayerDeathAnimation();
                bool allDead = true;
                foreach (var player in _players)
                {
                    if (player.GetHealth() != 0)
                    {
                        allDead = false;
                    }
                }

                if (allDead)
                {
                    SceneManager.LoadScene(_prevScene);
                }
            }
        }
    }

    //Takes character and healtAmount and heals the character by that amount
    public void DoHeal(Character character, int healAmount)
    {
        character.DoHeal(healAmount);
    }

    //Updates AP of player and returns true or false, depending on whether the character has enough AP
    public bool UpdateAp(Player player, int ap)
    {
        int beforeAp = player.GetCurrentAp();
        int currentAp = player.UseAp(ap);
        if (currentAp < 0)
        {
            player.SetCurrentAp(beforeAp);
            return false;
        }
        return true;
    }

    //Uses an ability - Pass player, enemy, and index of ability
    public bool UseAbility(Player player, Enemy enemy, int abilityIndex)
    {
        //If player has no health no action can be performed so nothing happens
        if (player.GetHealth() == 0)
        {
            return false;
        }

        //Get ability being used
        Ability ability = player.GetAbilities()[abilityIndex];

        //Check if player has enough AP
        bool success = UpdateAp(player, ability.ApCost);

        //If enough AP
        if (success)
        {
            //For each ability type this tells the program what to do
            Ability.AbilityTypes abilityType = ability.AbilityType;
            PlayPlayerCastAnimation();
            switch (abilityType)
            {
                case (Ability.AbilityTypes.NumberDamage):
                    DoDamage(enemy, ability.EffectMagnitude);
                    break;
                case (Ability.AbilityTypes.NumberHeal):
                    DoHeal(player, ability.EffectMagnitude);
                    break;
                case (Ability.AbilityTypes.PercentMaxHeal):
                    DoHeal(player, player.GetMaxHealth() * ability.EffectMagnitude / 100);
                    break;
                case (Ability.AbilityTypes.PercentCurrentDamage):
                    DoDamage(enemy, enemy.GetHealth() * ability.EffectMagnitude / 100);
                    break;
                case (Ability.AbilityTypes.PercentTotalDamage):
                    DoDamage(enemy, enemy.GetMaxHealth() * ability.EffectMagnitude / 100);
                    break;
                case (Ability.AbilityTypes.GroupNumberHeal):
                    for(int i = 0; i < _players.Count; i++)
                    {
                        _players[i].DoHeal(ability.EffectMagnitude);
                    }
                    break;
                case (Ability.AbilityTypes.GroupApIncrease):
                    for (int i = 0; i < _players.Count; i++)
                    {
                        _players[i].GiveAp(ability.EffectMagnitude);
                    }
                    break;
                case (Ability.AbilityTypes.EnemyStun):
                    _enemyStunned = true;
                    break;
                case (Ability.AbilityTypes.PlayerStun):
                    _playerStunned = true;
                    break;
                case (Ability.AbilityTypes.EnemyTickingDamage):
                    _enemies[_enemyIndex].SetTickingDamage(true);
                    _enemies[_enemyIndex].SetTickingDamagePerTurn(ability.EffectMagnitude);
                    break;
                case (Ability.AbilityTypes.PlayerTickingDamage):
                    _players[_playerIndex].SetTickingDamage(true);
                    _players[_playerIndex].SetTickingDamagePerTurn(ability.EffectMagnitude);
                    break;
            }
        }
        UpdateStatsInfo();
        return success;
    }

    //Runs attack depending on which button is pressed
    public void AttackButton(int attackButtonNumber)
    {
        //Only perform action on button press if its the players turn and animation is finished
        if (_playerTurn && _playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            //Uses ability depending on button press -- success is whether the ability was able to be ran
            bool success = false;
            switch (attackButtonNumber)
            {
                case (1):
                    success = UseAbility(_players[_playerIndex], _enemies[_enemyIndex], 0);
                    break;
                case (2):
                    success = UseAbility(_players[_playerIndex], _enemies[_enemyIndex], 1);
                    break;
                case (3):
                    success = UseAbility(_players[_playerIndex], _enemies[_enemyIndex], 2);
                    break;
                case (4):
                    success = UseAbility(_players[_playerIndex], _enemies[_enemyIndex], 3);
                    break;
                default:
                    Debug.Log("BUG");
                    break;
            }

            //if ability was able to be ran
            if (success)
            {
                //Do player ticking damage at end of turn
                if (_players[_playerIndex].GetTickingDamage())
                {
                    DoDamage(_players[_playerIndex], _players[_playerIndex].GetTickingDamagePerTurn());
                }

                //Update stats bars
                UpdateStatsInfo();

                //If enemy is stunned jump back to player turn otherwise give enemy a turn
                if (_enemyStunned)
                {
                    _enemyStunned = false;
                    _playerTurn = true;
                }
                else
                {
                    _playerTurn = false;
                    TurnCheck();
                }
            }
        }
    }

    //Get player abilities of current player
    public List<Ability> GetPlayerAbilities()
    {
        return _players[_playerIndex].GetAbilities();
    }

    //Opens swap player canvas
    public void SwapPlayerCanvas(bool active)
    {
        _playerSwitchCanvas.SetActive(active);
    }

    //Switch player when function is ran, takes player index as an parameter
    public void SwitchPlayer(int index)
    {
        _playerIndex = index - 1;
        UpdateStatsInfo();
        UpdateSprite();
        UpdateButtons();

        Player player = _players[_playerIndex];
        Enemy enemy = _enemies[_enemyIndex];

        if (player.GetHealth() == 0)
        {
            PlayPlayerDeadAnimation();
        }
        else
        {
            ResetPlayerAnimator();
        }

        if (enemy.GetHealth() == 0)
        {
            PlayEnemyDeadAnimation();
        }
        else
        {
            ResetEnemyAnimator();
        }

    }

    //Update button text to ability names
    public void UpdateButtons()
    {
        List<Ability> abilityList = GetPlayerAbilities();
        GameObject buttonsParent = GameObject.FindGameObjectWithTag("CombatButtons");
        Button[] combatbuttonsObj = buttonsParent.GetComponentsInChildren<Button>();
        for (int i = 0; i < 4; i++)
        {
            Ability CurrentAbility = abilityList[i];
            combatbuttonsObj[i].GetComponentInChildren<Text>().text = CurrentAbility.Name + "  (" + CurrentAbility.ApCost + ")\n" + CurrentAbility.Description;
        }
    }
    
}
