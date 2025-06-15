using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int _gameScore;
    private int _highScore;

    private void Start()
    {
        _gameScore = 0;
        _highScore = PlayerPrefs.GetInt("highScore");
        scoreText.text = "SCORE: " + _gameScore;
        highScoreText.text = "High Score: " + _highScore;
    }

    public int getScore()
    {
        return _gameScore;
    }

    public void addPoints(int pointsToAdd)
    {
        _gameScore += pointsToAdd;
        scoreText.text = "SCORE: " + _gameScore; 
        Debug.Log(_gameScore);
    }


    [ContextMenu("ver pontos")]
    public void debugPoint()
    {
        Debug.Log(_gameScore);
    }
}
