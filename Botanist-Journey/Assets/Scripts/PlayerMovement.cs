using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    // Movement speed
    public float speed = 5f;

    // Jump force
    public float jumpForce = 10f;

    // Gravity value
    public float gravity = -9.81f;

    // Flag to check if the player is on a ladder
    public bool isOnLadder = false;

    // Reference to the CharacterController component
    private CharacterController controller;

    // Store the player's vertical velocity
    public Vector3 velocity;

    void Start()
    {
        // Get the CharacterController component
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input from horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector (XZ plane)
        Vector3 move = new Vector3(horizontalInput, 0f, verticalInput);

        // Apply movement
        controller.Move(move * speed * Time.deltaTime);

        // Apply gravity and jump only if not on the ladder
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

    // Function to reset the player's vertical velocity (used when leaving a ladder)
    public void ResetVelocity()
    {
        velocity.y = 0f;
    }
}