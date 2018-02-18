using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-- This whole class was added for Assessment 3

/// <summary>
/// Simply updates money shown in town mode
/// </summary>
public class MoneyUpdate : MonoBehaviour {

    /// <summary>
    /// Ensures money is kept up to date in town mode
    /// </summary>
    void Update()
    {
        Text moneyText = gameObject.GetComponent<Text>();
        moneyText.text = "Current Money: " + PlayerData.instance.data.Money;
    }
}
