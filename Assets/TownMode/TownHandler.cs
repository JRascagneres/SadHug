using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownHandler : MonoBehaviour {

    void Start()
    {
    }

   public void goBack()
    {
        SceneChanger.instance.loadLevel(SceneManager.GetSceneAt(0).name);
    }
}
