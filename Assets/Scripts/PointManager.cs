using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;

    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
    
    public void HighScoreUpdate()
    {
        // is there already a high score?
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (score > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
        }

        // update text
        finalScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
}
