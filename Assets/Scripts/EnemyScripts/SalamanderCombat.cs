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
