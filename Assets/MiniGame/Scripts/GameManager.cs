using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//-- This whole class was added for Assessment 3
/// <summary>
/// Class that handles when the game ends and handles restarting the game after game over
/// </summary>
public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public GameObject player;

    /// <summary>
    /// Assigns the player to the game object with tag "Player"
    /// </summary>
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    /// <summary>
    /// When GameOver function is called from <see cref="PlayerCollison.OnTriggerEnter2D(Collider2D)"/>,
    /// assigns true to the variable to signal the game has ended, Prints game over to console and loads the end game scene
    /// </summary>
    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;                            
            player.SetActive(false);                        
            Debug.Log("Game Over");                         
            SceneManager.LoadScene("EndGameScene");         
        }      
    }

    /// <summary>
    /// Function that restarts the game, Score is reset to 0 then Reloads scene to restart
    /// </summary>
    void Restart()
    {
        ScoreScript.scoreValue = 0;                                     
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     
    }

}
