using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyData data;
    private float currentSpeed;
    private int currentHealth;

    public PathManager pathManager;
    private int waypointIndex = 0;

    // Diverging Path Variables
    private Transform targetTower;
    private bool isAttacking = false;
    private float nextCheckTime;

    void Start()
    {
        currentSpeed = data.speed;
        currentHealth = data.health;

        // Grounding Raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 2f, Vector3.down, out hit, 10f))
        {
            float groundedY = hit.point.y;
            transform.position = new Vector3(transform.position.x, groundedY, transform.position.z);
        }
    }

    void Update()
    {
        if (isAttacking)
        {
            MoveTowardsTower();
        }
        else
        {
            // 1. Look for towers if it's time to check
            CheckForNearbyTowers();

            // 2. Original Path Following Logic
            if (waypointIndex < pathManager.points.Length)
            {
                Vector3 targetPos = pathManager.points[waypointIndex].position;
                targetPos.y = transform.position.y;

                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetPos,
                    currentSpeed * Time.deltaTime
                );

                if (Vector3.Distance(transform.position, targetPos) < 0.1f)
                {
                    waypointIndex++;
                }
            }
            else
            {
                // Reached the end: No gold awarded for escaping!
                Die(false); 
            }
        }
    }

    void CheckForNearbyTowers()
    {
        if (Time.time < nextCheckTime) return;
        nextCheckTime = Time.time + 1f; // Check once per second

        // Roll for aggression based on EnemyData
        if (Random.value > data.aggressionChance) return;

        string[] tagsToFind = { "Tower1", "Tower2", "Tower3", "Tower4"};
        List<GameObject> towers = new List<GameObject>();
        foreach (string tag in tagsToFind){
            towers.AddRange(GameObject.FindGameObjectsWithTag(tag));
        }
        
        foreach (GameObject tower in towers)
        {
            float dist = Vector3.Distance(transform.position, tower.transform.position);
            if (dist <= data.detectionRadius)
            {
                targetTower = tower.transform;
                isAttacking = true;
                break;
            }
        }
    }

    void MoveTowardsTower()
    {
        if (targetTower == null)
        {
            isAttacking = false;
            return;
        }

        Vector3 dir = targetTower.position - transform.position;
        dir.y = 0; // Keep them on the ground
        transform.position = Vector3.MoveTowards(transform.position, targetTower.position, currentSpeed * Time.deltaTime);

        // Placeholder for attacking logic
        if (Vector3.Distance(transform.position, targetTower.position) < 0.5f)
        {
            Debug.Log($"{data.enemyName} is attacking the tower!");
        }
    }

    // Updated Die function to handle gold rewards properly
    public void Die(bool giveGold)
    {
        if (giveGold)
        {
            GameObject economy = GameObject.FindWithTag("Economy");
            EconomyManager economyManager = economy.GetComponent<EconomyManager>();
            if (economyManager != null)
            {
                economyManager.AddGold(data.goldReward);
            }
        }

        Destroy(gameObject);
    }
}