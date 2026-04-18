using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public GameObject strategyCamera;
    public GameObject fpsCamera;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        HandleStateChange(GameStateManager.Instance.CurrentState);
    }

    private void OnEnable()
    {
        GameStateManager.OnGameStateChanged += HandleStateChange;
    }

    private void OnDisable()
    {
        GameStateManager.OnGameStateChanged -= HandleStateChange;
    }

    private void HandleStateChange(GameState state)
    {
        Debug.Log("Camera Switch: " + state);

        if (strategyCamera == null || fpsCamera == null)
        {
            Debug.LogError("CameraManager: Cameras not assigned!");
            return;
        }

        if (strategyCamera.transform.parent != null)
            strategyCamera.transform.parent.gameObject.SetActive(state == GameState.StrategyMode);

        if (fpsCamera.transform.parent != null)
            fpsCamera.transform.parent.gameObject.SetActive(state == GameState.PossessionMode);

        strategyCamera.SetActive(state == GameState.StrategyMode);
        fpsCamera.SetActive(state == GameState.PossessionMode);

        Debug.Log("StrategyCam FINAL ActiveInHierarchy: " + strategyCamera.activeInHierarchy);
        Debug.Log("FPSCam FINAL ActiveInHierarchy: " + fpsCamera.activeInHierarchy);
    }
}