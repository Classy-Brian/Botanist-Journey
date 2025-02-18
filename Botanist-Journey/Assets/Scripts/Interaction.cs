using UnityEngine;

using static Inventory;

public class Interaction: MonoBehaviour
{
    public GameObject player;
    public Item requiredTool; 
    public GameObject itemPickupPrefab; 
    private bool playerInRange = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered interaction range.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left the interaction range.");
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Inventory playerInventory = player.GetComponent<Inventory>();

            // Check if the player has the required tool
            bool hasTool = false;
            foreach (Item item in playerInventory.items)
            {
                if (item!= null && item.toolType == requiredTool.toolType)
                {
                    hasTool = true;
                    Debug.Log("Player has the required tool");
                    break;
                }
            }

            if (hasTool)
            {
                Debug.Log("Player can harvest");
                HarvestItem();
            }
            else
            {
                Debug.Log("Player can't harvest");
                // Display a message indicating the required tool
            }
        }
    }

    void HarvestItem()
    {
        // Instantiate the item pickup:
        Instantiate(itemPickupPrefab, transform.position, Quaternion.identity);

        // Get the Item from the ItemHolder
        Item itemToAdd = itemPickupPrefab.GetComponent<ItemHolder>().item;

        // Add the item to the player's inventory:
        player.GetComponent<Inventory>().AddItem(itemToAdd);

        // Destroy or deactivate the object in the scene.
        Destroy(gameObject); // Or gameObject.SetActive(false);
    }
}