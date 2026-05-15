using UnityEngine;
using TMPro;

public class CastleHealth : MonoBehaviour{
    // castle initial health
    public int health = 100;

    // Text component to display castle health
    public TextMeshProUGUI healthText;

    private void OnCollisionEnter(Collision collision){
        // reduces castle health if an enemy collides with it
        if (collision.gameObject.CompareTag("Enemy")){
            // determines how much damage the enemy does to the castle
            EnemyData enemyData = collision.gameObject.GetComponent<EnemyMovement>().data;
            health -= enemyData.castleDamage;
            
            // checks if the castle health has dropped to 0 or below, and if so, triggers game over
            if (health <= 0){
                healthText.text = "0";
            } else{
                healthText.text = health.ToString();
            }
        } 
    }
}
