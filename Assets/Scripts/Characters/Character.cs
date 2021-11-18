using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public int maxHp;
    public int hp;
    public int Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp > maxHp)
                hp = maxHp;
            if (hp <= 0)
            {
                hp = 0;
                Die();
            }
            if (hpEvent != null)
                hpEvent();
            hpText.text = "HP : " + hp.ToString();
        }
    }
    public delegate void HpEvent();
    public HpEvent hpEvent;

    public int def;

    public int damage;
    public TextMeshProUGUI hpText;

    public void Hit(int _atk)
    {
        damage = -(def - _atk);
        if (damage <= 0)
        {
            damage = 0;
            Debug.Log(name + "에게 아무런 피해가 없었다!");
        }
        if (damage > 0)
        {
            Hp -= damage;
        }
    }

    public virtual void Die()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnTriggerEnter(Collider other) { }
}
