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
    public float attackPower;
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
        if (Input.GetKeyDown(KeyCode.W) && !isAttacking)
        {
            StartAttack(weaponType, "up", attackPower);
        }
        if (Input.GetKeyDown(KeyCode.A) && !isAttacking)
        {
            StartAttack(weaponType, "left", attackPower);
        }
        if (Input.GetKeyDown(KeyCode.D) && !isAttacking)
        {
            StartAttack(weaponType, "right", attackPower);
        }
        if (Input.GetKeyDown(KeyCode.S) && !isAttacking)
        {
            StartAttack(weaponType, "down", attackPower);
        }

    }

    public void StartAttack(string weaponType, string direction, float dmg)
    {
        isAttacking = true;
        if (direction == "up")
        {
            animator.SetBool("isAttackingUp", true);
        }
        if (direction == "left")
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