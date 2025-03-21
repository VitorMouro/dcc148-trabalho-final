using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class EnemyController : MonoBehaviour
{
    public GameObject grid;
    private Vector3 currentTarget;
    private NavMeshAgent agent;

    public PlayerController playerRef;

  

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        newTarget();
    }

    void Update()
    {
        

        float dist =  Vector3.Distance(transform.position, currentTarget); 
        if (dist < 1.0f)
            newTarget();
    }

    private void newTarget()
    {
        // Choose random child
        Transform randomChild = grid.transform.GetChild(Random.Range(0, grid.transform.childCount));
        currentTarget = randomChild.position;
        agent.SetDestination(currentTarget);
    }

    void OnCollisionEnter(Collision colision)
    { 
        if(colision.gameObject.CompareTag("Player")){
            playerRef.anotherOneBitesTheDust();
            gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
