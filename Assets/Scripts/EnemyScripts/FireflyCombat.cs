using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyCombat : EnemyCombat
{
    [SerializeField] GameObject prefab;
    // Start is called before the first frame update
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
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (hp <= 0)
        {
            animator.Play("Firefly Die");
        }
    }
}
