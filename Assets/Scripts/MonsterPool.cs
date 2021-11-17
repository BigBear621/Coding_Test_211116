using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    List<Monster> monsterPool;
    private void Start()
    {
        monsterPool = new List<Monster>();
    }
}
