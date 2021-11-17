using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boost<T> : MonoBehaviour
{
    public Action<Player, int> boostAction;

    public void HpBoost(Player player, int value)
    {
        player.Hp += value;
    }

    public void AtkBoost(Player player, int value)
    {
        player.atk += value;
    }

    public void DefBoost(Player player, int value)
    {
        player.def += value;
    }

    void Start()
    {
        boostAction += HpBoost;
        boostAction += AtkBoost;
        boostAction += DefBoost;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
            other.GetComponent<Player>().Heal(boostAction);
    }
}
