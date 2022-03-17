using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;

    public bool DontDestroyEnabled = true;

    [SerializeField]
    private float waitTime; //シーン遷移時のインターバル

    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        if(DontDestroyEnabled){
            DontDestroyOnLoad(this);
        }
    }

    public void LoadExplanationScene()
    {
        StartCoroutine( Load("ExplanationScene") );
    }

    public void LoadGameScene()
    {
        StartCoroutine( Load("GameScene") );
    }

    public void LoadEndScene()
    {
        StartCoroutine( Load("EndScene") );
    }

    public void LoadTitleScene()
    {
        StartCoroutine( Load("Title") );
    }

    IEnumerator Load(string LoadSceneName)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(LoadSceneName);
    }
}
