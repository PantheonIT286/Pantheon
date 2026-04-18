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

<<<<<<< HEAD:Assets/Scripts/GameManagement/RTSCameraController.cs
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.position += move * moveSpeed * Time.deltaTime;
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            GameStateManager.Instance.SetState(GameState.PossessionMode);
        }
=======
        HandleMovement();

>>>>>>> c728ace731797a7af9ee6d87fcf149c40d872592:Assets/Scripts/Adreanna Systems/RTSCameraController.cs
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            TryPossess();
        }
    }

    void HandleMovement()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void TryPossess()
    {
        Debug.Log("TryPossess CALLED");

        if (Time.time < lastPlacementTime + possessDelay)
        {
            Debug.Log("Blocked by delay");
            return;
        }

        Camera cam = CameraManager.Instance.strategyCamera.GetComponent<Camera>();

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Possessable possessable = hit.collider.GetComponentInParent<Possessable>();

            if (possessable != null)
            {
                possessable.EnterPossession();
            }
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