using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveContent
{
    public EnemyData enemyType;
    public int count;
    public float spawnRate;
}

public class WaveSpawner : MonoBehaviour
{
    public List<WaveContent> waves; // List of waves you design in Inspector
    public Transform spawnPoint;
    public PathManager path;
    
    private int currentWaveIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to start next wave
        {
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        WaveContent currentWave = waves[currentWaveIndex];

        for (int i = 0; i < currentWave.count; i++)
        {
            GameObject enemyGO = Instantiate(currentWave.enemyType.prefab, spawnPoint.position, Quaternion.identity);
            
            // Tell the enemy which path to follow
            EnemyMovement moveScript = enemyGO.GetComponent<EnemyMovement>();
            moveScript.pathManager = path;
            moveScript.data = currentWave.enemyType;

            yield return new WaitForSeconds(currentWave.spawnRate);
        }

        currentWaveIndex++;
    }
}