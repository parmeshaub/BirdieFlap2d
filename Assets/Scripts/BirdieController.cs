using System;
using UnityEngine;

public class BirdieController : MonoBehaviour
{
    private Rigidbody2D rb;

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

