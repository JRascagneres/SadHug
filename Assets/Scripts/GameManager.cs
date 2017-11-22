using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text playerHealth;
    public Text enemyHealth;
    public List<Player> players;
    public List<Enemy> enemies;

    CombatMode combatMode;

    // Use this for initialization
    void Start () {

        //@Michael if you add a new camera thingy go into CombatMode and in the initiate thing make sure the camera moves to where combat is
        //Initialise CombatMode
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
