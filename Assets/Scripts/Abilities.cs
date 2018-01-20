using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Abilities
{
    //Abilities are referred to with these enums
    public enum AbilityEnum {basicAttack, complain, changingVariables, enterTheMatrix, chemicalSpill, noxiousGas, explosiveReagents, pepTalk, hockeyClub, rko, reversePsychology, therapy, readingWeak, dischord, harmony, hearingDamage};

    //This gets the ability types and information inside of character class
    public Ability getAbility(AbilityEnum abEnum){
        switch (abEnum)
        {
            //Links the enum values to individual Abilities
            case AbilityEnum.basicAttack:
                return new Ability("Basic Attack", Ability.abilityTypes.numberDamage, "5 damage", 0, 5, false, false);
            case AbilityEnum.complain:
                return new Ability("Complain", Ability.abilityTypes.numberDamage, "25 Damage", 2, 25, false, false);
            case AbilityEnum.changingVariables:
                return new Ability("Changing Variables", Ability.abilityTypes.percentMaxHeal, "20% Max Heal", 2, 20, false, false);
            case AbilityEnum.enterTheMatrix:
                return new Ability("Enter The Matrix",Ability.abilityTypes.percentCurrentDamage, "30% of current enemy health", 3, 30, false, false);
            case AbilityEnum.chemicalSpill:
                return new Ability("Chemical Spill", Ability.abilityTypes.numberDamage, "Deals 15 damage to enemy", 1, 15, false, false);
            case AbilityEnum.noxiousGas:
                return new Ability("Noxious Gas", Ability.abilityTypes.enemyTickingDamage, "Poisen 10 damage per turn", 2, 10, false, true);
            case AbilityEnum.explosiveReagents:
                return new Ability("Explosive Reagents", Ability.abilityTypes.percentCurrentDamage, "40% of current enemy health", 5, 40, false, false);
            case AbilityEnum.pepTalk:
                return new Ability("Pep Talk", Ability.abilityTypes.groupAPIncrease, "Give 1 AP to all allies", 1, 1, false, false);
            case AbilityEnum.hockeyClub:
                return new Ability("Hockey Club", Ability.abilityTypes.enemyStun, "Stun 1 turn", 2, 0, true, false);
            case AbilityEnum.rko:
                return new Ability("RKO", Ability.abilityTypes.percentTotalDamage, "20% map hp damage", 4, 20, false, false);
            case AbilityEnum.reversePsychology:
                return new Ability("Reverse Psychology", Ability.abilityTypes.numberDamage, "20 damage", 2, 20, false, false);
            case AbilityEnum.therapy:
                return new Ability("Therapy", Ability.abilityTypes.groupAPIncrease, "Give 2 AP to all allies", 2, 2, false, false);
            case AbilityEnum.readingWeak:
                return new Ability("Reading 'weak'", Ability.abilityTypes.percentCurrentDamage, "20% of current enemy health", 3, 20, false, false);
            case AbilityEnum.dischord:
                return new Ability("Dischord", Ability.abilityTypes.enemyStun, "Stun 1 turn", 2, 0, true, false);
            case AbilityEnum.harmony:
                return new Ability("Harmony", Ability.abilityTypes.groupNumberHeal, "Heal allies for 25 HP", 2, 25, false, false);
            case AbilityEnum.hearingDamage:
                return new Ability("Hearing Damage", Ability.abilityTypes.numberDamage, "30 damage", 3, 30, false, false);
            
            default:
                return null;
        }
    }


}
