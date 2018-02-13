using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public GameObject[] Spawners;
    private float tick;
    private float spd = 1f;
    private int level = 0;

    private SceneChanger sceneChanger;
    /// <summary>Sound effect to play when transitioning</summary>
    private AudioClip SFX;

    // Use this for initialization
    void Start()
    {
        sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            level += 1;
        }

        if (Mathf.Round(tick)/spd == Mathf.Round(10/spd))
        {
            Spawners[0].GetComponent<CarSpawner>().Trigger(0);
        }
        if (Mathf.Round(tick)/spd == Mathf.Round(30 /spd))
        {
            Spawners[1].GetComponent<CarSpawner>().Trigger(1);
        }
        if (Mathf.Round(tick)/spd == Mathf.Round(50 /spd))
        {
            Spawners[2].GetComponent<CarSpawner>().Trigger(1);
            Spawners[5].GetComponent<CarSpawner>().Trigger(0);
        }
        if (Mathf.Round(tick)/spd == Mathf.Round(70 /spd))
        {
            Spawners[3].GetComponent<CarSpawner>().Trigger(2);
        }
        if (Mathf.Round(tick)/spd == Mathf.Round(90 /spd))
        {
            Spawners[4].GetComponent<CarSpawner>().Trigger(2);
        }
        tick += spd;
        if (tick > 100)
        {
            tick = 0;
        }

    }

    public void OnGUI()
    {
        Rect bounds = new Rect(40,40,140,140);
        GUI.Label(bounds, "Level: " + level + " /3");
    }

    public void ChangeSpeed(float amount)
    {
        level += 1;
        spd += 0.5f;
        for (int i = 0; i < Spawners.Length; i++)
        {
            Spawners[i].GetComponent<CarSpawner>().Harder(amount);
        }

        if (level>=3)
        {
            //load correct scene
            Debug.Log("LOAD CORRECT LEVEL");
            SoundManager.instance.playSFX("transition");
            if(SceneManager.GetActiveScene().name=="MiniGame")
                sceneChanger.loadLevel("WorldMap", new Vector2(-46,-3));
            else
                sceneChanger.loadLevel("WorldMap", new Vector2(-13, -7));

        }

    }

    public void Restart()
    {
        level = 0;
        spd = 1f;
        for (int i = 0; i < Spawners.Length; i++)
        {
            Spawners[i].GetComponent<CarSpawner>().Restart();
        }
    }
}
