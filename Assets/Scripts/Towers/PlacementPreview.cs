using UnityEngine;

public class PlacementPreview : MonoBehaviour
{
    public PlacementValidator validator;
    public Renderer previewRenderer;

    void Update()
    {
        if (validator.IsValid())
            previewRenderer.material.color = Color.green;
        else
            previewRenderer.material.color = Color.red;
    }
}