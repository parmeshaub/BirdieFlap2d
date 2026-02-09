using System;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-100)]
public class InputManager : MonoBehaviour
{
    [SerializeField] private InputSystem_Actions inputActions;
    public event Action OnJumpPressed;
    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Birdie.Jump.performed += HandleJump;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Birdie.Jump.performed -= HandleJump;
    }

    private void HandleJump(InputAction.CallbackContext context)
    {
        OnJumpPressed?.Invoke();
    }
}
