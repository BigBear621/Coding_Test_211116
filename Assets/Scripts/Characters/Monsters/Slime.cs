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
        def = 5;
        maxCloneHp = 50;
        hpEvent += delegate { if (Hp < maxHp / 2 && Hp >= maxCloneHp) Clone(); };
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

    public override void Die()
    {
        base.Die();
    }
}
