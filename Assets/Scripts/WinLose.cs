using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public AttachToRidgidBody katamariScript; // Reference to the AttachToRidgidBody script to get katamari size
    public TextMeshProUGUI timerText; // Reference to TMP text for displaying the timer
    public float targetSize = 50f; // Target size to win the game
    public float timeLimit = 60f; // Time limit in seconds
    public CircularTimer circularTimer;

    private float timer;

    void Start()
    {
        circularTimer = FindAnyObjectByType<CircularTimer>();
        katamariScript = FindAnyObjectByType<AttachToRidgidBody>();
        // Initialize timer to the time limit
        timer = timeLimit;
        circularTimer.StartTimer();
    }

    void Update()
    {
        // Countdown the timer
        timer -= Time.deltaTime;

        // Update the timer display
        timerText.text = Mathf.Ceil(timer).ToString() + "S";

        // Check win/lose conditions
        if (timer <= 0)
        {
            // If the Katamari's size is less than the target size, transfer to FailScene
            if (katamariScript.katamariSize < targetSize)
            {
                SceneManager.LoadScene("FailScene");
            }
            else
            {
                SaveKatamariSize();
                // Otherwise, if the Katamari size has reached the target size, proceed to win
                SceneManager.LoadScene("WinScene");
            }
        }
    }
    private void SaveKatamariSize()
    {
        PlayerPrefs.SetFloat("FinalKatamariSize", katamariScript.katamariSize);
        PlayerPrefs.Save(); // Ensure the data is saved immediately
    }
}
