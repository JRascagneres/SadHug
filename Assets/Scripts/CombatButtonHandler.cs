using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CombatButtonHandler : MonoBehaviour {

    //All buttons on the combat screen
    public Button combatOne;
    public Button combatTwo;
    public Button combatThree;
    public Button combatFour;
    public Button switchPlayer;

    //Bool checking if combatmode started initialised as bool
    private bool started = false;

    //Global reference required for these classes
    GameManager gameManager;
    CombatMode combatMode;

    void Start () {
        //All button and gamemanager references set to ingame objects
        gameManager = GameManager.instance;
        combatMode = gameManager.getCombatMode();

        Button combatButtonOne = combatOne.GetComponent<Button>();
        combatButtonOne.onClick.AddListener(combatOneAction);
        Button combatButtonTwo = combatTwo.GetComponent<Button>();
        combatButtonTwo.onClick.AddListener(combatTwoAction);
        Button combatButtonThree = combatThree.GetComponent<Button>();
        combatButtonThree.onClick.AddListener(combatThreeAction);
        Button combatButtonFour = combatFour.GetComponent<Button>();
        combatButtonFour.onClick.AddListener(combatFourAction);

        Button switchPlayerButton = switchPlayer.GetComponent<Button>();
        switchPlayerButton.onClick.AddListener(switchPlayerAction);
    }
	
	// Update is called once per frame
    //Checks if buttons have been initialised if not update the move text on the buttons and set started to true (been initialised)
	void Update () {
        if (started == false)
        {
            updateButtons();
            started = true;
        }
    }

    //Updates button text to their ability names
    public void updateButtons()
    {
        combatMode = gameManager.getCombatMode();
        List<Ability> abilityList = combatMode.getPlayerAbilities();
        combatOne.GetComponentInChildren<Text>().text = abilityList[0].name;
        combatTwo.GetComponentInChildren<Text>().text = abilityList[1].name;
        combatThree.GetComponentInChildren<Text>().text = abilityList[2].name;
        combatFour.GetComponentInChildren<Text>().text = abilityList[3].name;
    }

    //Methods called when buttons pressed (Tells combatmode which button has been pressed)
    void combatOneAction()
    {
        combatMode.attackButton(1);
    }

    void combatTwoAction()
    {
        combatMode.attackButton(2);
    }

    void combatThreeAction()
    {
        combatMode.attackButton(3);
    }

    void combatFourAction()
    {
        combatMode.attackButton(4);
    }

    //This one opens swap page when swap button pressed
    void switchPlayerAction()
    {
        combatMode.swapPlayerCanvas(true);
    }
}
