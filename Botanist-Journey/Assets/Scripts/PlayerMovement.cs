using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement: MonoBehaviour
{
    public float speed = 5f; 
    public float jumpForce = 10f;
    public float gravity = -9.81f; 
    public bool isOnLadder = false;

    private CharacterController controller;
    public Vector3 velocity; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input from horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector (XZ plane)
        Vector3 move = new Vector3(horizontalInput, 0f, verticalInput);

        if (isOnLadder && !controller.isGrounded)
        {
            // move.x = 0f;
            move.z = 0f;
        }

        // Apply movement
        controller.Move(move * speed * Time.deltaTime);

        if (!isOnLadder)
        {
            // Apply gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            // Jump if spacebar is pressed and the player is grounded
            if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Calculate jump velocity
            }
            
        }
    }

    public void ResetVelocity()
    {
        velocity.y = 0f;
    }
}