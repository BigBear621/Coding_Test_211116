using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster, IAttackFunc
{
    int atk;
    int def;

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
        this.gameObject.SetActive(false);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
            Attack(other.GetComponent<Player>());
    }
}
