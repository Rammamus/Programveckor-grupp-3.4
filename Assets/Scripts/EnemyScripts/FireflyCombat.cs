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
        if (inAttkRange)
        {
            gameObject.GetComponent<EnemyMovement>().canMove = false;
            GetComponent<EnemyMovement>().agent.SetDestination(transform.position);
        }
        else
        {
            gameObject.GetComponent<EnemyMovement>().canMove = true;
        }
    }

    public override void AttackPlayer(float dmg)
    {
        base.AttackPlayer(dmg);
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
