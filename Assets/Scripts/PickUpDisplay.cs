using UnityEngine;
using System.Collections.Generic;

public class PickUpDisplay : MonoBehaviour
{
    public List<GameObject> itemPrefabs; // List of item prefabs, should be assigned in the Inspector
    public Transform previewPosition; // Position where the preview object will be displayed in front of a UI camera
    public float spinSpeed = 50f; // Speed of spinning the displayed object
    public float displayDuration = 3f; // Duration to display the object before removing it

    private GameObject currentDisplayObject; // Currently displayed object instance
    private float displayTimer; // Timer to track display duration

    public void DisplayPickedUpItem(int identifier)
    {
        // Destroy the currently displayed object if it exists
        if (currentDisplayObject != null)
        {
            Destroy(currentDisplayObject);
        }

        // Spawn the new object based on the identifier
        if (identifier >= 0 && identifier < itemPrefabs.Count && itemPrefabs[identifier] != null)
        {
            currentDisplayObject = Instantiate(itemPrefabs[identifier], previewPosition.position, Quaternion.identity);
            currentDisplayObject.transform.SetParent(previewPosition); // Attach to the preview position for easy management
        }

        // Reset the timer
        displayTimer = displayDuration;
    }

    private void Update()
    {
        // Rotate the displayed object if it exists
        if (currentDisplayObject != null)
        {
            currentDisplayObject.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

            // Decrement the timer
            displayTimer -= Time.deltaTime;

            // Destroy the object if the timer has expired
            if (displayTimer <= 0f)
            {
                Destroy(currentDisplayObject);
                currentDisplayObject = null;
            }
        }
    }
}
