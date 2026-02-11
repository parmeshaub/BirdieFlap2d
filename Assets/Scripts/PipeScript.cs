using UnityEngine;
using System;

public class PipeScript : MonoBehaviour
{
    [SerializeField] private float pipeSpeed;
    private static float currentPipeSpeed;
    [SerializeField] private float pipeSpeedIncrement;

    private bool isPlayerDead = false;
    public static event Action OnScorePoint;

    private void OnEnable() {
        BirdieController.OnPlayerDeath += PlayerDeath;
        GameManager.OnGameStart += StartGame;
    }

    private void OnDisable() {
        BirdieController.OnPlayerDeath -= PlayerDeath;
        GameManager.OnGameStart -= StartGame;
    }

    private void Update() {
        if(!isPlayerDead) MovePipe();

        DeletePipeIfExceedX();
    }

    private void MovePipe() {
        float newSpeed = this.transform.position.x - currentPipeSpeed * Time.deltaTime;
        Vector3 newPosition = new Vector3(newSpeed, this.transform.position.y, this.transform.position.z);
        this.transform.position = newPosition;
    }

    private void DeletePipeIfExceedX() {
        if(this.transform.position.x < -13) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            OnScorePoint?.Invoke();
            currentPipeSpeed += pipeSpeedIncrement;
        }
    }

    private void PlayerDeath() {
        isPlayerDead = true;
    }

    public float PipeSpeed => pipeSpeed;

    public static void ResetSpeed(float speed) {
        currentPipeSpeed = speed;
    }

    private void StartGame() {
        // Cleaning up existing pipes on restart, speed is reset by spawner
        isPlayerDead = false;
        Destroy(this.gameObject);
    }
}
