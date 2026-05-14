using UnityEngine;
using Unity.VisualScripting;
using System.Collections;

public class Tower: MonoBehaviour{
    public int Health = 1500;
    public float  coolDown = 0;
    int dif;
    private PlacementManager placementManager;
    private EconomyManager economyManager;
    private GameObject TowerTile;
    public GameObject unitPrefab;

    private void Start(){
            dif = GameManager.Instance.DifficultyScale;
        TowerTile = GameObject.Find("ValidTowerPlacement");
            if (placementManager == null){
            placementManager = FindFirstObjectByType<PlacementManager>();
        }
        if (economyManager == null){
            economyManager = FindFirstObjectByType<EconomyManager>();
        }
    }
    public void PlaceTower(){
        bool canPlace = Variables.Object(TowerTile).Get<bool>("ValidTowerPlacement");
        if (canPlace){
            placementManager.TryPlaceTower();
            Variables.Object(TowerTile).Set("ValidTowerPlacement", false);
            SpawnUnit();

        }

        if (Health <= 0){
            Destroy(gameObject);
            coolDown = dif * 6;
        }
 
    }

    public void SpawnUnit(){
        if (economyManager == null)
        {
            Debug.LogWarning("EconomyManager not found. Cannot spawn unit.");
            return;
        }

        if (!economyManager.TrySpendGold(economyManager.UnitPlacementCost))
        {
            Debug.Log("Not enough gold to spawn unit.");
            return;
        }

        if (unitPrefab == null || TowerTile == null)
        {
            Debug.LogWarning("Missing unit prefab or tower tile for spawning.");
            return;
        }

        Vector3 tilePos = TowerTile.transform.position;
        Instantiate(unitPrefab, tilePos, Quaternion.identity);
    }

    private void Update(){
         float Nextplacement = 1;
         Nextplacement = Time.time + coolDown;
        if (Nextplacement > Time.time) {
            Variables.Object(TowerTile).Set("ValidTowerPlacement", true);
        }
    }

}
