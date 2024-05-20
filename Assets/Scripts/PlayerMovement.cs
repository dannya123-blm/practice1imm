using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f; // Movement speed
    public float gravity = -9.81f; // Gravity force
    public float jumpHeight = 3.0f; // Jump height
    private CharacterController controller; // Reference to the CharacterController component
    private Vector3 velocity; // Store the player's velocity

    void Start()
    {
        // Get the CharacterController component attached to the player
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is grounded
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small negative value to keep the player grounded
        }

        // Get input from the horizontal and vertical axes
        float moveX = Input.GetAxis("Horizontal"); // Left and right movement
        float moveZ = Input.GetAxis("Vertical"); // Forward and backward movement

        // Create a Vector3 based on the input and the player's current transform direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply the movement to the CharacterController
        controller.Move(move * speed * Time.deltaTime);

        // Jump logic (optional)
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity to the player
        velocity.y += gravity * Time.deltaTime;

        // Apply the gravity movement to the CharacterController
        controller.Move(velocity * Time.deltaTime);
    }
}
