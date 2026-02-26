using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public PathManager pathManager;
    public float moveSpeed = 5f;

    private int waypointIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                moveSpeed * Time.deltaTime
            );

            //Check if enemy has arrived at destination
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                waypointIndex++;
            }
        }
        else
        {
            //Destroy Enemy at the End
            Destroy(gameObject);
        }
    }
}
