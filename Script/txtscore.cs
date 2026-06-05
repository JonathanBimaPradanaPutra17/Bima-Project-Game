using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText; // Tarik 'ScoreNumber' ke sini
    int currentScore = 0;

    void Awake()
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
    }

    void Start()
    {
        // Ambil score dari scoremanager dan tampilkan
        if (scoremanager.instance != null)
        {
            currentScore = scoremanager.instance.GetScore();
        }
        UpdateScoreUI();
    }

    public void AddScore()
    {
        currentScore++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
        else
        {
            Debug.LogError("ScoreManager: scoreText is not assigned in the Inspector.");
        }
    }

    // Getter untuk mengambil current score
    public int GetCurrentScore()
    {
        return currentScore;
    }

    // Setter untuk set score
    public void SetScore(int newScore)
    {
        currentScore = newScore;
        UpdateScoreUI();
    }
}