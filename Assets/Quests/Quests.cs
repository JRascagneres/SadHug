using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enum of different quests
public enum QuestsEnum {Quest10, Level10, GeorgeLevel2};

/// <summary>
/// Defines class of quests and their components
/// </summary>
public class Quests{
    public static Quest GetQuests(QuestsEnum quests)
    {
        switch (quests)
        {
            case QuestsEnum.Quest10:
                return new Quest(QuestType.money, "Money 10", 10);
            case QuestsEnum.Level10:
                return new Quest(QuestType.level, "Level 1", 1);
            case QuestsEnum.GeorgeLevel2:
                return new Quest(QuestType.playerLevel, "George Level 2", 2, "George");
        }

        return null;
    }
}
