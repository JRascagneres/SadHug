using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTrigger : MonoBehaviour {


    // Use this for initialization
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "MainPlayer")
        {
            SceneManager.LoadScene("unity");
        }
    }
}

