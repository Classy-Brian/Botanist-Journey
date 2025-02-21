using UnityEngine;

public class LadderInteraction: MonoBehaviour
{
    // Speed at which the player climbs the ladder
    public float climbSpeed = 2f;

    // Reference to the player GameObject
    public GameObject player;

    // Flag to track if the player is within the ladder's trigger area
    private bool playerInRange = false;

    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the player
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            // Set the isOnLadder flag in the PlayerMovement script to true
            player.GetComponent<PlayerMovement>().isOnLadder = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider is the player
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            // Get the PlayerMovement component from the player
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            // Set the isOnLadder flag to false
            playerMovement.isOnLadder = false;

            // Reset the player's vertical velocity to prevent sudden drop
            playerMovement.ResetVelocity();
        }
    }

    void Update()
    {
        // Check if the player is within the ladder's range
        if (playerInRange)
        {
            // Get the CharacterController component from the player
            CharacterController controller = player.GetComponent<CharacterController>();

            // Move the player upwards if the "W" key is pressed
            if (Input.GetKey(KeyCode.W))
            {
                controller.Move(Vector3.up * climbSpeed * Time.deltaTime);
            }
            // Move the player downwards if the "S" key is pressed
            else if (Input.GetKey(KeyCode.S))
            {
                controller.Move(Vector3.down * climbSpeed * Time.deltaTime);
            }
        }
    }
}