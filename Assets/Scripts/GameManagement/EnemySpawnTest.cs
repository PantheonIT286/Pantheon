using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySpawnTester : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("Spawn setup is missing!");
            return;
        }

        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, randomPoint.position, randomPoint.rotation);

        Debug.Log("Enemy spawned at: " + randomPoint.position);
    }
}