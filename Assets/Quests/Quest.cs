using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType { money, level, playerLevel};

public class Quest {
    private string name;
    private QuestType questType;
    private bool complete;
    private int value;
    private string otherData;

    public Quest( QuestType questType, string name, int value)
    {
        this.questType = questType;
        this.complete = false;
        this.name = name;
        this.value = value;
    }

    public Quest (QuestType questType, string name, int value, string otherData)
    {
        this.questType = questType;
        this.complete = false;
        this.name = name;
        this.value = value;
        this.otherData = otherData;
    }

    public bool Complete
    {
        get
        {
            return this.complete;
        }
        set
        {
            this.complete = value;
        }
    }

    public QuestType QuestType
    {
        get
        {
            return this.questType;
        }
        set
        {
            this.questType = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public int Value
    {
        get
        {
            return this.value;
        }
        set
        {
            this.value = value;
        }
    }

    public string OtherData
    {
        get
        {
            return this.otherData;
        }
        set
        {
            this.otherData = value;
        }
    }

}
