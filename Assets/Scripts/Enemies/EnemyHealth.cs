using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Enemy took damage: " + amount + " | Remaining: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Enemy died");


        EnemyData enemyData = GetComponent<EnemyMovement>().data;
        GameObject economy = GameObject.FindWithTag("Economy");
        EconomyManager economyManager = economy.GetComponent<EconomyManager>();
            if (economyManager != null)
            {
                economyManager.AddGold(enemyData.goldReward);
            }

        Destroy(gameObject);
    }
}