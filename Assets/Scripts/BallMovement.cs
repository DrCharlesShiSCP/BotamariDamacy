using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of the ball movement
    public Transform cameraTransform; // Reference to the camera Transform
    private Rigidbody rb; // Reference to the Rigidbody component
    public Animator animator;

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();

        // Ensure cameraTransform is assigned, or find the main camera
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void FixedUpdate()
    {
        // Get input from the keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Check if there is any input
        if (moveHorizontal == 0 && moveVertical == 0)
        {
            // Stop the ball instantly by setting the velocity to zero
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
            // Calculate camera-relative movement direction
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            // Flatten the camera's forward and right vectors to ignore the Y axis
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            // Calculate the movement vector relative to the camera's orientation
            Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

            // Apply a force to the Rigidbody in the direction of the movement vector
            rb.AddForce(movement * moveSpeed);
        }
    }
}
