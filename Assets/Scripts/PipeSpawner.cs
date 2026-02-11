using UnityEngine;
using System.Collections;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float timeToSpawn;
    private float currentSpawnTime;
    [SerializeField] private float spawnTimeDecrease = 0.05f;
    [SerializeField] private float minSpawnTime = 0.5f;

    [SerializeField] private float maxPipeHeight = 2.5f;
    [SerializeField] private float minPipeHeight = -1.25f;

    private bool isPlayerDead = false;

    private void OnEnable() {
        BirdieController.OnPlayerDeath += PlayerDeath;
        GameManager.OnGameStart += StartGame;
        PipeScript.OnScorePoint += DecreaseSpawnTime;
    }

    private void OnDisable() {
        BirdieController.OnPlayerDeath -= PlayerDeath;
        GameManager.OnGameStart -= StartGame;
        PipeScript.OnScorePoint -= DecreaseSpawnTime;
    }

    private float RandomizePipeYValue() {
        float pipeHeight = Random.Range(minPipeHeight, maxPipeHeight);
        return pipeHeight;
    }

    private IEnumerator SpawnPipe() {
        if (isPlayerDead) yield break;
        Vector3 newPosition = new Vector3(this.transform.position.x, RandomizePipeYValue(), this.transform.position.z);
        Instantiate(pipePrefab, newPosition, this.transform.localRotation, this.transform);
        yield return new WaitForSeconds(currentSpawnTime);
        StartCoroutine(SpawnPipe());
    }

    private void StartGame() {
        isPlayerDead = false;
        currentSpawnTime = timeToSpawn;
        
        if(pipePrefab != null) {
            var pipeScript = pipePrefab.GetComponent<PipeScript>();
            if(pipeScript != null) {
                PipeScript.ResetSpeed(pipeScript.PipeSpeed);
            }
        }
        
        StartCoroutine(SpawnPipe());
    }

    private void DecreaseSpawnTime() {
        currentSpawnTime = Mathf.Max(minSpawnTime, currentSpawnTime - spawnTimeDecrease);
    }

    private void PlayerDeath() {
        isPlayerDead = true;
        StopAllCoroutines();
    }
}
