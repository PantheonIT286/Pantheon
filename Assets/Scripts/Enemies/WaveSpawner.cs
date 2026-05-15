using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyGroup
    {
        public EnemyData enemyType;
        public int count;
        public float spawnRate;
    }

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
    }

    [Header("Setup References")]
    public List<Wave> waves;
    public Transform spawnPoint;
    public PathManager path;

    public TextMeshProUGUI waveInfo; // UI text component to display wave information.
    private int currentWaveIndex = 0;
    private bool isSpawning = false;

    public PauseManager pauseManager; // Reference to the PauseMenu script to check the current pause status.

    IEnumerator SpawnWave()
    {
        isSpawning = true;
        Wave currentWave = waves[currentWaveIndex];

        Debug.Log($"<color=cyan>Wave Manager:</color> Starting {currentWave.waveName}");
        if (waveInfo != null)
            waveInfo.text = currentWave.waveName;

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

            yield return new WaitForSeconds(1.0f);
        }

        currentWaveIndex++;
        isSpawning = false;

        Debug.Log("<color=green>Wave Manager:</color> Wave complete.");
        if (waveInfo != null)
            waveInfo.text = "Wave Clear";
        pauseManager.setPause(); // Set sprite to pause when starting the wave.
    }

    // This function can be called by a UI button to start the wave.    
    public void startWave()
    {
        if (!isSpawning)
        {
            Debug.Log("Button Pressed.");
            pauseManager.setResume(); // Set sprite to resume when starting the wave.
            StartCoroutine(SpawnWave());
        }
    }

    // This function can be called by a UI button to check if the wave is currently spawning.
    public bool IsSpawning()
    {
        return isSpawning;
    }

    public int getCurrentWaveIndex(){
        return currentWaveIndex;
    }
}