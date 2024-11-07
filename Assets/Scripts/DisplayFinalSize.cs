using UnityEngine;
using TMPro;
public class DisplayFinalSize : MonoBehaviour
{
    public TextMeshProUGUI finalSizeText; // Reference to TMP text for displaying the final size
    public TextMeshProUGUI finalSizeTextRight;

    void Start()
    {
        // Retrieve the saved Katamari size from PlayerPrefs
        float finalSize = PlayerPrefs.GetFloat("FinalKatamariSize", 0f);
        finalSizeText.text = "Wow! You Reached: " + finalSize.ToString("F2") + " CM";
        finalSizeTextRight.text = "Final Size: " + finalSize.ToString("F2") + " CM";
    }
}
