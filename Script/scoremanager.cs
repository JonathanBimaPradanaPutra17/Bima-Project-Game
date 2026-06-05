using UnityEngine;
using TMPro;

public class scoremanager : MonoBehaviour
{
    public static scoremanager instance;

    public TextMeshProUGUI coinText;
    int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (coinText == null)
        {
            // try to find a TextMeshProUGUI in the scene as a fallback
            coinText = FindObjectOfType<TextMeshProUGUI>();
            if (coinText == null)
            {
                Debug.LogError("scoremanager: coinText is not assigned in the Inspector and no TextMeshProUGUI was found in the scene.");
            }
        }
    }

    public void AddScore()
    {
        score++;
        if (coinText != null)
        {
            coinText.text = score.ToString();
        }
        else
        {
            Debug.LogError("scoremanager.AddScore: coinText is null. Assign it in the Inspector.");
        }
    }

    // Reset score to zero and update UI if available
    public void ResetScore()
    {
        score = 0;
        if (coinText != null)
        {
            coinText.text = score.ToString();
        }
    }

    // Getter untuk mengambil score saat ini
    public int GetScore()
    {
        return score;
    }
}