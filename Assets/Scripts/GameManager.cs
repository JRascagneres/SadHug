using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private Text playerHealth;
    private Text enemyHealth;
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

        //@Michael if you add a new camera thingy go into CombatMode and in the initiate thing make sure the camera moves to where combat is
        //Initialise CombatMode

        GameObject[] enemiesGameObject = GameObject.FindGameObjectsWithTag("Enemies");

        foreach (GameObject enemyGameObject in enemiesGameObject)
        {
            enemies.Add(enemyGameObject.GetComponent<Enemy>() as Enemy);
        }

        GameObject[] playersGameObject = GameObject.FindGameObjectsWithTag("Players");

        foreach (GameObject playerGameObject in playersGameObject)
        {
            players.Add(playerGameObject.GetComponent<Player>() as Player);
        }

        playerHealth = GameObject.FindGameObjectWithTag("Player Health").GetComponent<Text>() as Text;
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy Health").GetComponent<Text>() as Text;

        combatMode = new CombatMode(players, enemies, playerHealth, enemyHealth);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public CombatMode getCombatMode()
    {
        return combatMode;
    }
}
