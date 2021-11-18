using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : Character, IAttackFunc
{
    public int atk;

    public static Animator animator;

    void Start()
    {
        maxHp = 100;
        Hp = maxHp;
        atk = 15;
        def = 10;

        animator = GetComponent<Animator>();
    }

    public void Attack(Character target)
    {
        animator.SetBool("isAttacking", true);
        target.Hit(atk);
    }

    public override void Die()
    {
        GameManager.instance.dieEvent();
    }

    public void GetBoost(Action<Player, int> boost)
    {
        boost(this, 20);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Monster>() != null)
            Attack(other.GetComponent<Monster>());
    }
}
