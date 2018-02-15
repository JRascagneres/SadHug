using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ALL ASSESSMENT 3 ADDITIONS

/// <summary>
/// A controller to controll the sataus of the minigame and most of its components
/// </summary>
public class CarController : MonoBehaviour
{
    /// <summary> An array of the different spawners being controlled to summon cars </summary>
    public GameObject[] Spawners;
    /// <summary> A tick that keeps counting ,used to manage the timings of how cars spawn </summary>
    private float tick;
    /// <summary> The increment of tick </summary>
    private float spd = 0.5f;
    /// <summary> the current level  </summary>
    private int level = 0;
    /// <summary>The scenechanger to get a nice transition </summary>
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
        //cheat if you find it hard press "p" a few times and then finish the level once
        if(Input.GetKeyDown(KeyCode.P))
        {
            level += 1;
        }
        //summon cars in a "nice" patten can increase spd to make cars summon faster
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
        //reset tick when a cycle is done
        tick += spd;
        if (tick > 100)
        {
            tick = 0;
        }

    }
    /// <summary>
    /// Draw the current level on the screen
    /// </summary>
    public void OnGUI()
    {
        Rect bounds = new Rect(40,40,140,140);
        GUI.Label(bounds, "Level: " + (level+1) + " /3");
    }
    /// <summary>
    /// Called when the player finishes a level, it increments the level by 1 and 
    /// checks to see if the player has finished all 3 levels if this is the case
    /// it loads back into the world map at the correct position
    /// additionaly it tells all the spawners to increase the car speeds by an amount
    /// </summary>
    /// <param name="amount">the amount of which to increase the car speeds</param>
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
            SoundManager.instance.playSFX("transition");
            if(SceneManager.GetActiveScene().name=="MiniGame")
                sceneChanger.loadLevel("WorldMap", new Vector2(-27,-42));
            else
                sceneChanger.loadLevel("WorldMap", new Vector2(23, -45));

        }

    }
    /// <summary>
    /// When the player runs out of lives this is called
    /// It resets level back to 0 and sets all the car speeds back to what they were origionally
    /// </summary>
    public void Restart()
    {
        level = 0;
        spd = 0.5f;
        for (int i = 0; i < Spawners.Length; i++)
        {
            Spawners[i].GetComponent<CarSpawner>().Restart();
        }
    }
}
