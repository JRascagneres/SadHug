using UnityEngine;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

// ASSESSMENT 3 UNIT TESTS

/// <summary>
/// Tests to ensure Loading and Saving functions can correctly restore player data.
/// </summary>
[TestFixture]
public class SavingLoadingTest
{

    [SetUp]
    public void Init()
    {
        PlayerData.instance = new PlayerData();
        PlayerData.instance.data = new DataManager();
    }

    [Test]
    public void SaveLoadPlayer()
    {
        Player testPlayer = new Player("George", 1, 100, 5, 5, 5, 5, 5, 5, 0, new Hammer(),
            new MagicAttack("hi-jump kicked", "Kick with power 15", 3, 15),
            new RaiseDefence("buffed up against", "Increase your defence by 10%", 2, 0.1f),
            (Texture2D)Resources.Load("Character1", typeof(Texture2D)));

        SaveData.PlayerSaveData savedPlayer = PlayerData.instance.data.PlayerToSerializable(testPlayer);
        Player restoredPlayer = PlayerData.instance.data.SerializableToPLayer(savedPlayer);
        Assert.AreEqual(restoredPlayer.Name, testPlayer.Name);
        Assert.AreEqual(restoredPlayer.Level, testPlayer.Level);
        Assert.AreEqual(restoredPlayer.Health, testPlayer.Health);
        Assert.AreEqual(restoredPlayer.Attack, testPlayer.Attack);
        Assert.AreEqual(restoredPlayer.Defence, testPlayer.Defence);
        Assert.AreEqual(restoredPlayer.MaximumMagic, testPlayer.MaximumMagic);
        Assert.AreEqual(restoredPlayer.Magic, testPlayer.Magic);
        Assert.AreEqual(restoredPlayer.Luck, testPlayer.Luck);
        Assert.AreEqual(restoredPlayer.Speed, testPlayer.Speed);
        Assert.AreEqual(restoredPlayer.Exp, testPlayer.Exp);

        // Other non-primitive data types are tested below.
    }

    [Test]
    public void SaveLoadItem()
    {
        Item testItem = new Hammer();

        SaveData.ItemSaveData savedItem = PlayerData.instance.data.ItemToSerializable(testItem);
        Item restoredItem = PlayerData.instance.data.SerializableToItem(savedItem);

        Assert.IsInstanceOf<Hammer>(restoredItem);
        Assert.AreEqual(testItem.Name, restoredItem.Name);
        Assert.AreEqual(testItem.Desc, restoredItem.Desc);
    }

    [Test]
    public void SpecialMoveSaveLoad()
    {
        SpecialMove testMove = new MagicAttack("testtext", "testdesc", 1, 1.2f);

        SaveData.SpecialMoveSaveData savedItem = PlayerData.instance.data.SpecialMoveToSerializable(testMove);
        SpecialMove restoredMove = PlayerData.instance.data.SerializableToSpecialMove(savedItem);

        Assert.IsInstanceOf<MagicAttack>(restoredMove);
        Assert.AreEqual(testMove.Desc, restoredMove.Desc);
        Assert.AreEqual(testMove.Text, restoredMove.Text);
        Assert.AreEqual(testMove.Magic, restoredMove.Magic);
        Assert.AreEqual(testMove.Special, restoredMove.Special);
    }

    [Test]
    public void ObjectsActiveSaveLoad()
    {
        IDictionary<string, bool> testDict = new Dictionary<string, bool>();

        SaveData.ObjectsActiveData savedDict = PlayerData.instance.data.ObjectsActiveToSerializable(testDict);
        IDictionary<string, bool> restoredDict = PlayerData.instance.data.SerializableToObjectsActive(savedDict);

        Assert.AreEqual(testDict, restoredDict);
    }

    [Test]
    public void TextureSaveLoad()
    {
        Texture2D testTexture = (Texture2D)Resources.Load("Character1", typeof(Texture2D));

        SaveData.TextureData savedTexture = PlayerData.instance.data.Texture2DToSerializable(testTexture);
        Texture2D restoredTexture = PlayerData.instance.data.SerializableToTexture2D(savedTexture);

        // Because of Unity subleties, equality of images done by first encoding to PNG.
        Assert.AreEqual(testTexture.EncodeToPNG(), restoredTexture.EncodeToPNG());
    }

    [Test]
    public void VectorSaveLoad()
    {
        Vector2 testVector = new Vector2(5, 5);

        SaveData.VectorData savedVector = PlayerData.instance.data.VectorToSerializable(testVector);
        Vector2 restoredVector = PlayerData.instance.data.SerializableToVector(savedVector);

        Assert.AreEqual(testVector, restoredVector);
    }

}
