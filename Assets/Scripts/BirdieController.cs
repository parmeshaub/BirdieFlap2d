using System;
using UnityEngine;

public class BirdieController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float tiltSpeed = 5;

    [SerializeField] private float tiltPosThreshold;
    [SerializeField] private float tiltNegThreshold;

    private bool isPlayerDead = false;

    public static event Action OnPlayerDeath;
    public static event Action OnJump;

    [SerializeField] private float jumpForce;

    private void OnEnable()
    {
        InputManager.OnJumpPressed += Jump;
        GameManager.OnGameStart += StartGame;
    }

    private void OnDisable() {
        InputManager.OnJumpPressed -= Jump;
        GameManager.OnGameStart -= StartGame;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        GameInitialization();
    }

    private void FixedUpdate() {
        TiltBirdOnVelocity();
    }

    private void TiltBirdOnVelocity() {
        float targetZ = 0;

        if (rb.linearVelocity.y >= tiltPosThreshold) targetZ = 50f;
        else if (rb.linearVelocity.y <= tiltNegThreshold) targetZ = -90f;

        Quaternion targetRotation = Quaternion.Euler(0, 0, targetZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * tiltSpeed);
    }

    private void Jump()
    {
        rb.linearVelocityY = 0;
        rb.AddForceY(jumpForce);
        OnJump?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!isPlayerDead) {
            OnPlayerDeath?.Invoke();
            isPlayerDead = true;
        }
    }

    private void GameInitialization() {
        this.gameObject.transform.position = new Vector3(0, 0, 0);
        isPlayerDead = false;
        rb.simulated = false;
    }

    private void StartGame() {
        this.gameObject.transform.position = new Vector3(0, 0, 0);
        isPlayerDead = false;
        rb.simulated = true;
    }
}

