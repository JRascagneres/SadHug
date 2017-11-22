﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CombatButtonHandler : MonoBehaviour {

    public Button combatOne;
    public Button combatTwo;
    public Button combatThree;
    public Button combatFour;

    private bool started = false;

    GameManager gameManager;
    CombatMode combatMode;

    // Use this for initialization
    void Start () {
        gameManager = Camera.allCameras[0].GetComponent<GameManager>();

        Button combatButtonOne = combatOne.GetComponent<Button>();
        combatButtonOne.onClick.AddListener(combatOneAction);
        Button combatButtonTwo = combatTwo.GetComponent<Button>();
        combatButtonTwo.onClick.AddListener(combatTwoAction);
        Button combatButtonThree = combatThree.GetComponent<Button>();
        combatButtonThree.onClick.AddListener(combatThreeAction);
        Button combatButtonFour = combatFour.GetComponent<Button>();
        combatButtonFour.onClick.AddListener(combatFourAction);
    }
	
	// Update is called once per frame
	void Update () {
        if (started == false)
        {
            firstStartSetup();
            started = true;
        }
    }

    void firstStartSetup()
    {
        List<Ability> abilityList = gameManager.getCombatMode().getPlayerAbilities();
        combatOne.GetComponentInChildren<Text>().text = abilityList[0].name;
        combatTwo.GetComponentInChildren<Text>().text = abilityList[1].name;
        combatThree.GetComponentInChildren<Text>().text = abilityList[2].name;
        combatFour.GetComponentInChildren<Text>().text = abilityList[3].name;
    }

    void combatOneAction()
    {
        combatMode = gameManager.getCombatMode();
        combatMode.attackButton(1);
    }

    void combatTwoAction()
    {
        combatMode = gameManager.getCombatMode();
        combatMode.attackButton(2);
    }

    void combatThreeAction()
    {
        combatMode = gameManager.getCombatMode();
        combatMode.attackButton(3);
    }

    void combatFourAction()
    {
        combatMode = gameManager.getCombatMode();
        combatMode.attackButton(4);
    }
}