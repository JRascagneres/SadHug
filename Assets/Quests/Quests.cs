using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CLASS ADDED FOR ASSESSMENT 4

//Enum of different quests
public enum QuestsEnum { Money10, Money20, Money30, Level1, Level2, Level3, GeorgeLevel2 };

/// <summary>
/// Defines class of quests and their components
/// </summary>
public class Quests{
    public static Quest GetQuests(QuestsEnum quests)
    {
        switch (quests)
        {
            case QuestsEnum.Money10:
                return new Quest(QuestType.money, "Money 10", 10);
            case QuestsEnum.Money20:
                return new Quest(QuestType.money, "Money 20", 20);
            case QuestsEnum.Money30:
                return new Quest(QuestType.money, "Money 30", 30);
            case QuestsEnum.Level1:
                return new Quest(QuestType.level, "Level 1", 1);
            case QuestsEnum.Level2:
                return new Quest(QuestType.level, "Level 2", 2);
            case QuestsEnum.Level3:
                return new Quest(QuestType.level, "Level 3", 3);
            case QuestsEnum.GeorgeLevel2:
                return new Quest(QuestType.playerLevel, "George Level 2", 2, "George");
        }

        return null;
    }
}
