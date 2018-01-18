using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Variables initialised
    public static GameManager instance = null;
    private List<Player> players = new List<Player>();
    private List<Enemy> enemies = new List<Enemy>();

    CombatMode combatMode;

    //Ensures that only one instance of GameManager exists and that it can be addressed uses GameManager.instance();
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    //Loops through all players and creates one of each and puts into players list
    void Start () {

        string[] playerTypes = Enum.GetNames(typeof(Player.PlayerType));
        foreach(String player in playerTypes)
        {
            Player.PlayerType playerType =  (Player.PlayerType)Enum.Parse(typeof(Player.PlayerType), player);
            Player playerObj = new Player(playerType);
            players.Add(playerObj);
        }

        string[] enemyTypes = Enum.GetNames(typeof(Enemy.EnemyType));
        foreach (String enemy in enemyTypes)
        {
            Enemy.EnemyType enemyType = (Enemy.EnemyType)Enum.Parse(typeof(Enemy.EnemyType), enemy);
            Enemy enemyObj = new Enemy(enemyType);
            enemies.Add(enemyObj);
        }

        
    }

    public void makeCombatMode(int enemyIndex, String prevScene)
    {
        Enemy enemy = enemies[enemyIndex];
        List<Enemy> Nenemies = new List<Enemy>();
        Nenemies.Add(enemy);
        combatMode = new CombatMode(players, Nenemies, prevScene);
    }

    //Returns current combatmode
    public CombatMode getCombatMode()
    {
        return combatMode;
    }
}
