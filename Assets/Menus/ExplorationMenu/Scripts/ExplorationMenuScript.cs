using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    ///THIS IS AN ASSESMENT 3 CHANGE
	/// <summary>
	///Now a toggle mute button 
	/// </summary>
	public void optionPressed() {
        bool soundOn = SoundManager.instance.isSoundOn();
        
        if (soundOn)
            {
                SoundManager.instance.soundOn(false);
                
            }
            else
            {
                SoundManager.instance.soundOn(true);
                
            }
        
        
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
