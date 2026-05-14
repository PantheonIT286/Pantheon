using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [Header("Stats")]
    public float range = 10f;
    public float fireRate = 1f;

    [Header("References")]
    public Transform firePoint;
    public GameObject projectilePrefab;

    private float fireCooldown = 0f;
    private Transform currentTarget;

    void Update()
    {
        FindTarget();

        if (currentTarget == null)
            return;

        RotateTowardsTarget();

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity;
        Transform nearest = null;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);

            if (dist < shortestDistance && dist <= range)
            {
                shortestDistance = dist;
                nearest = enemy.transform;
            }
        }

        currentTarget = nearest;
    }

    void RotateTowardsTarget()
    {
        Vector3 dir = currentTarget.position - transform.position;
        dir.y = 0f;

        Quaternion lookRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * 5f);
    }

    void Shoot()
    {
        if (projectilePrefab == null || firePoint == null) return;

        GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Projectile projectile = proj.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.SetTarget(currentTarget);
        }
    }
}