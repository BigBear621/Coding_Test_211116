using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item<T> : MonoBehaviour
{
    public Stack<Item<T>> itemStack;
    public Dictionary<Item<T>, Boost<T>> itemEffect;
    public delegate void UseItem();
    public UseItem useItem;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            useItem();
        }
    }

    public void Func() { }
}
