using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool<T> : MonoBehaviour where T : Monster
{
    public List<T> monsterList = new List<T>();
    public Queue<GameObject> monsterQueue = new Queue<GameObject>();
    [Range(5, 100)]
    public int poolSize = 50;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObject = new GameObject("---");
            newObject.AddComponent<T>();
            monsterQueue.Enqueue(newObject);
        }
    }

    public void ShowList()
    {
        for (int i = 0; i < monsterList.Count; i++)
            Debug.Log(monsterList[i]);
    }

    public void ShowQueue()
    {
        Debug.Log(monsterQueue.Count);
    }
}
