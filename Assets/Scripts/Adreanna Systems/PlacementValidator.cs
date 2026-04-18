using UnityEngine;

public class PlacementValidator : MonoBehaviour
{
    public LayerMask validGroundLayer;
    public LayerMask blockedLayers; // EnemyPath, Restricted, Tower

    public float checkRadius = 1f;

    public bool IsValid()
    {
        // Check ground below
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);

        if (!Physics.Raycast(ray, 5f, validGroundLayer))
            return false;

        // Check for overlapping objects
        Collider[] hits = Physics.OverlapSphere(transform.position, checkRadius, blockedLayers);

        if (hits.Length > 0)
            return false;

        return true;
    }
}