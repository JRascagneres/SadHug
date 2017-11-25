using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Abilities
{
    public enum AbilityEnum {fiveDamage, tenHeal, tenPercentCurrent, tenPercentTotal};

    public Abilities() {
            
    }

    public Ability getAbility(AbilityEnum abEnum){
        switch (abEnum)
        {
            case AbilityEnum.fiveDamage:
                return new Ability("Five Damage", Ability.abilityTypes.numberDamage, "Does five damage", 1, 5);
            case AbilityEnum.tenHeal:
                return new Ability("Ten Heal", Ability.abilityTypes.numberHeal, "Heals 10", 3, 10);
            case AbilityEnum.tenPercentCurrent:
                return new Ability("Ten Percent Current", Ability.abilityTypes.percentCurrentDamage, "Ten Percent Current", 1, 10);
            case AbilityEnum.tenPercentTotal:
                return new Ability("Ten Percent Total", Ability.abilityTypes.percentTotalDamage, "Ten Percent Total", 1, 10);
            default:
                return null;
        }
    }


}
