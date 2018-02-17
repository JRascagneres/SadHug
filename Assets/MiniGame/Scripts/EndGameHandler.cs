using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameHandler : MonoBehaviour {

    private Canvas thisCanvas;
    private Button endGameButton;
    private Text scoreText;
    private int score;

    /// <summary>
    /// Start method sets references to all GameObjects required
    /// </summary>
	void Start () {
        thisCanvas = gameObject.GetComponent<Canvas>();
        scoreText = thisCanvas.transform.GetChild(2).GetComponent<Text>();
    }

    /// <summary>
    /// Ensures score is correct when scene opens
    /// </summary>
    void Update ()
    {
        score = ScoreScript.scoreValue;
        scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Restarts the miniGame - Gives player reward money, resets score
    /// </summary>
    public void playAgain()
    {
        SceneManager.LoadScene("MiniGame");
        PlayerData.instance.data.Money += score;
        ScoreScript.scoreValue = 0;
    }

    /// <summary>
    /// Exits to WorldMap - Gives player reward money
    /// </summary>
    public void endGame()
    {
        SceneManager.LoadScene("WorldMap");
        GlobalFunctions.instance.player.SetActive(true);
        PlayerData.instance.data.Money += score;
    }

}
