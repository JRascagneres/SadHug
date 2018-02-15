using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A monobehaviour object to house an instance of <see cref="DataManager"/> so it can be called by other objects
/// </summary>
public class PlayerData : MonoBehaviour {

	public DataManager data;
	public static PlayerData instance = null;

	/// <summary>
	/// Creates <see cref="DataManager"/> object and adds initial player 
	/// </summary>
	void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

}

/// <summary>
/// An object to store all player data including players, items and money and provide useful functions
/// </summary>
public class DataManager {

	private Player[] players;
	private Item[] items;
	private int money;

    /// <summary>
    /// Normal constructor, for use when a new game is started, an initial player is needed.
    /// </summary>
    /// <param name="initialPlayer">First player in the party.</param>
	public DataManager(Player initialPlayer) {
		players = new Player[6];
		players [0] = initialPlayer;
		items = new Item[6];
		money = 0;
	}



    /// <summary>
    /// Constructor for loading, no player need be defined as it will be loaded from the save file.
    /// </summary>
    public DataManager()     // NEW FOR ASSESSMENT 3
    {
        players = new Player[6];
        items = new Item[6];
        money = 0;
    }

    public Player[] Players {
		get {
			return this.players;
		}
		set {
			players = value;
		}
	}

	public Item[] Items {
		get {
			return this.items;
		}
	}

	public int Money {
		get {
			return this.money;
		}
		set {
			money = value;
		}
	}

	/// <summary>
	/// Gets the first player.
	/// </summary>
	/// <returns>The first player in the array, <see cref="players"/>[0] </returns>
	public Player getFirstPlayer() {
		return players [0];
	}

	/// <summary>
	/// Returns the number of players in <see cref="players"/> that are not null and have health above zero 
	/// </summary>
	/// <returns>The number of players alive</returns>
	public int playersAlive() {
		int alive = 0;
		foreach (Player player in players) {
			if (player != null) {
				if (player.Health > 0) {
					alive += 1;
				}
			}
		}
		return alive; 
	}

	/// <summary>
	/// Adds a new player to <see cref="players"/> if not-full, otherwise throwing an <c> InvalidOperationException</c>
	/// </summary>
	/// <param name="player">The player to add to the array</param>
	public void addPlayer(Player player) {
		bool added = false;
		for (int i = 0; i < players.Length; i++) {
			if (players[i] == null) {
				players[i] = player;
				added = true;
				break;
			}
		}
		if (!added) {
			throw new System.InvalidOperationException("Player Array is full");
		}
	}

	/// <summary>Swap two player's positions in <see cref="players"/></summary>
	/// <param name="index1">The index of one player to swap</param>
	/// <param name="index2">The index of the other player to swap</param>
	public void swapPlayers(int index1, int index2) {
		Player temp = players [index1];
		players [index1] = players [index2];
		players [index2] = temp;
	}

	/// <summary>
	/// Add an item to <see cref="items"/> 
	/// </summary>
	/// <param name="item">The item to add</param>
	public void addItem(Item item) {
		for (int i = 0; i < items.Length; i++) {
			if (items [i] == null) {
				items [i] = item;
				break;
			}
		}
	}

	/// <summary>
	/// Counts all items in <see cref="items"/> which are not null
	/// </summary>
	/// <returns>The number of non-null elements in the array</returns>
	public int countItems() {
		int count = 0;
		for (int i = 0; i < items.Length; i++) {
			if (items [i] != null) {
				count += 1;
			}
		}
		return count;
	}

    // ALL METHODS BELOW ARE NEW FOR ASSESSMENT 3

    /// <summary>
    /// Saves data necessary to restore game state to a <see cref="SaveData"/> instance and exports this to a file with a binary formatter.  
    /// </summary>
    public void Save()
    {
        SaveData savedData = new SaveData();

        // Save money.
        savedData.Money = Money;

        // Save players.
        for (var i = 0; i < players.Length; i++)
        {
            savedData.serializedPlayers[i] = PlayerToSerializable(players[i]);
        }

        // Save inventory items.
        for (var i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                savedData.serializedItems[i] = ItemToSerializable(items[i]);
            }

        }

        // Save player position.
        if (GameObject.Find("Player") != null)
        {
            savedData.playerPosition = VectorToSerializable(GameObject.Find("Player").transform.position);
        }

        savedData.currentSceneName = SceneManager.GetActiveScene().name;


        // Save bjects active from GlobalFunctions.
        savedData.serializedObjectsActive = ObjectsActiveToSerializable(GlobalFunctions.instance.objectsActive);

        // Save current level.
        savedData.currentLevel = GlobalFunctions.instance.currentLevel;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.dat");
        bf.Serialize(file, savedData);
        Debug.Log(Players[0]);
        Debug.Log("success!");

    }

    /// <summary>
    /// Loads data to restore game state, using a serialized binary formatted instance of <see cref="SaveData"/> stored in user's AppData. 
    /// </summary>
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGame.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.dat", FileMode.Open);
            SaveData savedGame = (SaveData)bf.Deserialize(file);
            file.Close();

            // Money.
            money = savedGame.Money;

            // Restore players.
            for (var i = 0; i < players.Length; i++)
            {
                players[i] = SerializableToPLayer(savedGame.serializedPlayers[i]);
            }

            // Restore items.
            for (var i = 0; i < items.Length; i++)
            {
                items[i] = SerializableToItem(savedGame.serializedItems[i]);
            }

            // Restore objects active.
            GlobalFunctions.instance.objectsActive = SerializableToObjectsActive(savedGame.serializedObjectsActive);

            // Restore current level.
            GlobalFunctions.instance.currentLevel = savedGame.currentLevel;

            // Restore player position.
            SceneChanger.instance.loadLevel(savedGame.currentSceneName, SerializableToVector(savedGame.playerPosition));


        }
    }

    /// <summary>
    /// Takes a <see cref="Player"/> and converts it to a <see cref="SaveData.PlayerSaveData"/> format for serialization.
    /// </summary>
    /// <param name="player">A player instance to serialize.</param>
    /// <returns> Serializable player, or null if player is null. </returns>
    public SaveData.PlayerSaveData PlayerToSerializable(Player player)
    {
        if (player != null)
        {
            SaveData.PlayerSaveData playerToSave = new SaveData.PlayerSaveData();

            // Assign attributes of player to those of player to be serialized.
            playerToSave.name = player.Name;
            playerToSave.level = player.Level;
            playerToSave.health = player.Health;
            playerToSave.attack = player.Attack;
            playerToSave.defence = player.Defence;
            playerToSave.maximumMagic = player.MaximumMagic;
            playerToSave.magic = player.Magic;
            playerToSave.luck = player.Luck;
            playerToSave.speed = player.Speed;
            playerToSave.special1 = SpecialMoveToSerializable(player.Special1);
            playerToSave.special2 = SpecialMoveToSerializable(player.Special2);
            playerToSave.image = Texture2DToSerializable(player.Image);
            playerToSave.exp = player.Exp;

            if (player.Item != null)
            {
                playerToSave.item = ItemToSerializable(player.Item);
            }

            return playerToSave;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    ///  Takes a <see cref="SaveData.PlayerSaveData"/> and converts it to an actual <see cref="Player"/> for use in game.
    /// </summary>
    /// <param name="serializedPlayer"> The serializable <see cref="SaveData.PlayerSaveData"/> player. </param>
    /// <returns> A real Player instance, or null if passed null.</returns>
    public Player SerializableToPLayer(SaveData.PlayerSaveData serializedPlayer)
    {
        if (serializedPlayer != null)
        {
            Player playerToLoad = new Player(serializedPlayer.name,
                serializedPlayer.level,
                serializedPlayer.health,
                serializedPlayer.attack,
                serializedPlayer.defence,
                serializedPlayer.maximumMagic,
                serializedPlayer.magic,
                serializedPlayer.luck,
                serializedPlayer.speed,
                serializedPlayer.exp,
                SerializableToItem(serializedPlayer.item),
                SerializableToSpecialMove(serializedPlayer.special1),
                SerializableToSpecialMove(serializedPlayer.special2),
                SerializableToTexture2D(serializedPlayer.image));

            return playerToLoad;
        }
        return null;
    }

    /// <summary>
    /// Takes a <see cref="Item"/> and converts it to a <see cref="SaveData.ItemSaveData"/> format for serialization.
    /// </summary>
    /// <param name="item"> <see cref="Item"/> instance to serialize.</param>
    /// <returns> Serializable <see cref="SaveData.ItemSaveData"/> for saving.</returns>
    public SaveData.ItemSaveData ItemToSerializable(Item item)
    {
        if (item != null)
        {
            SaveData.ItemSaveData itemToSave = new SaveData.ItemSaveData
            {
                typeOfItem = item.GetType().FullName,
                name = item.Name,
                desc = item.Desc
            };

            return itemToSave;
        }
        return null;
    }
    /// <summary>
    /// Takes a <see cref="SaveData.ItemSaveData"/> and converts it to an <see cref="Item"/> for use in game.
    /// </summary>
    /// <param name="serializedItem">The serilaizable <see cref="SaveData.ItemSaveData"/> item. </param>
    /// <returns> Real <see cref="Item"/> instance, or null if passed null. </returns>
    public Item SerializableToItem(SaveData.ItemSaveData serializedItem)
    {
        if (serializedItem != null)
        {
            Type type = Type.GetType(serializedItem.typeOfItem);
            Item itemToLoad = (Item)Activator.CreateInstance(type);
            itemToLoad.Desc = serializedItem.desc;
            itemToLoad.Name = serializedItem.name;

            Debug.Log(itemToLoad.GetType().ToString());
            Debug.Log(itemToLoad.Desc);
            Debug.Log(itemToLoad.Name);

            return itemToLoad;
        }
        return null;
    }

    /// <summary>
    /// Takes a <see cref="SpecialMove"/> and converts it to a <see cref="SaveData.SpecialMoveSaveData"/> format for serialization.
    /// </summary>
    /// <param name="move"> <see cref="SpecialMove"/> insatnce to serialize. </param>
    /// <returns> Serializable <see cref="SaveData.SpecialMoveSaveData"/> for saving.</returns>
    public SaveData.SpecialMoveSaveData SpecialMoveToSerializable(SpecialMove move)
    {
        SaveData.SpecialMoveSaveData moveToSave = new SaveData.SpecialMoveSaveData
        {
            typeOfSpecialMove = move.GetType().ToString(),
            text = move.Text,
            desc = move.Desc,
            magic = move.Magic,
            special = move.Special
        };

        return moveToSave;
    }

    /// <summary>
    /// Takes a <see cref="SaveData.SpecialMoveSaveData"/> and converts it to a <see cref="SpecialMove"/> for use in game.
    /// </summary>
    /// <param name="serializedMove"> The serializable <see cref="SaveData.SpecialMoveSaveData"/> move. </param>
    /// <returns> <see cref="SpecialMove"/> instance for use in game.</returns>
    public SpecialMove SerializableToSpecialMove(SaveData.SpecialMoveSaveData serializedMove)
    {
        Type type = Type.GetType(serializedMove.typeOfSpecialMove);
        SpecialMove moveToLoad = (SpecialMove)Activator.CreateInstance(type, serializedMove.text, serializedMove.desc, serializedMove.magic, serializedMove.special);
        return moveToLoad;
    }

    /// <summary>
    /// Takes a dictionary of string and bool and converts it to a <see cref="SaveData.ObjectsActiveData"/> format for serialization.
    /// </summary>
    /// <param name="dictionary"> The dictionary to convert. </param>
    /// <returns> Serializable <see cref="SaveData.ObjectsActiveData"/> for saving. </returns>
    public SaveData.ObjectsActiveData ObjectsActiveToSerializable(IDictionary<string, bool> dictionary)
    {
        SaveData.ObjectsActiveData dictionaryToSave = new SaveData.ObjectsActiveData();

        foreach (KeyValuePair<string, bool> pair in dictionary)
        {
            Debug.Log(pair);
            dictionaryToSave.keys.Add(pair.Key);
            dictionaryToSave.values.Add(pair.Value);
        }

        return dictionaryToSave;
    }

    /// <summary>
    /// Takes a dictionary of string and bool and converts it to a <see cref="SaveData.ObjectsActiveData"/> format for serialization.
    /// </summary>
    /// <param name="serializedObjectsActive"> The serializable <see cref="SaveData.ObjectsActiveData"/>.</param>
    /// <returns> A dictionary that can be used for ObjectsActive in <see cref="GlobalFunctions"/></returns>
    public IDictionary<string, bool> SerializableToObjectsActive(SaveData.ObjectsActiveData serializedObjectsActive)
    {
        IDictionary<string, bool> dictionaryToLoad = new Dictionary<string, bool>();

        for (var i = 0; i < serializedObjectsActive.keys.Count; i++)
        {
            dictionaryToLoad.Add(serializedObjectsActive.keys[i], serializedObjectsActive.values[i]);
        }

        return dictionaryToLoad;
    }

    /// <summary>
    /// Encodes a Unity Texture2D to a PNG format and stores it to a <see cref="SaveData.TextureData"/> for saving.  
    /// Ensure the image has Read/Write Enabled and is not compressed in the Unity Editor for this to work.
    /// </summary>
    /// <param name="playerTexture2D"> The Texture2D to convert. </param>
    /// <returns> Serializable <see cref="SaveData.TextureData"/> for saving. </returns>
    public SaveData.TextureData Texture2DToSerializable(Texture2D playerTexture2D)
    {
        SaveData.TextureData texturetoSave = new SaveData.TextureData();
        texturetoSave.rawTextureData = playerTexture2D.EncodeToPNG();
        texturetoSave.width = playerTexture2D.width;
        texturetoSave.height = playerTexture2D.height;

        return texturetoSave;
    }

    /// <summary>
    /// Takes a <see cref="SaveData.TextureData"/> and converts it to a  Unity Texure2D for use in game. 
    /// </summary>
    /// <param name="serializedPlayerTexture2D"> <see cref="SaveData.TextureData"/> to convert. </param>
    /// <returns> A Unity Texture2D. </returns>
    public Texture2D SerializableToTexture2D(SaveData.TextureData serializedPlayerTexture2D)
    {
        Texture2D textureToLoad = new Texture2D(serializedPlayerTexture2D.width, serializedPlayerTexture2D.height);
        textureToLoad.LoadImage(serializedPlayerTexture2D.rawTextureData);
        return textureToLoad;
    }

    /// <summary>
    /// Takes a Unity Vector2 and converts it to a <see cref="SaveData.VectorData"/> format for serialization.
    /// </summary>
    /// <param name="vector"> A Unity Vector2.</param>
    /// <returns> <see cref="SaveData.TextureData"/> for serialization.</returns>
    public SaveData.VectorData VectorToSerializable(Vector2 vector)
    {
        SaveData.VectorData vectorToSave = new SaveData.VectorData();
        vectorToSave.xcoord = vector.x;
        vectorToSave.ycoord = vector.y;

        return vectorToSave;
    }
    /// <summary>
    /// Takes a <see cref="SaveData.VectorData"/> and converts it to a  Unity Texure2D for use in game.
    /// </summary>
    /// <param name="serializedVector"></param>
    /// <returns> A Unity Vector2 for use in game.</returns>
    public Vector2 SerializableToVector(SaveData.VectorData serializedVector)
    {
        Vector2 vectorToLoad = new Vector2(serializedVector.xcoord, serializedVector.ycoord);
        return vectorToLoad;
    }
}