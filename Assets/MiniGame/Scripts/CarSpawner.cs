using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {
    public int Facing;
    public GameObject[] Cars;
    private float[] carSpeeds = {0.2f,0.4f,0.1f};
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trigger(int which)
    {
        GameObject car = Instantiate(Cars[which]);
        car.transform.position = transform.position;
        car.GetComponent<CarScript>().SetFacing ( Facing);
        car.GetComponent<CarScript>().SetSpeed(carSpeeds[which]);
    }

    public void Harder(float amount)
    {
        for (int i=0;i<carSpeeds.Length;i++)
        {
            carSpeeds[i] *= amount;
        }
    }

}
