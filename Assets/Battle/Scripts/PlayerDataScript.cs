﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataScript : MonoBehaviour {

	public Player[] playerArray;

	// Use this for initialization
	void Start () {
		playerArray = new Player[6];
		for (int i = 0; i < 6; i++) {
			playerArray [i] = new Player("Test",1,100,1,1,1,1,1,0,"None");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Player[] getData() {
		return playerArray;
	}

}
