using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FPSMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float mouseSensitivity = 2f;

    public Transform cameraPivot;

    private CharacterController controller;
    private InputSystem_Actions inputActions;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private float verticalRotation = 0f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputActions = InputManager.Instance.InputActions;
    }

    private void OnEnable()
    {
        inputActions.FPS.Move.performed += OnMove;
        inputActions.FPS.Move.canceled += OnMoveCanceled;

        inputActions.FPS.Look.performed += OnLook;
        inputActions.FPS.Look.canceled += OnLookCanceled;
    }

    private void OnDisable()
    {
        inputActions.FPS.Move.performed -= OnMove;
        inputActions.FPS.Move.canceled -= OnMoveCanceled;

        inputActions.FPS.Look.performed -= OnLook;
        inputActions.FPS.Look.canceled -= OnLookCanceled;
    }

    private void Update()
    {
        if (GameStateManager.Instance.CurrentState != GameState.PossessionMode)
            return;

        HandleMovement();
        HandleLook();
    }

    private void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    private void HandleLook()
    {
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

        cameraPivot.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
    }

    private void OnLook(InputAction.CallbackContext ctx)
    {
        lookInput = ctx.ReadValue<Vector2>();
    }

    private void OnLookCanceled(InputAction.CallbackContext ctx)
    {
        lookInput = Vector2.zero;
    }
}