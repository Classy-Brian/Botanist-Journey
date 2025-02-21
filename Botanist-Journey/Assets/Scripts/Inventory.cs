using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{
    // List to store the collected plants
    public List<Plant> plants = new List<Plant>();

    // Function to add a plant to the inventory
    public void AddItem(Plant plant)
    {
        // Add the plant to the list
        plants.Add(plant);

        // Print a debug message to the console
        Debug.Log("Added " + plant.name + " to inventory.");
    }
}