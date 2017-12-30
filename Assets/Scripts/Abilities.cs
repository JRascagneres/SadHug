using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Abilities
{
    public enum AbilityEnum {fiveDamage, tenHeal, tenPercentCurrent, tenPercentTotal, groupHealTen, singleStunEnemy, singleStunPlayer, poisenTenEnemy, poisenTenPlayer};

    public Abilities() {
            
    }

    public Ability getAbility(AbilityEnum abEnum){
        switch (abEnum)
        {
            case AbilityEnum.fiveDamage:
                return new Ability("Basic Attack", Ability.abilityTypes.numberDamage, "Does five damage", 0, 5, false, false);
            case AbilityEnum.tenHeal:
                return new Ability("Ten Heal", Ability.abilityTypes.numberHeal, "Heals 10", 3, 10, false, false);
            case AbilityEnum.tenPercentCurrent:
                return new Ability("Ten Percent Current", Ability.abilityTypes.percentCurrentDamage, "Ten Percent Current", 1, 10, false, false);
            case AbilityEnum.tenPercentTotal:
                return new Ability("Ten Percent Total", Ability.abilityTypes.percentTotalDamage, "Ten Percent Total", 1, 10, false, false);
            case AbilityEnum.groupHealTen:
                return new Ability("Group 10 Heal", Ability.abilityTypes.groupNumberHeal, "Group Heal 10", 1, 10, false, false);
            case AbilityEnum.singleStunEnemy:
                return new Ability("Enemy turn stun", Ability.abilityTypes.enemyStun, "Stuns for one turn", 1, 0, true, false);
            case AbilityEnum.singleStunPlayer:
                return new Ability("Player turn stun", Ability.abilityTypes.playerStun, "Stuns for one turn", 1, 0, true, false);
            case AbilityEnum.poisenTenEnemy:
                return new Ability("Poisen 10 Enemy", Ability.abilityTypes.enemyTickingDamage, "Poisens for 10 per turn", 1, 10, false, true);
            case AbilityEnum.poisenTenPlayer:
                return new Ability("Poisen 10 Player", Ability.abilityTypes.playerTickingDamage, "Poisens for 10 per turn", 1, 10, false, true);
            default:
                return null;
        }
    }


}
