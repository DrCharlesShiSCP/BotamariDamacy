using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class TutorialKeys : MonoBehaviour
{
    public List<GameObject> list1; // List of GameObjects to deactivate
    public List<GameObject> list2; // List of GameObjects to activate

    private bool[] keyStates = new bool[4]; // Track the activation state for each key

    void Start()
    {
        // Ensure the lists have exactly 5 GameObjects each
        if (list1.Count != 4 || list2.Count != 4)
        {
            Debug.LogError("Both lists must contain exactly 4 GameObjects.");
            return;
        }

        // Initialize all GameObjects in list2 as inactive
        foreach (GameObject obj in list2)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        // Check each key and activate/deactivate corresponding objects
        if (Input.GetKeyDown(KeyCode.W)) ActivateObject(0);
        if (Input.GetKeyDown(KeyCode.A)) ActivateObject(1);
        if (Input.GetKeyDown(KeyCode.S)) ActivateObject(2);
        if (Input.GetKeyDown(KeyCode.D)) ActivateObject(3);

        // Check if all objects in list2 are active, then switch to MainGame scene
        if (AllObjectsActive())
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void ActivateObject(int index)
    {
        if (!keyStates[index])
        {
            list1[index].SetActive(false); // Deactivate the counterpart in list1
            list2[index].SetActive(true);  // Activate the corresponding object in list2
            keyStates[index] = true;       // Mark this key as activated
        }
    }

    bool AllObjectsActive()
    {
        foreach (bool state in keyStates)
        {
            if (!state) return false;
        }
        return true;
    }
}
