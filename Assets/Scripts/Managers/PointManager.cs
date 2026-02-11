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
    }

    private void OnDisable() {
        PipeScript.OnScorePoint -= AddPoint;
    }

    private void AddPoint() {
        score++;
        OnPointsChanged?.Invoke(score);

    }

    private void ResetOrStartGame() {
        score = 0;
        OnPointsChanged?.Invoke(score);
    }
}
