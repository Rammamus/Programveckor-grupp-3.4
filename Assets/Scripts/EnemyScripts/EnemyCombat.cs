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

    [Header("HP Related")]
    public float hp;
    public float maxHP;

    public PlayerCombat player;

    // Start is called before the first frame update
    public virtual void Start()
    {
        attackSpeedTimer = attackSpeed;
        hp = maxHP;
        player = FindObjectOfType<PlayerCombat>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (inAttkRange && attackSpeedTimer >= attackSpeed)
        {
            AttackPlayer(attackDMG);
            attackSpeedTimer = 0;
        }

        if (attackSpeedTimer < attackSpeed)
        {
            attackSpeedTimer += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
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

    public virtual void AttackPlayer(float dmg)
    {

    }
}
