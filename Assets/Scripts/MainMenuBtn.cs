using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtn : MonoBehaviour
{
    public void NewGame(string newGame)
    {
        SceneManager.LoadScene("newGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
