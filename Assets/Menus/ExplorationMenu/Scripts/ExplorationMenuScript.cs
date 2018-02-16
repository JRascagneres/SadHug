using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// A script to manage the exploration menu that the user can call up at anytime
/// </summary>
public class ExplorationMenuScript : MonoBehaviour {

	public bool menuActive;
	//public bool pseudoKeyPress;
	private GameObject menuBox;
	private PlayerMovement movementScript;

	// Use this for initialization
	void Start () {
		movementScript = FindObjectOfType<PlayerMovement> ();
		//menuBox = gameObject.transform.Find ("MenuScript").gameObject;
		SceneChanger.instance.menuOpen = true;
		//setInactive ();
	}

	/// <summary>
	/// Hide menu and renable player movement
	/// </summary>
	private void setInactive() {
		menuBox.SetActive (false);
		movementScript.setCanMove (true);
		menuActive = false;
	}

	/// <summary>
	/// When the inventory button is pressed, update <see cref="SceneChanger"/> to show that <see cref="SceneChanger.menuOpen"/>
	/// is now false, and load the item menu  
	/// </summary>
	public void inventPressed() {
		SceneChanger.instance.menuOpen = false;
		SceneChanger.instance.loadLevel ("ItemMenu");
	}

	/// <summary>
	/// When the party button is pressed, update <see cref="SceneChanger"/> to show that <see cref="SceneChanger.menuOpen"/>
	/// is now false, and load the party menu
	/// </summary>
	public void partyPressed() {
		SceneChanger.instance.menuOpen = false;
		SceneChanger.instance.loadLevel ("Party");
	}

	/// <summary>
	/// Placeholder function for when the save button is pressed, to be implemented in later builds
	/// </summary>
	public void savePressed() {
        PlayerData.instance.data.Save();
    }

	/// <summary>
    /// Initiates town mode scene
	/// </summary>
	public void tradePressed() {
        SceneChanger.instance.menuOpen = false;
        SceneManager.LoadScene("TownMode", LoadSceneMode.Additive);
	}

    /// <summary>
    /// Initiates miniGame
	/// </summary>
	public void miniGamePressed()
    {
        SceneChanger.instance.menuOpen = false;
        //SceneManager.LoadScene("MiniGame", LoadSceneMode.Additive);
        SceneChanger.instance.loadLevel("MiniGame", new Vector2(0, 0));
    }

    /// <summary>
    /// When the exit button is pressed, update <see cref="SceneChanger"/> to show that <see cref="SceneChanger.menuOpen"/>
    /// is now false, and go back to the main menu
    /// </summary>
    public void exitPressed() {
		SceneChanger.instance.menuOpen = false;
		SceneChanger.instance.loadLevel ("mainmenu1");
	}
}
