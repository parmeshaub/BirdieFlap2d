using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreTextGameOver;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject startUI;

    private void OnEnable() {
        PointManager.OnPointsChanged += UpdatePoints;
        GameManager.OnGameStart += InitializeStartGameUI;
        BirdieController.OnPlayerDeath += InitializeGameOverUI;
    }

    private void OnDisable() {
        PointManager.OnPointsChanged -= UpdatePoints;
        GameManager.OnGameStart -= InitializeStartGameUI;
        BirdieController.OnPlayerDeath -= InitializeGameOverUI;
    }

    private void Start() {
        InitalizeStartUI();
    }

    private void InitalizeStartUI() {
        startUI.SetActive(true);
        gameUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    private void InitializeStartGameUI() {
        startUI.SetActive(false);
        gameUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    private void InitializeGameOverUI() {
        startUI.SetActive(false);
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);

        scoreTextGameOver.text = scoreText.text;
    }

    private void UpdatePoints(int score) {
        scoreText.text = score.ToString();
    }
}
