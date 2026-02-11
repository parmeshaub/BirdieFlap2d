using UnityEngine;
using System;

public class PointManager : MonoBehaviour
{
    private int score = 0;
    public static event Action<int> OnPointsChanged;

    private void Start() {
        OnPointsChanged?.Invoke(score);
    }

    private void OnEnable() {
        PipeScript.OnScorePoint += AddPoint;
        GameManager.OnGameStart += ResetOrStartGame;
        BirdieController.OnPlayerDeath += CheckAndSaveHighScore;
    }

    private void OnDisable() {
        PipeScript.OnScorePoint -= AddPoint;
        GameManager.OnGameStart -= ResetOrStartGame;

    }

    private void AddPoint() {
        score++;
        OnPointsChanged?.Invoke(score);

    }

    private void ResetOrStartGame() {
        score = 0;
        OnPointsChanged?.Invoke(score);
    }

    private void CheckAndSaveHighScore() {
        if(score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
