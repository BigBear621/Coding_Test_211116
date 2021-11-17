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
            hpText.text = hp.ToString();
        }
    }

    public int damage;
    public TextMeshProUGUI hpText;

    public virtual void Hit(int _atk) { }

    public virtual void Die() { }

    public virtual void OnTriggerEnter(Collider other) { }
}
