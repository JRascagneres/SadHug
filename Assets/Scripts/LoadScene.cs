using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    //loads scene with the scene name as an arguement
	public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
