using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer; 

    void Start()
    {
        videoPlayer.Play();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            HandleSceneTransition();
        }
    }
    void HandleSceneTransition()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene)
        {
            case "Menu":
                SceneManager.LoadScene("Tutorial");
                break;
            case "FailScene":
                SceneManager.LoadScene("Menu");
                break;
            case "Intro":
                SceneManager.LoadScene("Menu");
                break;
            default:
                Debug.LogWarning("Unhandled scene transition for current scene: " + currentScene);
                break;
        }
    }
}
