using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger : MonoBehaviour {

    //Switches scene to world map when the Collider is triggered
	public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("WorldMap");
    }
}
