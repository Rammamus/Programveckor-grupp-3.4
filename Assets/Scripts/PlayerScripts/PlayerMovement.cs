using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    Vector2 lastClickedPos;
    bool isMoving;
    bool mouseDown;
    public bool isDashing;
    public bool canDash;
    public float dashCooldown;
    public float dashSpeed;
    float dashTimer;

    [SerializeField] GameObject moveCursor;
    NavMeshAgent agent;
    Animator animator;
    SpriteRenderer playerSprite;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        dashTimer = dashCooldown;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            mouseDown = true;

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Instantiate(moveCursor, worldPosition, Quaternion.identity);
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

        if (dashTimer < dashCooldown)
        {
            dashTimer += Time.deltaTime;
            canDash = false;
        }
        else if (dashTimer >= dashCooldown)
        {
            canDash = true;
        }
        
        if (Input.GetKeyDown(KeyCode.F) && canDash)
        {
            isDashing = true;
            StartDash();
        }

        if (GetComponent<PlayerCombat>().isAttacking == true)
        {
            agent.isStopped = true;
            isMoving = false;
        }

        if (isDashing)
        {
            agent.SetDestination(transform.position);
            if (rb.velocity.x < 0)
            {
                playerSprite.flipX = true;
            }
            else if (rb.velocity.x > 0)
            {
                playerSprite.flipX = false;
            }
        }
        
        if (isMoving && (Vector2)transform.position != lastClickedPos)
        {
            agent.isStopped = false;
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

    public void StartDash()
    {
        agent.isStopped = true;
        agent.velocity = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);
        isDashing = true;
        isMoving = false;
        animator.SetBool("isDashing", true);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector2 dashDirection = (mousePosition - transform.position).normalized;
        rb.velocity = dashDirection * dashSpeed;
    }

    public void EndDash()
    {
        isDashing = false;
        rb.velocity = new Vector2(0, 0);
        dashTimer = 0;
        lastClickedPos = (Vector2)transform.position;
        animator.SetBool("isDashing", false);
        agent.isStopped = false;
    }
}
