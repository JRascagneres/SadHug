using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Variables initialised
    public static GameManager Instance = null;
    private List<Player> _players = new List<Player>();
    private List<Enemy> _enemies = new List<Enemy>();

    CombatMode _combatMode;

    //Ensures that only one instance of GameManager exists and that it can be addressed uses GameManager.instance();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    //Ran when GameManagaer is created, initialises list of players and enemies
    void Start () {
        GenerateCharacters(); 
    }

    //Loops through all players and enemies and creates one of each and puts into players list
    void GenerateCharacters()
    {
        _players = new List<Player>();
        _enemies = new List<Enemy>();

        string[] playerTypes = Enum.GetNames(typeof(Player.PlayerType));
        foreach (String player in playerTypes)
        {
            Player.PlayerType playerType = (Player.PlayerType)Enum.Parse(typeof(Player.PlayerType), player);
            Player playerObj = new Player(playerType);
            _players.Add(playerObj);
        }

        string[] enemyTypes = Enum.GetNames(typeof(Enemy.EnemyType));
        foreach (String enemy in enemyTypes)
        {
            Enemy.EnemyType enemyType = (Enemy.EnemyType)Enum.Parse(typeof(Enemy.EnemyType), enemy);
            Enemy enemyObj = new Enemy(enemyType);
            _enemies.Add(enemyObj);
        }
    }

    //Starts combat mode and send parameters to start with
    public void MakeCombatMode(int enemyIndex, String prevScene)
    {
        GenerateCharacters();

        Enemy enemy = _enemies[enemyIndex];
        List<Enemy> newEnemies = new List<Enemy>();
        newEnemies.Add(enemy);

        List<Player> newPlayers = new List<Player>();
        newPlayers.AddRange(_players);
        _combatMode = new CombatMode(newPlayers, newEnemies, prevScene);

        SceneManager.LoadScene("CombatMode");
    }

    //Returns current combatmode
    public CombatMode GetCombatMode()
    {
        return _combatMode;
    }
}
