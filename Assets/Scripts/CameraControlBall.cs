using UnityEngine;

public class CameraControlBall : MonoBehaviour
{
    public Transform centerObject; // The object to orbit around (e.g., Katamari)
    public float orbitSpeed = 50f; // Speed of orbit
    public float orbitDistance = 10f; // Fixed distance of the orbit

    private float currentAngle = 0f; // Track the current angle of rotation

    void Update()
    {
        if (centerObject == null)
        {
            Debug.LogError("Center object is not assigned.");
            return;
        }

        // Determine rotation direction based on player input
        if (Input.GetKey(KeyCode.D))
        {
            currentAngle -= orbitSpeed * Time.deltaTime; // Rotate left
        }
        else if (Input.GetKey(KeyCode.A))
        {
            currentAngle += orbitSpeed * Time.deltaTime; // Rotate right
        }

        // Calculate the new position based on the current angle and fixed orbit distance
        float radians = currentAngle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(
            Mathf.Cos(radians) * orbitDistance,
            transform.position.y - centerObject.position.y, // Maintain the camera's height
            Mathf.Sin(radians) * orbitDistance
        );

        // Set the camera's position relative to the center object
        transform.position = centerObject.position + offset;
        transform.LookAt(centerObject); // Ensure the camera faces the center
    }
}
