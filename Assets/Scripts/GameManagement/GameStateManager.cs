using UnityEngine;

public enum GameState
{
    StrategyMode,
    PossessionMode
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public GameState CurrentState { get; private set; }

    private InputSystem_Actions inputActions;

    [Header("Cameras")]
    public GameObject strategyCamera;
    public GameObject fpsCamera;

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
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;

        if (newState == GameState.StrategyMode)
        {
            strategyCamera.SetActive(true);
            fpsCamera.SetActive(false);

            inputActions.RTS.Enable();
            inputActions.FPS.Disable();
        }
        else
        {
            strategyCamera.SetActive(false);
            fpsCamera.SetActive(true);

            inputActions.RTS.Disable();
            inputActions.FPS.Enable();
        }
    }
}