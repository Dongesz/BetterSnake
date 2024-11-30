using System.ComponentModel;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText; 

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
