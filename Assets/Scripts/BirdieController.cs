using System;
using UnityEngine;

public class BirdieController : MonoBehaviour
{
    private InputManager inputManager;
    private Rigidbody2D rb;

    private bool isPlayerDead = false;
    public static event Action OnPlayerDeath;
    public static event Action OnJump;

    [SerializeField] private float jumpForce;

    private void OnEnable()
    {
        inputManager.OnJumpPressed += Jump;
    }

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    private void GameOrRestartStart() {
        isPlayerDead = false;
    }
}

