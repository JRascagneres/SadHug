using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ALL ADDED for assessment 3 
/// <summary>
/// A car spawner to spawn cars when triggered by a controller and give the correct variable to the car
/// </summary>
public class CarSpawner : MonoBehaviour {
    /// <summary>the facing value to give the cars 1 right -1 left </summary>
    public int Facing;
    /// <summary>the cars which it can spawn</summary>
    public GameObject[] Cars;
    /// <summary>the speeds which the cars initially have as default </summary>
    private float[] carSpeeds = {0.2f,0.4f,0.1f};
    
    /// <summary>
    /// A trigger to cause the spawner to spawn a chosen car
    /// </summary>
    /// <param name="which">the car which it should spawn as an int</param>
    public void Trigger(int which)
    {
        GameObject car = Instantiate(Cars[which]);
        car.transform.position = transform.position;
        car.GetComponent<CarScript>().SetFacing ( Facing);
        car.GetComponent<CarScript>().SetSpeed(carSpeeds[which]);
    }
    /// <summary>
    /// Set the diffucilty by multiplying the speeds by amount
    /// </summary>
    /// <param name="amount">the multipleier of which to increase the speeds</param>
    public void Harder(float amount)
    {
        for (int i=0;i<carSpeeds.Length;i++)
        {
            carSpeeds[i] *= amount;
        }
    }
    /// <summary>
    /// Reset the speeds to the origional
    /// </summary>
    public void Restart()
    {
        carSpeeds = new float[] { 0.2f, 0.4f, 0.1f };
    }

}
