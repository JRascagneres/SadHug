using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ALL ASSESMENT 3 ADDITIONS

/// <summary>
/// To be attatched to the Dialogue component of characters if they are to sell items
/// </summary>
public class Vendor : MonoBehaviour
{

    /// <summary>How many items you want the vendor to have </summary>
    public int numberOfItems = 6;
    /// <summary>How many items you want per row of the interface </summary>
    public int numberOfItemsPerRow = 3;
    //cell width and height are both recalculated on start 
    private float cellWidth = Screen.width / 4;
    private float cellHeight = Screen.height / 3;
    /// <summary>the images you want to display with the items (order matters) </summary>
    public Texture[] tex;
    /// <summary>the cost you want to display with the items (order matters) </summary>
    public int[] costs;
    /// <summary>the items you want to display (order matters) </summary>
    public GlobalFunctions.ItemTypes[] items;
    /// <summary>if the shop should be drawing or not </summary>
    private bool draw = false;

    private void Start()
    {
        //resize the cells to fit in screen
        cellHeight = Screen.height / (numberOfItems / numberOfItemsPerRow + 1);
        cellWidth = Screen.width / (numberOfItemsPerRow + 1);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //check which cell clicked on, on mouse press LEFT and perform the action if money allows 
        if (Input.GetMouseButtonDown(0))
        {


            for (int i = 0; i < numberOfItems; i++)
            {
                Rect bounds = new Rect(i % numberOfItemsPerRow * (cellWidth + 5), Mathf.Round(i / numberOfItemsPerRow) * (cellHeight + 5), cellWidth, cellHeight);

                if (bounds.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
                {
                    if (costs[i] <= PlayerData.instance.data.Money)
                    {
                        PlayerData.instance.data.Money -= costs[i];
                        sellItem(items[i]);
                    }
                }
            }
        }
        // on RIGHT mouse button leave the shop
        if (Input.GetMouseButtonDown(1))
        {
            setDraw(false);
        }

    }

    void OnGUI()
    {
        // if can draw, draw out the items for the shop with names and costs 
        if (draw)
        {

            for (int i = 0; i < numberOfItems; i++)
            {
                Rect bounds = new Rect(i % numberOfItemsPerRow * (cellWidth + 5), Mathf.Round(i / numberOfItemsPerRow) * (cellHeight + 5), cellWidth, cellHeight);

                GUI.DrawTexture(bounds, tex[i]);
                GUI.Label(bounds, items[i].ToString() + " costs: " + costs[i]);
            }

            Rect extra = new Rect(numberOfItemsPerRow * (cellWidth + 5), 1 * (cellHeight + 5), cellWidth, cellHeight);
            GUI.Label(extra, "You have: " + PlayerData.instance.data.Money + " Gold");




        }
    }

    /// <summary>
    /// Sets draw to the value given
    /// </summary>
    /// <param name="val">the value to be given to draw</param>
    public void setDraw(bool val)
    {
        draw = val;
    }
    /// <summary>
    /// Adds the item to the players inventry
    /// </summary>
    /// <param name="item">the item to be added to the players inventry</param>
    private void sellItem(GlobalFunctions.ItemTypes item)
    {
        DataManager data = PlayerData.instance.data;
        data.addItem(GlobalFunctions.instance.createItem(item));
    }
}
