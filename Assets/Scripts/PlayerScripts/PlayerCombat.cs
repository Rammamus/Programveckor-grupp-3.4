using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerCombat : MonoBehaviour
{
    public static event Action OnPlayerDamaged;

    [Header("Attack Related")]
    public float attackDamage;
    public float attackSpeed;

    [Header("HP Related")]
    public float hp;
    public float maxHP;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackEnemy(EnemyCombat enemy, float dmg)
    {
        
    }

    public void PlayerTakeDMG()
    {
        OnPlayerDamaged?.Invoke();
    }
}