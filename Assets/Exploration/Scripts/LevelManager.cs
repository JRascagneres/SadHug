﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// A script used to check and handle when a level is beat by defeating the final boss
///  </summary>
public class LevelManager : MonoBehaviour {

	/// <summary>
	/// The name of the object that should be beat in order to progress
	/// </summary>
	[SerializeField]
	private string bossObjectName = "Boss";
	/// <summary>
	/// The position that the player should spawn at on the world map once beat
	/// </summary>
	private Player newPlayer;
	private string playerDesc;
    private bool addPlayer = false;
	[SerializeField]
	private Vector2 worldMapExitPosition;

	/// <summary>
	/// When the scene is loaded (either at the start or after exiting the boss battle scene, check if boss has been
	/// defeated and if so increase <see cref="GlobalFunctions.currentLevel"/> and send the player back to the world map.
	/// A new player will also be added to the team with a brief description shown
	/// </summary>
	void Start () {
		switch (GlobalFunctions.instance.currentLevel) {
		case (0):
                addPlayer = true;
                newPlayer = new Player("Gorilla", 3, 100, 20, 20, 10, 10, 5, 5, 0, null,
                new LowerDefence("beats chest at", "Decrease enemy defence by 80%", 2, 0.8f),
                new MagicAttack("punches", "Punches his enemy in the face! for power 30", 4, 30),
                (Texture2D)Resources.Load("Gorilla", typeof(Texture2D)));
                newPlayer.IsGorilla = true;
			playerDesc = "Whats this?! A Gorilla joined your team! He seems like he could be a powerful addition to your team but be careful! " +
                    "Gorilla's are unpredictable!";
			break;
		case (1):
                addPlayer = true;
                newPlayer = new Player ("Alice", 3, 100, 15, 12, 10, 10, 15, 25, 0, null,
				new LowerSpeed ("tripped", "Decrease enemy speed by 30%", 3, 0.3f),
				new MagicAttack ("charged at", "Charge at the enemy with damage 18", 5, 18),
				(Texture2D) Resources.Load("Character4", typeof(Texture2D)));
			playerDesc = "You got a new team member, Alice! She's from James and has very high speed but lower" +
				" defence. Her specials can slow the enemy and attack by charging straight at them";
			break;
		case (2):
                addPlayer = true;
                newPlayer = new Player ("Josh", 4, 100, 15, 25, 10, 10, 15, 5, 0, null,
				new RaiseAttack ("strengthened up against", "Increase attack by 20%", 6, 0.2f),
				new MagicAttack ("gave asbestos poisoning to", "Use asbestos to damage with power 15", 3, 15),
				(Texture2D) Resources.Load("Character5", typeof(Texture2D)));
			playerDesc = "You got a new team member, Josh! He's from Derwent and has very high defence" +
				" but low speed. His specials can raise his attack or give asbestos poison to the enemy";
			break;
		case (3):
                addPlayer = true;
                newPlayer = new Player ("Lucy", 5, 100, 13, 18, 15, 15, 23, 18, 0, null,
				new MagicAttack ("outsmarted", "Attack with power 13", 4, 13),
				new MagicAttack ("threw their dissertation at", "Use dissertation to attack with power 20", 6, 20),
				(Texture2D) Resources.Load("Character6", typeof(Texture2D)));
			playerDesc = "You got a new team member, Lucy! She's from Wentworth and has great magic spells" +
				" but low standard attack. Both her specials attack using her superior intelect.";
			break;
		default: 
			break;
		}

		IDictionary<string,bool> objectsActive = GlobalFunctions.instance.objectsActive;
		string key = SceneManager.GetActiveScene ().name + bossObjectName;
		if (objectsActive.ContainsKey(key)) {
			if (!GlobalFunctions.instance.objectsActive [key]) {
				StartCoroutine (WaitThenLoad ());
			}
		}
	}
    //added "addplayer" to fix bugs present from assessment 2 in assessment 3
	/// <summary>
	/// Function called by <see cref="Start"/> once boss has been beaten
	/// Applies all functions along with waiting 5 seconds for user to read dialogue about new player
	/// </summary>
	/// <returns>The then load.</returns>
	private IEnumerator WaitThenLoad() {
        if(addPlayer)
		PlayerData.instance.data.addPlayer (newPlayer);
		GameObject dialogueBox = GameObject.Find ("Dialogue Manager").transform.Find ("DialogueBox").gameObject;
		dialogueBox.SetActive (true);
		Text dialogueText = dialogueBox.transform.Find("DialogueText").GetComponent<Text> ();
		dialogueText.text = playerDesc;
		GlobalFunctions.instance.currentLevel += 1;
		Debug.Log ("Beat the level!");
		GameObject.FindObjectOfType<PlayerMovement> ().setCanMove (false);
		while (!Input.GetKeyDown (KeyCode.Space)) { 
			yield return null;
		}
		dialogueBox.SetActive (false);
        if(GlobalFunctions.instance.currentLevel== GlobalFunctions.instance.lastLevel)
            SceneChanger.instance.loadLevel("EndScene", worldMapExitPosition);
        else
            SceneChanger.instance.loadLevel ("WorldMap", worldMapExitPosition);
	}

}
