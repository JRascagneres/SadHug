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
