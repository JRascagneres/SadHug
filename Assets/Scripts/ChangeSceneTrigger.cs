﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("WorldMap");
    }
}
