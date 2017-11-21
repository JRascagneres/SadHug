using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Abilities
{
    public enum AbilityEnum {fiveDamage};

    public Abilities() {
            
    }

    public Ability getAbility(AbilityEnum abEnum){
        switch (abEnum)
        {
            case AbilityEnum.fiveDamage:
                return new Ability("Five Damage", "Does five damage", 1, 5);
            default:
                return null;
        }
    }


}
