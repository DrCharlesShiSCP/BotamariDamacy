using UnityEngine;

public class UIChanger : MonoBehaviour
{
    public GameObject Larger; // Reference to the first UI element
    public GameObject SameSize; // Reference to the second UI element

    public float spinSpeed1 = 50f; // Spin speed for UI element 1
    public float enlargeShrinkSpeed = 1f; // Speed at which the size changes for UI element 1
    public float sizeRange = 0.2f; // Range for enlarging and shrinking (scale amount)

    public float spinSpeed2 = 100f; // Spin speed for UI element 2

    private RectTransform element1Rect;
    private bool isAnimatingElement1 = false;
    private bool isAnimatingElement2 = false;
    private float originalScale;

    void Start()
    {
        Larger.SetActive(false);
        SameSize.SetActive(false);
        if (Larger != null)
        {
            element1Rect = Larger.GetComponent<RectTransform>();
            originalScale = element1Rect.localScale.x;
        }
    }

    void Update()
    {
        if (isAnimatingElement1)
        {
            AnimateElement1();
        }

        if (isAnimatingElement2)
        {
            AnimateElement2();
        }
    }

    public void ShowAndAnimateElement1()
    {
        // Activate UI element 1, deactivate UI element 2
        Larger.SetActive(true);
        SameSize.SetActive(false);

        // Start animating element 1
        isAnimatingElement1 = true;
        isAnimatingElement2 = false;
    }

    public void ShowAndSpinElement2()
    {
        // Activate UI element 2, deactivate UI element 1
        SameSize.SetActive(true);
        Larger.SetActive(false);

        // Start animating element 2
        isAnimatingElement1 = false;
        isAnimatingElement2 = true;
    }

    private void AnimateElement1()
    {
        // Spin element 1
        element1Rect.Rotate(Vector3.forward, spinSpeed1 * Time.deltaTime);

        // Enlarge and shrink element 1
        float scale = originalScale + Mathf.Sin(Time.time * enlargeShrinkSpeed) * sizeRange;
        element1Rect.localScale = new Vector3(scale, scale, 1);
    }

    private void AnimateElement2()
    {
        // Spin element 2 at a different speed
        RectTransform element2Rect = SameSize.GetComponent<RectTransform>();
        element2Rect.Rotate(Vector3.forward, spinSpeed2 * Time.deltaTime);
    }
}
