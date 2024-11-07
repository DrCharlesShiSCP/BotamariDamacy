using UnityEngine;

public class TestingFollow : MonoBehaviour
{
    public Transform target; // Reference to the target GameObject

    void Update()
    {
        if (target != null)
        {
            // Set this object's position to the target's position
            transform.position = target.position;
        }
    }
}
