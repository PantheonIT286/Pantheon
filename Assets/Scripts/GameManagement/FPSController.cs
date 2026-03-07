using UnityEngine;
using UnityEngine.InputSystem;

public class FPSController : MonoBehaviour
{
    private InputSystem_Actions inputActions;

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
        inputActions.FPS.Exit.performed += OnExitPressed;
    }

    private void OnDisable()
    {
        inputActions.FPS.Exit.performed -= OnExitPressed;
    }

    private void OnExitPressed(InputAction.CallbackContext ctx)
    {
        if (GameStateManager.Instance.CurrentState != GameState.PossessionMode)
            return;

        GameStateManager.Instance.SetState(GameState.StrategyMode);
    }
}