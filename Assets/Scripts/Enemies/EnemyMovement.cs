using UnityEngine;

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
    public void Die()
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
