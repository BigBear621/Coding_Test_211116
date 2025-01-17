using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster, IAttackFunc
{
    public int atk;

    void Start()
    {
        maxHp = 50;
        Hp = maxHp;
        atk = 5;
        def = 10;
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
