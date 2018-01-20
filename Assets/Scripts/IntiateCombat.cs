using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntiateCombat : MonoBehaviour {

	// Called when combat mode starts
	void Start () {

        GameManager.Instance.GetCombatMode().SwitchScene();
    }
}
