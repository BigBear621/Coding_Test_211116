using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Monster, IAttackFunc
{
    public int atk;

    void Start()
    {
        maxHp = 9999999;
        Hp = maxHp;
        atk = 999;
        def = 999;
    }

    public void Attack(Character target)
    {
        target.Hit(atk);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
            Attack(other.GetComponent<Player>());
    }

    public override void Die()
    {
        base.Die();
    }
}
