using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalamanderCombat : EnemyCombat
{
    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (gameObject.GetComponent<EnemyMovement>().agent.velocity.x != 0 || gameObject.GetComponent<EnemyMovement>().agent.velocity.y != 0)
        {
            animator.SetFloat("Velocity", 1);
        }
        else
        {
            animator.SetFloat("Velocity", 0);
        }
    }

    public override void StartAttack(float dmg)
    {
        base.StartAttack(dmg);
        player.PlayerTakeDMG(attackDMG);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (hp <= 0)
        {
            animator.Play("Salamander Die");
        }
    }
}
