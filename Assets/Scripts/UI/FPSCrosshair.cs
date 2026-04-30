using UnityEngine;
using UnityEngine.UI;

public class FPSCrosshair : MonoBehaviour
{
    private Image crosshairImage;

    void Awake()
    {
        crosshairImage = GetComponent<Image>();

        // Ensure correct state on start
        UpdateVisibility(GameStateManager.Instance.CurrentState);
    }

    void OnEnable()
    {
        GameStateManager.OnGameStateChanged += UpdateVisibility;
    }

    void OnDisable()
    {
        GameStateManager.OnGameStateChanged -= UpdateVisibility;
    }

    void UpdateVisibility(GameState state)
    {
        if (crosshairImage == null) return;

        crosshairImage.enabled = (state == GameState.PossessionMode);
    }
}