using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CombatButtonHandler : MonoBehaviour {

    //All buttons on the combat screen
    public Button CombatOne;
    public Button CombatTwo;
    public Button CombatThree;
    public Button CombatFour;
    public Button SwitchPlayer;

    //Bool checking if combatmode started initialised as bool
    private bool _started = false;

    //Global reference required for these classes
    GameManager _gameManager;
    CombatMode _combatMode;

    void Start () {
        //All button and gamemanager references set to ingame objects
        _gameManager = GameManager.Instance;
        _combatMode = _gameManager.GetCombatMode();

        Button combatButtonOne = CombatOne.GetComponent<Button>();
        combatButtonOne.onClick.AddListener(CombatOneAction);
        Button combatButtonTwo = CombatTwo.GetComponent<Button>();
        combatButtonTwo.onClick.AddListener(CombatTwoAction);
        Button combatButtonThree = CombatThree.GetComponent<Button>();
        combatButtonThree.onClick.AddListener(CombatThreeAction);
        Button combatButtonFour = CombatFour.GetComponent<Button>();
        combatButtonFour.onClick.AddListener(CombatFourAction);

        Button switchPlayerButton = SwitchPlayer.GetComponent<Button>();
        switchPlayerButton.onClick.AddListener(SwitchPlayerAction);
    }
	
	// Update is called once per frame
    //Checks if buttons have been initialised if not update the move text on the buttons and set started to true (been initialised)
	void Update () {
        if (_started == false)
        {
            UpdateButtons();
            _started = true;
        }
    }

    //Updates button text to their ability names
    public void UpdateButtons()
    {
        _combatMode = _gameManager.GetCombatMode();
        List<Ability> abilityList = _combatMode.GetPlayerAbilities();
        CombatOne.GetComponentInChildren<Text>().text = abilityList[0].Name;
        CombatTwo.GetComponentInChildren<Text>().text = abilityList[1].Name;
        CombatThree.GetComponentInChildren<Text>().text = abilityList[2].Name;
        CombatFour.GetComponentInChildren<Text>().text = abilityList[3].Name;
    }

    //Methods called when buttons pressed (Tells combatmode which button has been pressed)
    void CombatOneAction()
    {
        _combatMode.AttackButton(1);
    }

    void CombatTwoAction()
    {
        _combatMode.AttackButton(2);
    }

    void CombatThreeAction()
    {
        _combatMode.AttackButton(3);
    }

    void CombatFourAction()
    {
        _combatMode.AttackButton(4);
    }

    //This one opens swap page when swap button pressed
    void SwitchPlayerAction()
    {
        _combatMode.SwapPlayerCanvas(true);
    }
}
