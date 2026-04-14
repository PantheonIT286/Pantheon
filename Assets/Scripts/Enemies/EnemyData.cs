using UnityEngine;

/*
Purpose of this script is to define the variables for enemy data, including it's speed, health,
and the amount of gold it'll drop when killed.
*/

[CreateAssetMenu(fileName = "NewEnemy", menuName = "TowerDefense/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float speed;
    public int health;
    public int goldReward;
    public GameObject prefab; // The actual 3D model/prefab
}