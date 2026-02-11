using UnityEngine;
using System;

public class PipeScript : MonoBehaviour
{
    [SerializeField] private float pipeSpeed;
    private bool isPlayerDead = false;
    public static event Action OnScorePoint;

    private void OnEnable() {
        BirdieController.OnPlayerDeath += PlayerDeath;
    }

    private void OnDisable() {
        BirdieController.OnPlayerDeath -= PlayerDeath;

    }

    private void Update() {
        if(!isPlayerDead) MovePipe();

        DeletePipeIfExceedX();
    }

    private void MovePipe() {
        Vector3 newPosition = new Vector3(this.transform.position.x - pipeSpeed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
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
        }
    }

    private void PlayerDeath() {
        isPlayerDead = true;
    }

    private void GameStart() {
        isPlayerDead = false;
        Destroy(this.gameObject);
    }
}
