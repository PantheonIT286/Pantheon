using UnityEngine;
using UnityEngine.InputSystem;

public class DamageTester : MonoBehaviour
{
    public int damageAmount = 10;

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            DamageAllEnemies();
        }
    }

    void DamageAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();

            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }

        Debug.Log("Damaged all enemies for: " + damageAmount);
    }
}