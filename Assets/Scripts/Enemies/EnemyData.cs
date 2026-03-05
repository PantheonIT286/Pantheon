using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "TowerDefense/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float speed;
    public int health;
    public int goldReward;
    public GameObject prefab; // The actual 3D model/prefab
}