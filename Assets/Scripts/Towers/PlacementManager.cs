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

    // flag to track if a tower has been purchased
    private bool towerPurchased = false;

    private void Start()
    {
        // Check if tower preview prefab is assigned in the inspector, else set it to inactive
        if (previewPrefab == null){
            Debug.LogError("Preview Prefab not assigned!");
            return;
        } else{
            previewPrefab.SetActive(false);
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
    
    // displays the tower preview when a tower has been purchased and game is in strategy mode
    private void Update(){
        if (GameStateManager.Instance == null || GameStateManager.Instance.CurrentState != GameState.StrategyMode){
            return;
        } else if (towerPurchased){
            Cursor.lockState = CursorLockMode.Confined;
            MovePreview();
        }
    }

    // moves the tower preview to the mouse position on the ground
    private void MovePreview(){
        // sets the position of the preview instance to the mouse position on the ground using raycasting
        Ray ray = strategyCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Ground", "Buildable"))){
            Vector3 pos = hit.point;
            pos.y = 0.5f;
            previewInstance.transform.position = pos;
        }

        // Ensure the preview instance is active when moving the mouse
        previewInstance.SetActive(true);
    }

    void OnPlace(InputAction.CallbackContext ctx)
    {
        if (GameStateManager.Instance.CurrentState != GameState.StrategyMode)
            return;

        TryPlaceTower();
    }

    public void TryPlaceTower()
    {
        PlacementValidator validator = previewInstance.GetComponent<PlacementValidator>();

        if (validator != null && validator.IsValid() && towerPurchased)
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

                // Reset the preview instance and towerPurchased flag after placing the tower
                previewInstance.SetActive(false);
                towerPurchased = false;
            }
        }
    }

    // method to set the towerPurchased flag to true when a tower is purchased
    public void setTowerPurchased(){
        towerPurchased = true;
    }
}