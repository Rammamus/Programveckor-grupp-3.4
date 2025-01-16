using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    Vector2 lastClickedPos;
    bool isMoving;
    bool mouseDown;

    NavMeshAgent agent;
    Animator animator;
    SpriteRenderer playerSprite;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            mouseDown = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            mouseDown = false;
        }

        else if (mouseDown)
        {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
            
        }

        if (GetComponent<PlayerCombat>().isAttacking == true)
        {
            agent.SetDestination(transform.position);
        }
        else if (isMoving && (Vector2)transform.position != lastClickedPos)
        {
            float step = speed * Time.deltaTime;
            agent.SetDestination(lastClickedPos);
            animator.SetFloat("xVelocity", 1);
            if (agent.velocity.x > 0)
            {
                playerSprite.flipX = false;
            }
            else if (agent.velocity.x < 0)
            {
                playerSprite.flipX = true;
            }
        }
        else
        {
            isMoving = false;
        }

        if (!isMoving)
        {
            animator.SetFloat("xVelocity", 0);
        }
    }
}
