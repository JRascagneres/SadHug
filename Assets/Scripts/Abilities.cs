using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Abilities
{
    //Abilities are referred to with these enums
    public enum AbilityEnum {BasicAttack, Complain, ChangingVariables, EnterTheMatrix, ChemicalSpill, NoxiousGas, ExplosiveReagents, PepTalk, HockeyClub, Rko, ReversePsychology, Therapy, ReadingWeak, Dischord, Harmony, HearingDamage};

    //This gets the ability types and information inside of character class
    public Ability GetAbility(AbilityEnum abEnum){
        switch (abEnum)
        {
            //Links the enum values to individual Abilities
            case AbilityEnum.BasicAttack:
                return new Ability("Basic Attack", Ability.AbilityTypes.NumberDamage, "5 damage", 0, 5, false, false);
            case AbilityEnum.Complain:
                return new Ability("Complain", Ability.AbilityTypes.NumberDamage, "25 Damage", 2, 25, false, false);
            case AbilityEnum.ChangingVariables:
                return new Ability("Changing Variables", Ability.AbilityTypes.PercentMaxHeal, "20% Max Heal", 2, 20, false, false);
            case AbilityEnum.EnterTheMatrix:
                return new Ability("Enter The Matrix",Ability.AbilityTypes.PercentCurrentDamage, "30% of current health", 3, 30, false, false);
            case AbilityEnum.ChemicalSpill:
                return new Ability("Chemical Spill", Ability.AbilityTypes.NumberDamage, "Deals 15 damage to enemy", 1, 15, false, false);
            case AbilityEnum.NoxiousGas:
                return new Ability("Noxious Gas", Ability.AbilityTypes.EnemyTickingDamage, "Poisen 10 damage per turn", 2, 10, false, true);
            case AbilityEnum.ExplosiveReagents:
                return new Ability("Explosive Reagents", Ability.AbilityTypes.PercentCurrentDamage, "40% of current health", 5, 40, false, false);
            case AbilityEnum.PepTalk:
                return new Ability("Pep Talk", Ability.AbilityTypes.GroupApIncrease, "Give 1 AP to all allies", 1, 1, false, false);
            case AbilityEnum.HockeyClub:
                return new Ability("Hockey Club", Ability.AbilityTypes.EnemyStun, "Stun 1 turn", 2, 0, true, false);
            case AbilityEnum.Rko:
                return new Ability("RKO", Ability.AbilityTypes.PercentTotalDamage, "20% map hp damage", 4, 20, false, false);
            case AbilityEnum.ReversePsychology:
                return new Ability("Reverse Psychology", Ability.AbilityTypes.NumberDamage, "20 damage", 2, 20, false, false);
            case AbilityEnum.Therapy:
                return new Ability("Therapy", Ability.AbilityTypes.GroupApIncrease, "Give 2 AP to all allies", 2, 2, false, false);
            case AbilityEnum.ReadingWeak:
                return new Ability("Reading 'weak'", Ability.AbilityTypes.PercentCurrentDamage, "20% of current health", 3, 20, false, false);
            case AbilityEnum.Dischord:
                return new Ability("Dischord", Ability.AbilityTypes.EnemyStun, "Stun 1 turn", 2, 0, true, false);
            case AbilityEnum.Harmony:
                return new Ability("Harmony", Ability.AbilityTypes.GroupNumberHeal, "Heal allies for 25 HP", 2, 25, false, false);
            case AbilityEnum.HearingDamage:
                return new Ability("Hearing Damage", Ability.AbilityTypes.NumberDamage, "30 damage", 3, 30, false, false);
            
            default:
                return null;
        }
    }


}
