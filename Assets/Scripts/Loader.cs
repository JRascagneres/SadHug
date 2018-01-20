using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject GameManager;

    //Created game manager instance on load (attach to any object in scene -- Usually camera)
    private void Awake()
    {
        if (global::GameManager.Instance == null)
            Instantiate(GameManager);
    }
}
