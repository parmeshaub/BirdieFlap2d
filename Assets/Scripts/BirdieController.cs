using System;
using UnityEngine;

public class BirdieController : MonoBehaviour
{
    private InputManager inputManager;
    private Rigidbody2D rb;

    public event Action OnPlayerDeath; //Todo

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
    }
}

