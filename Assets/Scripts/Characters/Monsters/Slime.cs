using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster, ICloneFunc
{
    int maxCloneHp;

    void Start()
    {
        maxHp = 100;
        Hp = maxHp;
        maxCloneHp = 50;
    }

    public void Clone()
    {
        this.maxHp = maxHp / 2;
        this.Hp = this.maxHp;

        Slime temp = new Slime();
        temp.maxHp = this.maxHp;
        temp.Hp = temp.maxHp;
        Instantiate(temp.gameObject);
    }

    public override void Hit(int _atk)
    {
        Hp -= _atk;
        if (Hp < maxHp / 2 && Hp >= maxCloneHp)
            Clone();
    }

    public override void Die()
    {
        this.gameObject.SetActive(false);
    }
}
