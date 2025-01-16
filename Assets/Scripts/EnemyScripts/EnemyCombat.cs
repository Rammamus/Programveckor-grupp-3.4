using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("Attack Related")]
    public float attackDMG;
    public float attackSpeed;
    float attackSpeedTimer;
    public float attackRange;
    public bool inAttkRange;
    public bool isAttacking;

    [Header("HP Related")]
    public float hp;
    public float maxHP;

    EntityFlash flashEffect;
    public PlayerCombat player;
    public Animator animator;
    EnemyMovement enemyMovement;

    // Start is called before the first frame update
    public virtual void Start()
    {
        flashEffect = GetComponent<EntityFlash>();
        enemyMovement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();
        attackSpeedTimer = attackSpeed;
        hp = maxHP;
        player = FindObjectOfType<PlayerCombat>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (inAttkRange && attackSpeedTimer >= attackSpeed)
        {
            StartAttack(attackDMG);
            attackSpeedTimer = 0;
        }

        if (attackSpeedTimer < attackSpeed)
        {
            attackSpeedTimer += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (inAttkRange)
        {
            gameObject.GetComponent<EnemyMovement>().canMove = false;
            GetComponent<EnemyMovement>().agent.SetDestination(transform.position);
        }
        else
        {
            gameObject.GetComponent<EnemyMovement>().canMove = true;
        }

        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position, attackRange);
        if (ray.collider != null)
        {
            inAttkRange = ray.collider.CompareTag("Player");
            if (inAttkRange)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
        else
        {
            inAttkRange = false;
        }
    }

    public virtual void StartAttack(float dmg)
    {
        isAttacking = true;
        animator.SetBool("isAttacking", true);
    }

    public virtual void StopAttack()
    {
        isAttacking = false;
        animator.SetBool("isAttacking", false);
    }

    public virtual void TakeDamage(float damage)
    {
        hp -= damage;
        flashEffect.Flash(Color.white);
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            TakeDamage(player.attackPower);

        }
    }
}
