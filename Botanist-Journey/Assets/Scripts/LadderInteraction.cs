using UnityEngine;

public class LadderInteraction: MonoBehaviour
{
    public float climbSpeed = 2f;
    public GameObject player; 

    private bool playerInRange = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player.GetComponent<PlayerMovement>().isOnLadder = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            PlayerMovement playerMovement =  player.GetComponent<PlayerMovement>();
            playerMovement.isOnLadder = false;
            playerMovement.ResetVelocity();
        }
    }

    void Update()
    {
        if (playerInRange)
        {
            CharacterController controller = player.GetComponent<CharacterController>();
            if (Input.GetKey(KeyCode.W))
            {
                // Move player upwards using CharacterController.Move()
                controller.Move(Vector3.up * climbSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                // Move player downwards using CharacterController.Move()
                controller.Move(Vector3.down * climbSpeed * Time.deltaTime);
            }
        }
    }
}