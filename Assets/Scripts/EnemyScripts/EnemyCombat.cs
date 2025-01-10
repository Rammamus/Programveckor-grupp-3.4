using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("Attack Related")]
    public float attackDMG;
    public float attackSpeed;
    public float attackSpeedTimer;
    public float attackRange;
    public bool isInRange;

    [Header("HP Related")]
    public float hp;
    public float maxHP;

    PlayerCombat player;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        player = FindObjectOfType<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && attackSpeedTimer >= attackSpeed)
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
            isInRange = ray.collider.CompareTag("Player");
            if (isInRange)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }

    public void AttackPlayer(float dmg)
    {
        player.hp -= dmg;
        Debug.Log("KABOOOM MEGA  ATTACK");
    }
}
