using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public delegate void Die();
    public Die dieEvent;
    [HideInInspector]
    public Button button;
    [HideInInspector]
    public AsyncOperation asyncOperation;

    void Start()
    {
        dieEvent += () => Debug.Log("Á×À½");
        dieEvent += () =>
        {
            Player.animator.SetBool("isDying", true);
            StartCoroutine(CountDown());
        };
    }

    public IEnumerator CountDown()
    {
        for (int i = 5; i > 0; i--)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }
        LoadLastScene();
    }

    public void LoadLastScene()
    {
        asyncOperation = SceneManager.LoadSceneAsync("LastScene");
        if (asyncOperation.isDone)
        {
            //button = FindObjectOfType<Button>();
            button = transform.parent.Find("Revive").GetComponent<Button>();
            button.onClick.AddListener(delegate { Debug.Log("´©¸§"); Revive(); });
        }
    }
    
    public void Revive()
    {
        SceneManager.LoadScene("FirstScene");
    }
}
