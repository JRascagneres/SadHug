using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUItext : MonoBehaviour {
    public GUIText scoreText;
    public float score;

    Player_minigame p;
	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
	}
	
	// Update is called once per frame
	void UpdateScore () {
        scoreText.text = "Score: " + score;

	}
    public void AddScore(float newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void TimeAlive()
    {
        if (p.GetComponent<Player_minigame>().curHP > 0)
        {
            score += Time.deltaTime;
            AddScore(score);
        }
    }
}
