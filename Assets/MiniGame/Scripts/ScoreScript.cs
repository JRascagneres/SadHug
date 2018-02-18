using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    //Score Value is set to 0 at start of game
    public static int scoreValue = 0;

    //Text to display score
    Text score;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text>(); //Get text component to display score
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + scoreValue;  //Displays the current score
	}
}
