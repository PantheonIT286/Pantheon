using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class WaveContent
    {
        public EnemyData enemyType;
        public int count;
        public float spawnRate;
    }

    public List<WaveContent> waves; 
    public Transform spawnPoint;
    public PathManager path;

    private int currentWaveIndex = 0;
    private bool isSpawning = false;

    // REMOVE the Start() method if you don't want it to auto-start anymore!
    
    void Update()
    {
        // Debugging the keypress
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Space bar pressed!"); // This will show in Console to confirm input works
            TryStartNextWave();
        }
    }

    public void TryStartNextWave()
    {
        if (currentWaveIndex < waves.Count && !isSpawning)
        {
            StartCoroutine(SpawnWave());
        }
        else if (currentWaveIndex >= waves.Count)
        {
            Debug.Log("No more waves left!");
        }
    }

    IEnumerator SpawnWave()
    {
        isSpawning = true;
        WaveContent currentWave = waves[currentWaveIndex];
        Debug.Log($"<color=cyan>Spawning Wave {currentWaveIndex + 1}</color>");

        for (int i = 0; i < currentWave.count; i++)
        {
            GameObject enemyGO = Instantiate(currentWave.enemyType.prefab, spawnPoint.position, Quaternion.identity);
            
            EnemyMovement moveScript = enemyGO.GetComponent<EnemyMovement>();
            if (moveScript != null)
            {
                moveScript.pathManager = path;
                moveScript.data = currentWave.enemyType;
            }

            yield return new WaitForSeconds(currentWave.spawnRate);
        }

        currentWaveIndex++;
        isSpawning = false;
        Debug.Log("<color=green>Wave Finished Spawning.</color> Press Space for next wave.");
    }
}