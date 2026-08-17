using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
