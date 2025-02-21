using UnityEngine;

public class PlantInteraction: MonoBehaviour
{
    // Reference to the Plant data (Scriptable Object)
    public Plant plantData;

    // Reference to the player GameObject
    public GameObject player;

    // Flag to track if the player is within interaction range
    private bool playerInRange = false;

    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the player
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player is in range of the plant");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider is the player
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left the plant's range");
        }
    }

    void Update()
    {
        // Check if the player is in range and the interact button ("E") is pressed
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Plant harvested!");

            // Add the plant to the player's inventory
            player.GetComponent<Inventory>().AddItem(plantData);

            // Destroy the plant object
            Destroy(gameObject);
        }
    }
}