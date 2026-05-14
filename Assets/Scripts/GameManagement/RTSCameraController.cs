using UnityEngine;
using UnityEngine.InputSystem;

public class RTSCameraController : MonoBehaviour
{
    public float moveSpeed = 20f;

    private InputSystem_Actions inputActions;
    private Vector2 moveInput;

    private float lastPlacementTime = -1f;
    private float possessDelay = 0.2f;

    private void Start()
    {
        if (InputManager.Instance == null)
        {
            Debug.LogError("InputManager not found in scene!");
            return;
        }

        inputActions = InputManager.Instance.InputActions;

        inputActions.RTS.Move.performed += OnMovePerformed;
        inputActions.RTS.Move.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        if (inputActions == null) return;

        inputActions.RTS.Move.performed -= OnMovePerformed;
        inputActions.RTS.Move.canceled -= OnMoveCanceled;
    }

    private void Update()
    {
        if (GameStateManager.Instance == null)
            return;

        if (GameStateManager.Instance.CurrentState != GameState.StrategyMode)
            return;

        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    public void TryPossess(GameObject tower)
    {
        Debug.Log("TryPossess CALLED");

        if (Time.time < lastPlacementTime + possessDelay)
        {
            Debug.Log("Blocked by delay");
            return;
        }

        Possessable possessable = tower.GetComponent<Possessable>();
        if (possessable != null)
        {
            possessable.EnterPossession();
        }
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
    }
    public void NotifyPlacement()
    {
        lastPlacementTime = Time.time;
    }
}