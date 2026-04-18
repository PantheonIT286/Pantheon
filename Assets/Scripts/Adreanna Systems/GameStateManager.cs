
using UnityEngine;

public enum GameState
{
    StrategyMode,
    PossessionMode
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public static System.Action<GameState> OnGameStateChanged;

    public GameState CurrentState { get; private set; }

    private InputSystem_Actions inputActions;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (InputManager.Instance == null)
        {
            Debug.LogError("InputManager missing!");
            return;
        }

        inputActions = InputManager.Instance.InputActions;

        SetState(GameState.StrategyMode);

        Debug.Log("RTS Enabled: " + inputActions.RTS.enabled);
        Debug.Log("FPS Enabled: " + inputActions.FPS.enabled);
    }

    public void SetState(GameState newState)
    {
        Debug.Log("STATE CHANGE: " + newState);

        CurrentState = newState;

        OnGameStateChanged?.Invoke(newState);

        if (inputActions != null)
        {
            if (newState == GameState.StrategyMode)
            {
                inputActions.RTS.Enable();
                inputActions.FPS.Disable();

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                inputActions.RTS.Disable();
                inputActions.FPS.Enable();

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}