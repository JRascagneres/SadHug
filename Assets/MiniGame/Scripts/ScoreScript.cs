using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-- This whole class was added for Assessment 3
/// <summary>
/// Script that handles displaying the correct score in the mingame
/// </summary>
public class ScoreScript : MonoBehaviour {

    public static int scoreValue = 0;
    Text score;

    /// <summary>
    /// Get text component to display score
    /// </summary>
    void Start () {
        score = GetComponent<Text>(); 
	}

    /// <summary>
    /// Displays the current score
    /// </summary>
    void Update () {
        score.text = "Score: " + scoreValue;  
	}
}
