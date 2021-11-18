using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boost : MonoBehaviour
{
    public Action<Player, int> useBoost;
    public List<Action<Player, int>> boostList;

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
        boostList.Add(HpBoost);
        boostList.Add(AtkBoost);
        boostList.Add(DefBoost);
    }

    private void OnTriggerEnter(Collider other)
    {
        useBoost += boostList[UnityEngine.Random.Range(0, 3)];
        if (other.GetComponent<Player>() != null)
            other.GetComponent<Player>().GetBoost(useBoost);
    }
}
