using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory: MonoBehaviour
{
    // List to store the collected plants
    public List<Plant> plants = new List<Plant>();

    // Creates a UI Text element in the scene
    public TMPro.TextMeshProUGUI inventoryText;

    // Size of player's inventory
    public int maxInventorySize = 10;

    // Function to display text that user pick up a specific plant
    void UpdateInventoryUI() {
        if (inventoryText != null ) { // Check if the text object is assigned
            string text = "Inventory:\n";
            foreach(Plant p in plants) {
                text += p.displayName + "\n"; // Add the plan'ts name and a new line
            }
            inventoryText.text = text; // Set the text of the UI element
        }
    }

    // Function to add a plant to the inventory
    public void AddItem(Plant plant)
    {
        if (plants.Count < maxInventorySize) { // Checks if the user has space in their inventory
            plants.Add(plant);
            Debug.Log("Added " + plant.displayName + " to inventory");
            UpdateInventoryUI(); // Update the UI after adding
        } else {
            Debug.Log("Inventory is full!");
        }
    }

    public void RemoveItem(Plant plant)
    {
        plants.Remove(plant);
        Debug.Log("Removed: " + plant.displayName + " from inventory.");
        UpdateInventoryUI(); // Update the UI after removing
    }
}