using UnityEngine;
using UnityEngine.InputSystem;

public class FPSController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;

    private InputSystem_Actions inputActions;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private float verticalRotation = 0f;
    private Transform cameraRoot;

    private void Start()
    {
        if (InputManager.Instance == null)
        {
            Debug.LogError("InputManager not found in scene!");
            return;
        }

        inputActions = InputManager.Instance.InputActions;
        cameraRoot = transform.parent;

        inputActions.FPS.Move.performed += OnMove;
        inputActions.FPS.Move.canceled += OnMoveCancel;

        inputActions.FPS.Look.performed += OnLook;
        inputActions.FPS.Look.canceled += OnLookCancel;

        inputActions.FPS.Exit.performed += OnExitPressed;
    }

    private void OnDisable()
    {
        if (inputActions == null) return;

        inputActions.FPS.Move.performed -= OnMove;
        inputActions.FPS.Move.canceled -= OnMoveCancel;

        inputActions.FPS.Look.performed -= OnLook;
        inputActions.FPS.Look.canceled -= OnLookCancel;

        inputActions.FPS.Exit.performed -= OnExitPressed;
    }

    private void Update()
    {
        if (GameStateManager.Instance.CurrentState != GameState.PossessionMode)
            return;

        HandleMovement();
        HandleLook();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnMoveCancel(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
    }

    private void OnLook(InputAction.CallbackContext ctx)
    {
        lookInput = ctx.ReadValue<Vector2>();
    }

    private void OnLookCancel(InputAction.CallbackContext ctx)
    {
        lookInput = Vector2.zero;
    }

    private void HandleMovement()
    {
        Vector3 move = cameraRoot.right * moveInput.x + cameraRoot.forward * moveInput.y;
        cameraRoot.position += move * moveSpeed * Time.deltaTime;
    }

    private void HandleLook()
    {
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        cameraRoot.Rotate(Vector3.up * mouseX);
    }

    private void OnExitPressed(InputAction.CallbackContext ctx)
    {
        if (GameStateManager.Instance.CurrentState != GameState.PossessionMode)
            return;

        GameStateManager.Instance.SetState(GameState.StrategyMode);
    }

    //temp
    public void StrategyMode()
    {
        if (GameStateManager.Instance.CurrentState != GameState.PossessionMode)
            return;

        GameStateManager.Instance.SetState(GameState.StrategyMode);
    }
}