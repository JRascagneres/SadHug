using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public enum PlayerType {CompSci, Chem, Sport, Physc, Music};

    public PlayerType playerType;

    private static int maxAP = 10;
    private int currentAP = maxAP;
    
    public List<Ability> abilityList = new List<Ability>();
    private Abilities abilities = new Abilities();
    public Player()
    {
        switch (playerType)
        {
            case PlayerType.CompSci:
                setHealth(125);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                break;
            case PlayerType.Chem:
                setHealth(150);
                break;
            case PlayerType.Sport:
                setHealth(250);
                break;
            case PlayerType.Physc:
                setHealth(175);
                break;
            case PlayerType.Music:
                setHealth(100);
                break;
        }
    }

    public void setCurrentAP(int newAP)
    {
        this.currentAP = newAP;
    }

    public int getCurrentAP()
    {
        return this.currentAP;
    }

    public List<Ability> getAbilities()
    {
        return abilityList;
    }
    
}
