using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitchButtonHandler : MonoBehaviour {

    public Button characterOneBtn;
    public Button characterTwoBtn;
    public Button characterThreeBtn;
    public Button characterFourBtn;
    public Button characterFiveBtn;
    public Button goBack;

    GameManager gameManager;
    CombatMode combatMode;

    // Use this for initialization
    void Start () {
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

    void switchPlayer (int index)
    {
        combatMode = gameManager.getCombatMode();
        combatMode.switchPlayer(index);
        closeMenu();
    }

    void goBackButton()
    {
        closeMenu();
    }

    void closeMenu()
    {
        GameObject.FindGameObjectWithTag("CombatPlayerSwapCanvas").GetComponent<Canvas>().sortingOrder = -5;
    }
}
