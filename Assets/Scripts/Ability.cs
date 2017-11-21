using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability {
    public string name;
    public string description;
    public int apCost;
    public int damage;
	
    public Ability(string name, string description, int apCost, int damage)
    {
        this.name = name;
        this.description = description;
        this.apCost = apCost;
        this.damage = damage;
    }

}
