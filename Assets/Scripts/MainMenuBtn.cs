using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtn : MonoBehaviour
{
    //Loads a new game switching to the scene in which you pass it
    public void NewGame(string newGame)
    {
        SceneManager.LoadScene(newGame);
    }

    //Quits game
    public void ExitGame()
    {
        Application.Quit();
    }
}
