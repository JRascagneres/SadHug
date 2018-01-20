using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitchButtonHandler : MonoBehaviour {

    //All buttons on the character switch screen
    public Button CharacterOneBtn;
    public Button CharacterTwoBtn;
    public Button CharacterThreeBtn;
    public Button CharacterFourBtn;
    public Button CharacterFiveBtn;
    public Button GoBack;

    //Global reference required for these classes
    GameManager _gameManager;
    CombatMode _combatMode;

    // Use this for initialization
    void Start () {
        //All button and gamemanager references set to ingame objects
        CharacterOneBtn = CharacterOneBtn.GetComponent<Button>();
        CharacterOneBtn.onClick.AddListener(CharacterOneSwitch);
        CharacterTwoBtn = CharacterTwoBtn.GetComponent<Button>();
        CharacterTwoBtn.onClick.AddListener(CharacterTwoSwitch);
        CharacterThreeBtn = CharacterThreeBtn.GetComponent<Button>();
        CharacterThreeBtn.onClick.AddListener(CharacterThreeSwitch);
        CharacterFourBtn = CharacterFourBtn.GetComponent<Button>();
        CharacterFourBtn.onClick.AddListener(CharacterFourSwitch);
        CharacterFiveBtn = CharacterFiveBtn.GetComponent<Button>();
        CharacterFiveBtn.onClick.AddListener(CharacterFiveSwitch);
        GoBack = GoBack.GetComponent<Button>();
        GoBack.onClick.AddListener(GoBackButton);

        _gameManager = GameManager.Instance;
    }
	
    //Ran when buttons clicked passed index of player to switch to
	void CharacterOneSwitch()
    {
        SwitchPlayer(1);
    }

    void CharacterTwoSwitch()
    {
        SwitchPlayer(2);
    }

    void CharacterThreeSwitch()
    {
        SwitchPlayer(3);
    }

    void CharacterFourSwitch()
    {
        SwitchPlayer(4);
    }

    void CharacterFiveSwitch()
    {
        SwitchPlayer(5);
    }

    //Switches current combat player which is set in combatmode
    void SwitchPlayer (int index)
    {
        _combatMode = _gameManager.GetCombatMode();
        _combatMode.SwitchPlayer(index);
        CloseMenu();
    }

    //Calls closeMenu() when close button pressed
    void GoBackButton()
    {
        CloseMenu();
    }

    //Close menu which is set in combatmode
    void CloseMenu()
    {
        _combatMode = _gameManager.GetCombatMode();
        _combatMode.SwapPlayerCanvas(false);
    }
}
