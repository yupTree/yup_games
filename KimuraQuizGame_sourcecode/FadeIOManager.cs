using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeIOManager : MonoBehaviour
{
    [SerializeField] float fadeTime;

    public static FadeIOManager instance;

    

    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public CanvasGroup canvasGroup;

    //フェードアウト
    public void FadeOut()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, fadeTime).OnComplete( () => canvasGroup.blocksRaycasts = false);
    }

    //フェードイン
    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(0, fadeTime).OnComplete( () => canvasGroup.blocksRaycasts = false);
    }

    //フェードアウトしてフェードインする
    public void FadeOutToIn(TweenCallback action)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, fadeTime).OnComplete( () => {action(); FadeIn();});
    }
}
