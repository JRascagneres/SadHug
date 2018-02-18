using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    //Boolean value to signal if the game has ended or not
    bool gameHasEnded = false;

    //Main player game object
    public GameObject player;

    void Start()
    {
        //Assigns the player to the game object with tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;                            //assigns true to the variable to signal the game has ended
            player.SetActive(false);                        //Player is switched to false
            Debug.Log("Game Over");                         //Prints game over to console
            SceneManager.LoadScene("EndGameScene");         //Loads the end game scene
        }
      
    }

    void Restart()
    {
        ScoreScript.scoreValue = 0;                                     //Score is reset to 0
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //Reloads scene to restart
    }

}
