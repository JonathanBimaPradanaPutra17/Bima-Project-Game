using UnityEngine;

public class itempickable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Update score di scoremanager (untuk coinText di game)
            if (scoremanager.instance != null)
            {
                scoremanager.instance.AddScore();
            }
            else
            {
                Debug.LogWarning("itempickable: scoremanager.instance is null when picking up an item.");
            }

            // Update score di ScoreManager/txtscore (untuk scoreText di LevelCompleteMenu)
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore();
            }
            else
            {
                Debug.LogWarning("itempickable: ScoreManager.instance is null when picking up an item.");
            }

            Destroy(gameObject);
        }
    }
}
