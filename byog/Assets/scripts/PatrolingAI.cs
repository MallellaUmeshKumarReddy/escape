using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class PatrolingAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    // Patrolling
    Vector3 destPoint;
    bool walkPointSet;
    [SerializeField] float walkRange;
    [SerializeField] float agentSpeed = 3.0f; // Adjust this speed as needed

    //state change
    [SerializeField] float sightRange;
    bool playerInSight;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");

        // Set the agent's speed
        agent.speed = agentSpeed;

        // Call the initial destination point setup
        SearchForDestination();
    }

    void Update()
    {
       
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);

        // Call the patrol logic
        if(!playerInSight)
            Patrol();

        //call chase method
        if(playerInSight)
            chase();
    }

    void chase()
    {
        agent.SetDestination(player.transform.position);
    }
    void Patrol()
    {
        // If a destination point is not set, find a new one
        if (!walkPointSet) SearchForDestination();


        // If a destination point is set, move towards it
        if (walkPointSet) agent.SetDestination(destPoint);


        // Make the agent face the destination point
        //transform.LookAt(destPoint);

        // Check if the agent is close to the destination point
        if (Vector3.Distance(transform.position, destPoint) < 1) walkPointSet = false; 
            
    }

    void SearchForDestination()
    {
        
        float z = Random.Range(-walkRange, walkRange);
        float x = Random.Range(-walkRange, walkRange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        // Check if the destination point is on the ground
        //RaycastHit hit;
        if (Physics.Raycast(destPoint, Vector3.down,  groundLayer))
        {
            walkPointSet = true;
           // Debug.Log("ashv");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject);
            SceneManager.LoadScene(2);
        }
    }


}
