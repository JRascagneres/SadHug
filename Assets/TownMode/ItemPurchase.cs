using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-- This whole class was added for Assessment 3

/// <summary>
/// Script to handle item purchases for town mode
/// </summary>
public class ItemPurchase : MonoBehaviour {

    /// <summary>
	/// Enum storing different items so they can be chosen from the editor
	/// </summary>
    public enum Items{Hammer, Trainers, RabbitFoot, MagicAmulet, Shield, Armour};

    public Items item;
    private Canvas thisCanvas;
    private Button buyButton;
    private Text buyButtonText;
    private Button sellButton;
    private Text sellButtonText;
    private Text itemName;
    private Item thisItem;

    /// <summary>
    /// Start method sets references to all GameObjects required
    /// </summary>
    void Start () {
        thisCanvas = gameObject.GetComponent<Canvas>();
        buyButton = thisCanvas.transform.GetChild(0).GetComponent<Button>();
        buyButtonText = thisCanvas.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        sellButton = thisCanvas.transform.GetChild(1).GetComponent<Button>();
        sellButtonText = thisCanvas.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        itemName = thisCanvas.transform.GetChild(2).GetComponent<Text>();

        switch (item)
        {
            case Items.Hammer:
                thisItem = new Hammer();
                break;
            case Items.Trainers:
                thisItem = new Trainers();
                break;
            case Items.RabbitFoot:
                thisItem = new RabbitFoot();
                break;
            case Items.MagicAmulet:
                thisItem = new MagicAmulet();
                break;
            case Items.Shield:
                thisItem = new Shield();
                break;
            case Items.Armour:
                thisItem = new Armour();
                break;
        }

        itemName.text = thisItem.Name;
        buyButton.onClick.AddListener(delegate { buyItem(thisItem); });
        sellButton.onClick.AddListener(delegate { sellItem(thisItem); });

        buyButtonText.text = "$" + thisItem.Cost;
        sellButtonText.text = "$" + (thisItem.Cost - 2);

        checkItems();
    }

    /// <summary>
    /// Deducts money from player and gives them the item
    /// </summary>
    /// <param name="item">The item being bought</param>
    void buyItem(Item item)
    {
        PlayerData.instance.data.Money -= item.Cost;
        PlayerData.instance.data.addItem(item);
    }

    /// <summary>
    /// Credits money to the player and removes the item
    /// </summary>
    /// <param name="item">The item being sold</param>
    void sellItem(Item item)
    {
        PlayerData.instance.data.Money += (item.Cost - 2);
        PlayerData.instance.data.removeItem(item);
    }

    /// <summary>
    /// Runs the checkItems function every frame <see cref="checkItems"/>
    /// </summary>
    void Update () {
        checkItems();
	}

    /// <summary>
    /// Updates the buy&sell buttons and the item name in town mode
    /// </summary>
    void checkItems()
    {

        buyButton.interactable = true;
        sellButton.interactable = true;

        int numberOfItems = 0;

        for (int i = 0; i < PlayerData.instance.data.Items.Length; i++)
        {
            if (PlayerData.instance.data.Items[i] != null)
            {
                numberOfItems++;
            }
        }

        if (thisItem.Cost > PlayerData.instance.data.Money || numberOfItems == PlayerData.instance.data.Items.Length)
        {
            buyButton.interactable = false;
        }

        bool hasItem = false;
        for (int i = 0; i < PlayerData.instance.data.Items.Length; i++)
        {
            if (PlayerData.instance.data.Items[i] != null)
            {
                if (PlayerData.instance.data.Items[i].GetType() == thisItem.GetType())
                {
                    hasItem = true;
                }
            }
        }

        if (!hasItem)
        {
            sellButton.interactable = false;
        }
    }
}
