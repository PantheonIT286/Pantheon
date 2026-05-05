using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementManager : MonoBehaviour
{
    public GameObject previewPrefab;
    public GameObject finalTowerPrefab;
    private GameObject previewInstance;

    private Camera strategyCamera;
    private InputSystem_Actions inputActions;

    private void Start()
    {
        strategyCamera = GameStateManager.Instance.strategyCamera.GetComponent<Camera>();
        inputActions = InputManager.Instance.InputActions;

        previewInstance = Instantiate(previewPrefab);
    }

    void Update()
    {
        if (GameStateManager.Instance.CurrentState != GameState.StrategyMode)
            return;

        MovePreview();

        if (Mouse.current.leftButton.wasPressedThisFrame)
            TryPlaceTower();
    }

    void MovePreview()
    {
        Ray ray = strategyCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Ground")))
        {
            Vector3 snappedPosition = hit.point;

            snappedPosition.y = 0.5f; 

            previewInstance.transform.position = snappedPosition;
        }
    }

    void TryPlaceTower()
    {
        PlacementValidator validator = previewInstance.GetComponent<PlacementValidator>();

        if (validator != null && validator.IsValid())
        {
            Instantiate(finalTowerPrefab, previewInstance.transform.position, Quaternion.identity);
        }
    }
}