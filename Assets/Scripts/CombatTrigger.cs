using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTrigger : MonoBehaviour {

    
    public void OnTriggerEnter2D(Collider2D col)
    {
        //Checks if collison is with MainPlayer
        if(col.gameObject.name == "MainPlayer")
        {
            //Test if MainPlayer collides with EnemyOne or EnemyTwo
            String enemyName = gameObject.name;
            int enemyIndex = 1;
            if (enemyName == "EnemyOne")
            {
                enemyIndex = 0;
            }else if (enemyName == "EnemyTwo")
            {
                enemyIndex = 1;
            }
            //Loads combat mode and switches scene to combat scene
            GameManager.Instance.MakeCombatMode(enemyIndex, SceneManager.GetActiveScene().name);
            
        }
    }
}

