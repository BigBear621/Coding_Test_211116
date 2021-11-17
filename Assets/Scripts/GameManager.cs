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
        dieEvent += delegate { StartCoroutine(AnimateDyingMotion()); };
        dieEvent += LoadLastScene;
    }

    public IEnumerator AnimateDyingMotion()
    {
        Player.animator.SetBool("isDying", true);
        asyncOperation = SceneManager.LoadSceneAsync("LastScene");
        yield return new WaitForSeconds(3);
    }

    public void LoadLastScene()
    {
        if (asyncOperation.isDone)
            asyncOperation.allowSceneActivation = true;
        button = FindObjectOfType<Button>();
        button.onClick.AddListener(delegate { Revive(); });
    }
    
    public void Revive()
    {
        SceneManager.LoadScene("FirstScene");
    }
}
