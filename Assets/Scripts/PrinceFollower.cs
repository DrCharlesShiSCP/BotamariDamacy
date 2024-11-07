using UnityEngine;

public class PrinceFollower : MonoBehaviour
{
    public Transform katamari; // Reference to the Katamari GameObject
    public float followDistance = 1.5f; // Distance behind the Katamari
    public float followSmoothSpeed = 5f; // Speed of following

    private Rigidbody katamariRb;

    void Start()
    {
        if (katamari != null)
        {
            katamariRb = katamari.GetComponent<Rigidbody>();
            if (katamariRb == null)
            {
                Debug.LogError("Katamari does not have a Rigidbody component.");
            }
        }
    }

    void FixedUpdate()
    {
        if (katamari == null || katamariRb == null)
        {
            Debug.LogError("Katamari reference or Rigidbody component is missing.");
            return;
        }

        // Use Katamari's velocity to determine the movement direction
        Vector3 katamariVelocity = katamariRb.linearVelocity;
        if (katamariVelocity.sqrMagnitude > 0.01f)
        {
            // Calculate the backward direction based on Katamari's movement
            Vector3 backwardDirection = -katamariVelocity.normalized;

            // Calculate the target position for the Prince
            Vector3 targetPosition = katamari.position + backwardDirection * followDistance;
            targetPosition.y = transform.position.y; // Keep the Prince at the same height

            // Smoothly move the Prince to the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSmoothSpeed * Time.deltaTime);

            // Make the Prince face the Katamari's movement direction on the XZ plane
            Vector3 lookAtPosition = new Vector3(katamari.position.x, transform.position.y, katamari.position.z);
            transform.LookAt(lookAtPosition);
        }
    }
}
