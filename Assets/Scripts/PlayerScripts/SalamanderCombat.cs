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

    public override void AttackPlayer(float dmg)
    {
        base.AttackPlayer(dmg);
        player.hp -= dmg;
    }
}
