using UnityEngine;
using System.Collections;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float timeToSpawn;

    [SerializeField] private float maxPipeHeight = 2.5f;
    [SerializeField] private float minPipeHeight = -1.25f;

    private bool isPlayerDead = false;

    private void OnEnable() {
        BirdieController.OnPlayerDeath += PlayerDeath;
        GameManager.OnGameStart += StartGame;
    }

    private void OnDisable() {
        BirdieController.OnPlayerDeath -= PlayerDeath;
        GameManager.OnGameStart -= StartGame;
    }

    private void Start() {

    }

    private float RandomizePipeYValue() {
        float pipeHeight = Random.Range(minPipeHeight, maxPipeHeight);
        return pipeHeight;
    }

    private IEnumerator SpawnPipe() {
        yield return new WaitForSeconds(timeToSpawn);
        if (isPlayerDead) yield break;
        Vector3 newPosition = new Vector3(this.transform.position.x, RandomizePipeYValue(), this.transform.position.z);
        Instantiate(pipePrefab,newPosition, this.transform.localRotation, this.transform);
        StartCoroutine(SpawnPipe());
    }

    private void StartGame() {
        isPlayerDead = false;
        StartCoroutine(SpawnPipe());
    }

    private void PlayerDeath() {
        isPlayerDead = true;
        StopAllCoroutines();
    }
}
