﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

	public DataManager(Player initialPlayer) {
		players = new Player[6];
		players [0] = initialPlayer;
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

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile.dat");

        StoredData storedData = new StoredData();

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                storedData.players[i] = new StoredData.Player();
                storedData.players[i].name = players[i].Name;
                storedData.players[i].level = players[i].Level;
                storedData.players[i].health = players[i].Health;
                storedData.players[i].attack = players[i].Attack;
                storedData.players[i].defence = players[i].Defence;
                storedData.players[i].maximumMagic = players[i].MaximumMagic;
                storedData.players[i].magic = players[i].Magic;
                storedData.players[i].luck = players[i].Luck;
                storedData.players[i].speed = players[i].Speed;
                storedData.players[i].exp = players[i].Exp;
                if (players[i].Item != null)
                {
                    storedData.players[i].item = new StoredData.Item();
                    storedData.players[i].item.name = players[i].Item.Name;
                    storedData.players[i].item.desc = players[i].Item.Desc;
                }
                storedData.players[i].special1 = getMoveFromPlayer(players[i].Special1);
                storedData.players[i].special2 = getMoveFromPlayer(players[i].Special2);
                //storedData.players[i].Image = players[i].Image;
            }
        }

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                storedData.items[i] = new StoredData.Item();
                storedData.items[i].name = items[i].Name;
                storedData.items[i].desc = items[i].Desc;
            }
        }

        storedData.money = money;

        GameObject playerObject = GameObject.Find("Player");

        storedData.locationData.playerLocationX = playerObject.transform.position.x;
        storedData.locationData.playerLocationY = playerObject.transform.position.y;

        storedData.locationData.sceneName = SceneManager.GetActiveScene().name;

        binaryFormatter.Serialize(file, storedData);
        Debug.Log("Saved");
        file.Close();
    }

    public StoredData.SpecialMove getMoveFromPlayer(SpecialMove specialMove)
    {
        if (specialMove is MagicAttack)
        {
            StoredData.MagicAttack move = new StoredData.MagicAttack();
            move.desc = specialMove.Desc;
            move.magic = specialMove.Magic;
            move.power = ((MagicAttack)specialMove).power;
            move.text = specialMove.Text;
            return move;
        }
        else if (specialMove is LowerDefence)
        {
            StoredData.LowerDefence move = new StoredData.LowerDefence();
            move.desc = specialMove.Desc;
            move.magic = specialMove.Magic;
            move.decrease = ((LowerDefence)specialMove).decrease;
            move.text = specialMove.Text;
            return move;
        }
        else if (specialMove is LowerSpeed)
        {
            StoredData.LowerSpeed move = new StoredData.LowerSpeed();
            move.desc = specialMove.Desc;
            move.magic = specialMove.Magic;
            move.decrease = ((LowerSpeed)specialMove).decrease;
            move.text = specialMove.Text;
            return move;
        }
        else if (specialMove is RaiseAttack)
        {
            StoredData.RaiseAttack move = new StoredData.RaiseAttack();
            move.desc = specialMove.Desc;
            move.magic = specialMove.Magic;
            move.increase = ((RaiseAttack)specialMove).increase;
            move.text = specialMove.Text;
            return move;
        }
        else if (specialMove is RaiseDefence)
        {
            StoredData.RaiseDefence move = new StoredData.RaiseDefence();
            move.desc = specialMove.Desc;
            move.magic = specialMove.Magic;
            move.increase = ((RaiseDefence)specialMove).increase;
            move.text = specialMove.Text;
            return move;
        }
        else if (specialMove is IncreaseMoney)
        {
            StoredData.IncreaseMoney move = new StoredData.IncreaseMoney();
            move.desc = specialMove.Desc;
            move.magic = specialMove.Magic;
            move.increase = ((IncreaseMoney)specialMove).increase;
            move.text = specialMove.Text;
            return move;
        }
        else if (specialMove is HealingSpell)
        {
            StoredData.HealingSpell move = new StoredData.HealingSpell();
            move.desc = specialMove.Desc;
            move.magic = specialMove.Magic;
            move.increase = ((HealingSpell)specialMove).increase;
            move.text = specialMove.Text;
            return move;
        }
        return null;
    }

    public void Load()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/saveFile.dat", FileMode.Open);
        StoredData storedData = (StoredData)binaryFormatter.Deserialize(file);
        Debug.Log(storedData.locationData.sceneName);
        Debug.Log(storedData.locationData.playerLocationX);
        Debug.Log(storedData.locationData.playerLocationY);
        file.Close();

    }

    [Serializable]
    public class StoredData
    {

        public int money;

        [Serializable]
        public class SpecialMove
        {
            public string text;
            public string desc;
            public int magic;
        }

        [Serializable]
        public class MagicAttack : SpecialMove
        {
            public int power;
        }

        [Serializable]
        public class LowerDefence : SpecialMove
        {
            public float decrease;
        }

        [Serializable]
        public class LowerSpeed : SpecialMove
        {
            public float decrease;
        }

        [Serializable]
        public class RaiseAttack : SpecialMove
        {
            public float increase;
        }

        [Serializable]
        public class RaiseDefence : SpecialMove
        {
            public float increase;
        }

        [Serializable]
        public class IncreaseMoney : SpecialMove
        {
            public float increase;
        }

        [Serializable]
        public class HealingSpell : SpecialMove
        {
            public float increase;
        }

        [Serializable]
        public class Item
        {
            public string name;
            public string desc;
        }

        [Serializable]
        public class Player
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
            public int exp;
            public Item item;
            public SpecialMove special1;
            public SpecialMove special2;
            //public Texture2D Image;
        }

        [Serializable]
        public class LocationData
        {
            public string sceneName;
            public float playerLocationX;
            public float playerLocationY;
        }

        public Player[] players = new Player[6];
        public Item[] items = new Item[6];
        public LocationData locationData = new LocationData();

    }

}
