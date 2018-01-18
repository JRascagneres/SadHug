using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntiateCombat : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameManager.instance.getCombatMode().switchScene();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
