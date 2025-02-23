using UnityEngine;

public class ToolInteraction: MonoBehaviour
{
    // Reference to the Tool data (Scriptable Object)
    public Tool toolData;

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
            Debug.Log("Player is in range of the tool");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider is the player
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left the Tool's range");
        }
    }

    void Update()
    {
        // Check if the player is in range and the interact button ("E") is pressed
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Tool collected!");

            // Add the plant to the player's inventory
            player.GetComponent<Inventory>().AddItem(toolData);

            // Destroy the plant object
            Destroy(gameObject);
        }
    }
}