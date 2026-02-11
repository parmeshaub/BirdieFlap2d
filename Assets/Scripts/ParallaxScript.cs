using UnityEngine;

public class ParallaxScript : MonoBehaviour {
    private float length;
    private float startPos;

    private float autoScrollOffset;

    [SerializeField] private float parallaxEffect; 
    [SerializeField] private float scrollSpeed = 2f; 
    
    private bool shouldScroll = true;

    private void OnEnable() {
        GameManager.OnGameStart += StartParallax;
        BirdieController.OnPlayerDeath += StopParallax;
    }

    private void OnDisable() {
        GameManager.OnGameStart -= StartParallax;
        BirdieController.OnPlayerDeath -= StopParallax;
    }

    private void Start() {
        startPos = transform.position.x;
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate() {
        if (!shouldScroll) return;

        autoScrollOffset += (scrollSpeed * parallaxEffect) * Time.fixedDeltaTime;
        float distance = autoScrollOffset % length;
        transform.position = new Vector3(startPos - distance, transform.position.y, transform.position.z);
    }

    private void StartParallax() => shouldScroll = true;
    private void StopParallax() => shouldScroll = false;
}