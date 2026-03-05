using UnityEngine;
using UnityEngine.InputSystem;

public class RTSCameraController : MonoBehaviour
{
    public float moveSpeed = 20f;

    private InputSystem_Actions inputActions;
    private Vector2 moveInput;

    private void Awake()
    {
        if (InputManager.Instance == null)
        {
            Debug.LogError("InputManager not found in scene!");
            return;
        }

        inputActions = InputManager.Instance.InputActions;
    }

    private void OnEnable()
    {
        inputActions.RTS.Move.performed += OnMovePerformed;
        inputActions.RTS.Move.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        inputActions.RTS.Move.performed -= OnMovePerformed;
        inputActions.RTS.Move.canceled -= OnMoveCanceled;
    }

    private void OnMovePerformed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
    }

    private void Update()
    {
        if (GameStateManager.Instance.CurrentState != GameState.StrategyMode)
            return;

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.position += move * moveSpeed * Time.deltaTime;
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameStateManager.Instance.SetState(GameState.PossessionMode);
        }
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            TryPossess();
        }
    }
    void TryPossess()
    {
        Debug.Log("Trying to possess");

        if (GameStateManager.Instance == null)
        {
            Debug.LogError("GameStateManager.Instance is NULL");
            return;
        }

        if (GameStateManager.Instance.strategyCamera == null)
        {
            Debug.LogError("Strategy Camera is NULL");
            return;
        }

        Camera cam = GameStateManager.Instance.strategyCamera.GetComponent<Camera>();

        if (cam == null)
        {
            Debug.LogError("Camera component missing on strategyCamera");
            return;
        }

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Hit: " + hit.collider.name);

            Possessable possessable = hit.collider.GetComponent<Possessable>();

            if (possessable != null)
            {
                possessable.EnterPossession();
            }
        }
    }
}