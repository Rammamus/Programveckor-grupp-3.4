using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;

    SpriteRenderer sprite;
    EnemyCombat enemyCombat;
    public NavMeshAgent agent;
    GameObject player;
    public bool canSeePlayer;
    public bool canMove;
    float sightDistance = 8;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemyCombat = GetComponent<EnemyCombat>();
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        canMove = true;
    }

    private void Update()
    {
        if (enemyCombat.isAttacking)
        {
            agent.SetDestination(transform.position);
        }
        else if (canSeePlayer && canMove)
        {
            agent.SetDestination(target.position);
            if (agent.velocity.x > 0)
            {
                sprite.flipX = true;
            }
            if (agent.velocity.x < 0)
            {
                sprite.flipX = false;
            }
        }
    }

    private void FixedUpdate()
    {
        //Sends raycast towards player - Adrian
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position, sightDistance);
        if (ray.collider != null)
        {
            canSeePlayer = ray.collider.CompareTag("Player"); //If it hit player, it can see player - Adrian
            if (canSeePlayer && !enemyCombat.isAttacking)
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
