using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-100)]
public class InputManager : MonoBehaviour
{
    [SerializeField] private InputSystem_Actions inputActions;
    public static event Action OnJumpPressed;
    public static event Action OnStartPressed;
    public static InputManager Instance { get; private set; }
    private bool isGameRunning = false;

    private void Awake()
    {
        Instance = this;
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Birdie.Jump.performed += HandleJump;
        inputActions.MainMenu.Start.performed += StartSignal;
        inputActions.Birdie.Exit.performed += QuitGame;
        inputActions.MainMenu.Exit.performed += QuitGame;


        BirdieController.OnPlayerDeath += PlayerDeath;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Birdie.Jump.performed -= HandleJump;
        inputActions.MainMenu.Start.performed -= StartSignal;
        inputActions.Birdie.Exit.performed -= QuitGame;
        inputActions.MainMenu.Exit.performed -= QuitGame;


        BirdieController.OnPlayerDeath -= PlayerDeath;
    }

    private void HandleJump(InputAction.CallbackContext context)
    {
        OnJumpPressed?.Invoke();
    }

    private void PlayerDeath() {
        isGameRunning = false;
    }

    private void StartSignal(InputAction.CallbackContext context) {
        if (!isGameRunning) {
            isGameRunning = true;
            OnStartPressed?.Invoke();
        }
    }

    private void QuitGame(InputAction.CallbackContext context) {
        Application.Quit();
    }
}
