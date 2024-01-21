using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;

    private string highScoreKey = "HighScore";

    void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    void Update()
    {
        scoreUI.text = "Score: " + score.ToString();
        highScoreUI.text = "High Score: " + highScore.ToString();
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        Debug.Log(this.score);

        if (this.score > highScore)
        {
            highScore = this.score;

            PlayerPrefs.SetInt(highScoreKey, highScore);
            PlayerPrefs.Save();
        }
    }
}
