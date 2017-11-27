using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private List<Player> players = new List<Player>();
    private List<Enemy> enemies = new List<Enemy>();

    CombatMode combatMode;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {

        string[] playerTypes = Enum.GetNames(typeof(Player.PlayerType));
        foreach(String player in playerTypes)
        {
            Player.PlayerType playerType =  (Player.PlayerType)Enum.Parse(typeof(Player.PlayerType), player);
            Player playerObj = new Player(playerType);
            players.Add(playerObj);
        }

        enemies.Add(new Enemy(Enemy.EnemyType.TestBoi));

        combatMode = new CombatMode(players, enemies);
    }

    public CombatMode getCombatMode()
    {
        return combatMode;
    }
}
