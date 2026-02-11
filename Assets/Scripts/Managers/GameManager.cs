using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameStart;

    private void OnEnable() {
        InputManager.OnStartPressed += GameStart;
    }
    private void OnDisable() {
        InputManager.OnStartPressed -= GameStart;
    }

    private void GameStart() {
        OnGameStart?.Invoke();
    }
}
