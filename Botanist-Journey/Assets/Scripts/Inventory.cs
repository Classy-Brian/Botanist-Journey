using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

using static Item;

public class Inventory: MonoBehaviour
{
    public int inventorySize = 10; // Number of slots in the inventory
    public List<Item> items; // Array to store the items

    void Start()
    {
        items = new List<Item>(inventorySize); // Initialize the array with the given size
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }
}
