using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementManager : MonoBehaviour
{
    public GameObject previewPrefab;
    private GameObject previewInstance;

    public List<GameObject> towerPrefabs;

    public enum TowerType
    {
        Tower1,
        Tower2,
        Tower3,
        Tower4,
        Tower5
    }

    public TowerType selectedTowerType;

    private Camera strategyCamera;
    private InputSystem_Actions inputActions;
    internal static readonly object Instance;

    private void Start()
    {
        if (previewPrefab == null)
        {
            Debug.LogError("Preview Prefab not assigned!");
            return;
        }

        if (CameraManager.Instance == null)
        {
            Debug.LogError("CameraManager missing!");
            return;
        }

        strategyCamera = CameraManager.Instance.strategyCamera.GetComponent<Camera>();

        if (InputManager.Instance == null)
        {
            Debug.LogError("InputManager missing!");
            return;
        }

        inputActions = InputManager.Instance.InputActions;

        previewInstance = Instantiate(previewPrefab);

        inputActions.RTS.Place.performed += OnPlace;
    }

    private void OnDisable()
    {
        if (inputActions != null)
            inputActions.RTS.Place.performed -= OnPlace;
    }

    private void Update()
    {
        if (GameStateManager.Instance == null)
            return;

        if (GameStateManager.Instance.CurrentState != GameState.StrategyMode)
            return;

        MovePreview();
    }

    void MovePreview()
    {
        Ray ray = strategyCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, 100f,
            LayerMask.GetMask("Ground", "Buildable")))
        {
            Vector3 pos = hit.point;
            pos.y = 0.5f;
            previewInstance.transform.position = pos;
        }
    }
    /**
<<<<<<< HEAD
        // public void TryPlaceTower()
=======
        void OnPlace(InputAction.CallbackContext ctx)
        {
            if (GameStateManager.Instance.CurrentState != GameState.StrategyMode)
                return;

            TryPlaceTower();
        }
>>>>>>> Adreanna
            **/
    void TryPlaceTower()

    {
        PlacementValidator validator = previewInstance.GetComponent<PlacementValidator>();

        if (validator != null && validator.IsValid())
        {
            int index = (int)selectedTowerType;

            if (index >= 0 && index < towerPrefabs.Count)
            {
                Instantiate(
                    towerPrefabs[index],
                    previewInstance.transform.position,
                    Quaternion.identity
                );
                FindFirstObjectByType<RTSCameraController>()?.NotifyPlacement();
            }
        }
    }
}