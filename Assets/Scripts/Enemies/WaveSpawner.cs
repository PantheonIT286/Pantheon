using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyGroup // This defines a specific "batch" of enemies
    {
        public EnemyData enemyType;
        public int count;
        public float spawnRate;
    }

    [System.Serializable]
    public class Wave // This defines a collection of batches
    {
        public string waveName; // Useful for organization
        public List<EnemyGroup> enemyGroups;
    }

    [Header("Setup References")]
    public List<Wave> waves; 
    public Transform spawnPoint;
    public PathManager path;

    private int currentWaveIndex = 0;
    private bool isSpawning = false;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && !isSpawning)
        {
            Debug.Log("Space Bar Pressed.");
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        isSpawning = true;
        Wave currentWave = waves[currentWaveIndex];
        Debug.Log($"<color=cyan>Wave Manager:</color> Starting {currentWave.waveName}");

        // Now we loop through each GROUP in the wave
        foreach (EnemyGroup group in currentWave.enemyGroups)
        {
            for (int i = 0; i < group.count; i++)
            {
                if (group.enemyType.prefab == null) yield break;

                GameObject enemyGO = Instantiate(group.enemyType.prefab, spawnPoint.position, Quaternion.identity);
                
                EnemyMovement moveScript = enemyGO.GetComponent<EnemyMovement>();
                if (moveScript != null)
                {
                    moveScript.pathManager = path;
                    moveScript.data = group.enemyType;
                }

                yield return new WaitForSeconds(group.spawnRate);
            }
            
            // Optional: Wait a second or two between different types of enemies
            yield return new WaitForSeconds(1.0f); 
        }

        currentWaveIndex++;
        isSpawning = false;
        Debug.Log("<color=green>Wave Manager:</color> Wave complete.");
    }
}
