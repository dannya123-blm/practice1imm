using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f; // Movement speed
    public float gravity = -9.81f; // Gravity force
    public float jumpHeight = 3.0f; // Jump height

    public Transform leftArm; // Reference to the left arm bone
    public Transform rightArm; // Reference to the right arm bone

    private CharacterController controller; // Reference to the CharacterController component
    private Vector3 velocity; // Store the player's velocity
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        // Get the CharacterController component attached to the player
        controller = GetComponent<CharacterController>();
        // Check if controller is found
        if (controller == null)
        {
            Debug.LogError("CharacterController not found!");
        }

        // Get the Animator component attached to the player
        animator = GetComponent<Animator>();
        // Check if animator is found
        if (animator == null)
        {
            Debug.LogError("Animator not found!");
        }
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

        // Log input values
        Debug.Log("MoveX: " + moveX + ", MoveZ: " + moveZ);

        // Create a Vector3 based on the input and the player's current transform direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply the movement to the CharacterController
        controller.Move(move * speed * Time.deltaTime);

        // Update the Animator parameters based on movement
        animator.SetFloat("Speed", move.magnitude);

        // Arm movement
        float mouseX = Input.GetAxis("Mouse X"); // Horizontal mouse movement
        float mouseY = Input.GetAxis("Mouse Y"); // Vertical mouse movement

        // Rotate arms based on mouse input
        Vector3 leftArmRotation = leftArm.localEulerAngles;
        leftArmRotation.y += mouseX;
        leftArm.localEulerAngles = leftArmRotation;

        Vector3 rightArmRotation = rightArm.localEulerAngles;
        rightArmRotation.y += mouseX;
        rightArm.localEulerAngles = rightArmRotation;

        // Jump logic
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity to the player
        velocity.y += gravity * Time.deltaTime;

        // Apply the gravity movement to the CharacterController
        controller.Move(velocity * Time.deltaTime);

        // Update grounded state in Animator
        animator.SetBool("IsGrounded", controller.isGrounded);

        // Debugging logs
        Debug.Log("Velocity Y: " + velocity.y);
        Debug.Log("IsGrounded: " + controller.isGrounded);
    }
}
