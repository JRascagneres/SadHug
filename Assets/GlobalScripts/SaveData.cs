using System;
using System.Collections.Generic;

// NEW CLASS FOR ASSESSMENT 3

/// <summary>
/// Fully serializable class with variables for the data required to save and restore game states. Contains nested classes for each non-primitive type that needs to be serialized.
/// </summary>
[Serializable]
public class SaveData
{
    public int Money;
    public VectorData playerPosition;
    public PlayerSaveData[] serializedPlayers = new PlayerSaveData[PlayerData.instance.data.Players.Length];
    public ItemSaveData[] serializedItems = new ItemSaveData[PlayerData.instance.data.Items.Length];
    public ObjectsActiveData serializedObjectsActive = new ObjectsActiveData();
    public string currentSceneName;
    public int currentLevel;

    /// <summary>
    /// A serialzable class to represent 2D vector information.
    /// </summary>
    [Serializable]
    public class VectorData
    {
        public float xcoord;
        public float ycoord;
    }

    /// <summary>
    /// A serializable class to represent string,bool dictonaries.
    /// </summary>
    [Serializable]
    public class ObjectsActiveData
    {
        public List<string> keys = new List<string>();
        public List<bool> values = new List<bool>();
    }

    /// <summary>
    /// A serializable class for holding textures.
    /// </summary>
    [Serializable]
    public class TextureData
    {
        public byte[] rawTextureData;
        public int width;
        public int height;
    }

    /// <summary>
    /// A serialzable class to represent a <see cref="Player"/>.
    /// </summary>
    [Serializable]
    public class PlayerSaveData
    {
        public string name;
        public int level;
        public int health;
        public int attack;
        public int defence;
        public int maximumMagic;
        public int magic;
        public int luck;
        public int speed;
        public SpecialMoveSaveData special1;
        public SpecialMoveSaveData special2;
        public TextureData image;
        public int exp;
        public ItemSaveData item;
    }

    /// <summary>
    /// A serializable class to represent an <see cref="Item"/>.
    /// </summary>
    [Serializable]
    public class ItemSaveData
    {
        public string typeOfItem;
        public string name;
        public string desc;
    }

    /// <summary>
    /// A serializable class to represent a <see cref="SpecialMove"/>.
    /// </summary>
    [Serializable]
    public class SpecialMoveSaveData
    {
        // record the type of the move for loading purposes
        public string typeOfSpecialMove;
        public string text;
        public string desc;
        public int magic;
        public float special;
    }
}