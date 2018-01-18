using System;
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
            String enemyName = gameObject.name;
            int enemyIndex = 1;
            if (enemyName == "EnemyOne")
            {
                enemyIndex = 0;
            }else if (enemyName == "EnemyTwo")
            {
                enemyIndex = 1;
            }
            GameManager.instance.makeCombatMode(enemyIndex, SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("unity");
        }
    }
}

