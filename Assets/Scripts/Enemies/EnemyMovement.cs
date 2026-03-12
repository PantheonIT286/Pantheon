using UnityEngine;

/*
Purpose of this script is to have the enemy move around the level by moving from one checkpoint to
the next. When it reaches the end it will call the Die() function which tells the EconomyManager to
add gold. Right now since there's no way of killing enemies, when it reaches the end it will act
like it's been "killed" and drop the gold. That part needs to be updated to account for towers killing enemies,
and not award gold if an enemy reaches the end.
*/

public class EnemyMovement : MonoBehaviour
{
    public EnemyData data;
    private float currentSpeed;
    private int currentHealth;

    public PathManager pathManager;
    public float moveSpeed = 5f;

    private int waypointIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    //When the enemy dies, have it udpate the Gold Variable.
    void Die()
    {
        EconomyManager economy = Object.FindFirstObjectByType<EconomyManager>();

        if (economy != null)
        {
            economy.AddGold(data.goldReward);
        }

        Destroy(gameObject);
    }
    
    void Start()
    {
        //Initial Variables
        currentSpeed = data.speed;
        currentHealth = data.health;

        //Makes sure enemies don't spawn underground
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 2f, Vector3.down, out hit, 10f))
        {

            float groundedY = hit.point.y;

            transform.position = new Vector3(transform.position.x, groundedY, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex < pathManager.points.Length)
        {
            Vector3 targetPos = pathManager.points[waypointIndex].position;

            targetPos.y = transform.position.y;
            
            //Move towards target checkpoint
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                currentSpeed * Time.deltaTime
            );

            //Check if enemy has arrived at destination
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                waypointIndex++;
            }
        }
        else
        {
            //Call the Die Function.
            Die();
        }
    }
}
