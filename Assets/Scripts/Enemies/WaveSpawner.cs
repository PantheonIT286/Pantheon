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
<<<<<<< HEAD
        Debug.Log($"<color=cyan>Wave Manager:</color> Starting {currentWave.waveName}");
        waveInfo.text = currentWave.waveName;
=======
>>>>>>> Adreanna

        Debug.Log($"<color=cyan>Wave Manager:</color> Starting {currentWave.waveName}");
        if (waveInfo != null)
            waveInfo.text = "Starting " + currentWave.waveName;

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
            waveInfo.text = "Wave Complete";
    }
}