using System.Collections.Generic;
using UnityEngine;

using static Item;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Item machete = new Item();
        machete.itemName = "Machete";
        machete.itemDescription = "Cut down vines";
        machete.toolType = ToolType.Blade;

        Item vine = new Item();
        vine.itemName = "Vine";
        vine.itemDescription = "is vine";
        vine.plantType = PlantType.Vine;

        items.Add(machete);
        items.Add(vine);
    }
}
