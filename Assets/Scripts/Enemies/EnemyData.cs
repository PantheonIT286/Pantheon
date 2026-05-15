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
    public int castleDamage; // How much damage it does to the castle if it reaches the end
    public int goldReward;
    public GameObject prefab; // The actual 3D model/prefab
    public float aggressionChance; // 0.0 to 1.0 (0.2 = 20% chance to deviate)
    public float detectionRadius;  // How far the enemy can "see" a tower
}