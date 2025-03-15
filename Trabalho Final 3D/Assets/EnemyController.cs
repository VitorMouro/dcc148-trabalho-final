using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Vector3 currentTarget;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        newTarget();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, currentTarget) < 1.0f)
            newTarget();
        // Draw a line to the target
        Debug.DrawLine(transform.position, currentTarget, Color.red);
    }

    private void newTarget()
    {
        currentTarget = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
        agent.SetDestination(currentTarget);
        Debug.Log("New target: " + currentTarget);
    }
}
