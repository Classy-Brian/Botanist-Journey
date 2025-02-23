using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{
    // List to store the collected plants
    public List<Plant> plants = new List<Plant>();

    // List to store the collected tools
    public List<Tool> tools = new List<Tool>();

    // Function to add a Plamt to the inventory
    public void AddPlantItem(Plant plant)
    {
        // Add the plant to the list
        plants.Add(plant);

        // Print a debug message to the console
        Debug.Log("Added " + plant.name + " to inventory.");
    }

    // Function to add a Tool to the inventory
    public void AddToolItem(Tool tool)
    {
        // Add the tool to the list
        tools.Add(tool);

        // Print a debug message to the console
        Debug.Log("Added " + tool.name + " to inventory.");
    }
}