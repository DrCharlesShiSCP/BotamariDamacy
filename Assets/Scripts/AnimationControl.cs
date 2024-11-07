using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    private string isRunningParam = "isRunning"; // Parameter name in Animator

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // Check if there's movement input
        bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        // Set the Animator parameter based on movement input
        animator.SetBool(isRunningParam, isMoving);
    }
}
