using UnityEngine;
using TMPro; // if using TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText; // Use TextMeshProUGUI if needed

    void Awake()
    {
        instance = this;
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: 0";
    }
}
