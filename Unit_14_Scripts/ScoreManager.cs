using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    // Get point values based on object.
    public void GetPoints(string name)
    {
        int points = 0;
        switch (name)
        {
            case "Mothership(Clone)":
                points = 50;
                break;
            case "UFO(Clone)":
                points = 100;
                break;
            case "Scout(Clone)":
                points = 150;
                break;
        }

        IncreaseScore(points);
    }

    // Get negative point values based on object.
    public void LosePoints(string name)
    {
        int points = 0;
        switch (name)
        {
            case "Mothership(Clone)":
                points = 50;
                break;
            case "UFO(Clone)":
                points = 100;
                break;
            case "Scout(Clone)":
                points = 150;
                break;
        }

        DecreaseScore(points);
    }

    // Get points.
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // Lose points.
    public void DecreaseScore(int amount)
    {
        score -= amount;
        UpdateScoreText();
    }

    // Show new score total.
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
