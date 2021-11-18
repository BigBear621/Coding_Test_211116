using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    public Stack<GameObject> itemStack;
    public Dictionary<GameObject, Boost> itemEffect;

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

    public void Func()
    {

    }
}
