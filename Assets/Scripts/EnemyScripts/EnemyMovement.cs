using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;

    public NavMeshAgent agent;
    GameObject player;
    public bool canSeePlayer;
    public bool canMove;
    float sightDistance = 8;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        canMove = true;
    }

    private void Update()
    {
        if (canSeePlayer && canMove)
        {
            agent.SetDestination(target.position);
        }
    }

    private void FixedUpdate()
    {
        //Sends raycast towards player - Adrian
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position, sightDistance);
        if (ray.collider != null)
        {
            canSeePlayer = ray.collider.CompareTag("Player"); //If it hit player, it can see player - Adrian
            if (canSeePlayer)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }
}
