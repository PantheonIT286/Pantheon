using UnityEngine;

public class TowerHUDController : MonoBehaviour
{
    public PlacementManager placementManager;

    public void SelectTower1()
    {
        placementManager.selectedTowerType = PlacementManager.TowerType.Tower1;
    }

    public void SelectTower2()
    {
        placementManager.selectedTowerType = PlacementManager.TowerType.Tower2;
    }

    public void SelectTower3()
    {
        placementManager.selectedTowerType = PlacementManager.TowerType.Tower3;
    }
    public void SelectTower4()
    {
        placementManager.selectedTowerType = PlacementManager.TowerType.Tower4;
    }
    public void SelectTower5()
    {
        placementManager.selectedTowerType = PlacementManager.TowerType.Tower5;
    }
}