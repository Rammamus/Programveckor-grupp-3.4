using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    Vector2 lastClickedPos;
    bool isMoving;
    bool mouseDown;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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

        if (mouseDown)
        {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }

        if (isMoving && (Vector2)transform.position != lastClickedPos)
        {
            float step = speed * Time.deltaTime;
            agent.SetDestination(lastClickedPos);
        }
        else
        {
            isMoving = false;
        }
    }
}
