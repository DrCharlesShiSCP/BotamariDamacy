using UnityEngine;
using TMPro;

public class AttachToRidgidBody : MonoBehaviour
{
    public LayerMask ballLayer;
    public int playerLayer;
    public string tagToAdd;
    public float katamariSize = 7f; // Current size of the Katamari
    public TextMeshProUGUI sizeText; // Reference to the TMPro text displaying Katamari size

    public UIChanger uiChanger; // Reference to the UIChanger script
    public PickUpDisplay pickUpDisplay; // Reference to the PickUpDisplay script

    private void Start()
    {
        if (uiChanger == null)
        {
            uiChanger = FindAnyObjectByType<UIChanger>();
        }

        if (pickUpDisplay == null)
        {
            pickUpDisplay = FindAnyObjectByType<PickUpDisplay>();
        }
        UpdateSizeText();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag(tagToAdd))
        {
            ObjectSize objectSizeComponent = other.transform.GetComponent<ObjectSize>();
            if (objectSizeComponent != null)
            {
                float objectSize = objectSizeComponent.sizeValue;
                int objectIdentifier = objectSizeComponent.identifier;

                if (objectSize > katamariSize * 3 / 4)
                {
                    Debug.Log("Object is too large to attach.");
                    uiChanger.ShowAndSpinElement2();
                    return;
                }

                if (objectSize < katamariSize)
                {
                    uiChanger.ShowAndAnimateElement1();
                }

                other.transform.SetParent(transform);
                other.gameObject.layer = playerLayer;
                katamariSize += objectSize;
                UpdateSizeText();
                if (objectSize < katamariSize / 3)
                {
                    Collider objectCollider = other.transform.GetComponent<Collider>();
                    if (objectCollider != null)
                    {
                        objectCollider.enabled = false;
                    }
                }

                RaycastHit hit;
                if (Physics.Raycast(other.transform.position, (transform.position - other.transform.position).normalized, out hit, Mathf.Infinity, ballLayer))
                {
                    other.transform.forward = hit.normal;
                    other.transform.position = hit.point;
                    other.transform.position += other.transform.forward * other.transform.localScale.z * 0.5f;
                }

                // Display the most recent attached object in the UI
                pickUpDisplay.DisplayPickedUpItem(objectIdentifier);
            }
        }
    }

    private void UpdateSizeText()
    {
        Debug.Log("Updating Katamari size text.");
        if (sizeText != null)
        {
            sizeText.text = "Size: " + katamariSize.ToString("F2") + "CM";
        }
    }
}
