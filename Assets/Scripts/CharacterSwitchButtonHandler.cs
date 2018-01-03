using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitchButtonHandler : MonoBehaviour {

    //All buttons on the character switch screen
    public Button characterOneBtn;
    public Button characterTwoBtn;
    public Button characterThreeBtn;
    public Button characterFourBtn;
    public Button characterFiveBtn;
    public Button goBack;

    //Global reference required for these classes
    GameManager gameManager;
    CombatMode combatMode;

    // Use this for initialization
    void Start () {
        //All button and gamemanager references set to ingame objects
        characterOneBtn = characterOneBtn.GetComponent<Button>();
        characterOneBtn.onClick.AddListener(characterOneSwitch);
        characterTwoBtn = characterTwoBtn.GetComponent<Button>();
        characterTwoBtn.onClick.AddListener(characterTwoSwitch);
        characterThreeBtn = characterThreeBtn.GetComponent<Button>();
        characterThreeBtn.onClick.AddListener(characterThreeSwitch);
        characterFourBtn = characterFourBtn.GetComponent<Button>();
        characterFourBtn.onClick.AddListener(characterFourSwitch);
        characterFiveBtn = characterFiveBtn.GetComponent<Button>();
        characterFiveBtn.onClick.AddListener(characterFiveSwitch);
        goBack = goBack.GetComponent<Button>();
        goBack.onClick.AddListener(goBackButton);

        gameManager = GameManager.instance;
    }
	
    //Ran when buttons clicked passed index of player to switch to
	void characterOneSwitch()
    {
        switchPlayer(1);
    }

    void characterTwoSwitch()
    {
        switchPlayer(2);
    }

    void characterThreeSwitch()
    {
        switchPlayer(3);
    }

    void characterFourSwitch()
    {
        switchPlayer(4);
    }

    void characterFiveSwitch()
    {
        switchPlayer(5);
    }

    //Switches current combat player which is set in combatmode
    void switchPlayer (int index)
    {
        combatMode = gameManager.getCombatMode();
        combatMode.switchPlayer(index);
        closeMenu();
    }

    //Calls closeMenu() when close button pressed
    void goBackButton()
    {
        closeMenu();
    }

    //Close menu which is set in combatmode
    void closeMenu()
    {
        combatMode.swapPlayerCanvas(false);
    }
}
