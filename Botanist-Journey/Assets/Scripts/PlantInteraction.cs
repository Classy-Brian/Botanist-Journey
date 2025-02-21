using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

using static Inventory;

public class PlantInteraction : MonoBehaviour
{
    public GameObject player; 
    public Item requiredTool = new Item { toolType = ToolType.None };
    public GameObject itemPrefab;
    private bool playerInRange = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }      
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Inventory playerIventory = player.GetComponent<Inventory>();

            bool hasTool = false;
            foreach (Item item in playerIventory.items)
            {
                if (item!= null && item.toolType == ToolType.Blade)
                {
                    hasTool = true;
                    break;
                }
            }

            if (hasTool)
            {
                HarvestVine();
            }
            else
            {
                // Display a message
            }
        }
    }

    void HarvestVine()
    {
        // Instantiate the vine item
        Instantiate(itemPrefab, transform.position, Quaternion.identity);

        // Add the item to player's inventory
        player.GetComponent<Inventory>().AddItem(itemPrefab.GetComponent<Item>());

        // Destroy plant object
        Destroy(gameObject);
    }

}

