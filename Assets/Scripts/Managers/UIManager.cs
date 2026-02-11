using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnEnable() {
        PointManager.OnPointsChanged += UpdatePoints;
    }

    private void UpdatePoints(int score) {
        scoreText.text = score.ToString();
    }
}
