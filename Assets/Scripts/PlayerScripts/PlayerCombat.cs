using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerCombat : MonoBehaviour
{
    EntityFlash flashEffect;
    public static event Action OnPlayerDamaged;
    Animator animator;
    SpriteRenderer sprite;

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
        flashEffect = GetComponent<EntityFlash>();
        sprite = GetComponent<SpriteRenderer>();
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
            sprite.flipX = true;
            animator.SetBool("isAttackingSide", true);
        }
        if (direction == "right")
        {
            sprite.flipX = false;
            animator.SetBool("isAttackingSide", true);
        }
        if (direction == "down")
        {
            animator.SetBool("isAttackingDown", true);
        }
    }

    public void StopAttack()
    {
        animator.SetBool("isAttackingUp", false);
        animator.SetBool("isAttackingSide", false);
        animator.SetBool("isAttackingSide", false);
        animator.SetBool("isAttackingDown", false);
        isAttacking = false;
    }

    public void PlayerTakeDMG(float dmg)
    {
        OnPlayerDamaged?.Invoke();
        HealthBarScript.FindObjectOfType<HealthBarScript>().DrawHearts();
        hp -= dmg;

        string hexColor = "#FF3939";
        if (ColorUtility.TryParseHtmlString(hexColor, out Color color))
        {
            flashEffect.Flash(color);
        }
    }
}