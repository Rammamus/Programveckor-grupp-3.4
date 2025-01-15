using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerCombat : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    Animator animator;

    [Header("Attack Related")]
    public float attackDamage;
    public float attackSpeed;
    public string weaponType;
    public bool isAttacking;

    [Header("HP Related")]
    public float hp;
    public float maxHP;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isAttacking)
        {
            StartAttack(weaponType, "up", 5);
        }
        Debug.Log("Current State: " + animator.GetCurrentAnimatorStateInfo(0).IsName("Player AttackUp"));

        if (isAttacking && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Player AttackUp"))
        {
            animator.SetBool("isAttackingUp", false);
            StopAttack();
        }
    }

    public void StartAttack(string weaponType, string direction, float dmg)
    {
        if (direction == "up")
        {
            animator.SetBool("isAttackingUp", true);
        }
    }

    public void StopAttack()
    {
        animator.SetBool("isAttackingUp", false);
        isAttacking = false;
        print("stop attack");
    }

    public void PlayerTakeDMG(float dmg)
    {
        OnPlayerDamaged?.Invoke();
        HealthBarScript.FindObjectOfType<HealthBarScript>().DrawHearts();
        hp -= dmg;
    }
}