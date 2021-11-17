using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IAttackFunc
{
    int atk;
    int def;

    public static Animator animator;

    void Start()
    {
        maxHp = 100;
        Hp = maxHp;
        atk = 10;
        def = 10;
    }

    public void Attack(Character target)
    {
        target.Hit(atk);
    }

    public override void Hit(int _atk)
    {
        damage = -(def - _atk);
        if (damage <= 0)
        {
            damage = 0;
            Debug.Log("아무런 피해가 없었다!");
        }
        if (damage > 0)
        {
            Hp -= damage;
        }
    }

    public override void Die()
    {
        GameManager.instance.dieEvent();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Monster>() != null)
            Attack(other.GetComponent<Monster>());
    }
}
