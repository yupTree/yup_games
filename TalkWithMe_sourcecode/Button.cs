using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public static Text selectButtonText; //押したボタンのテキスト取得

    public static bool canClick = true;

    public void OnClickTitleStartButton()
    {
        LoadSceneManager.instance.LoadExplanationScene();
    }

    //遊び方画面でのスタートボタン
    public void OnClickGameStartButton()
    {
        LoadSceneManager.instance.LoadGameScene();
    }

    public void OnClickToTitleButton()
    {
        LoadSceneManager.instance.LoadTitleScene();
    }

    //会話画面での選択肢ボタン
    public void OnClickSelectButton()
    {
        if(canClick){
            selectButtonText = GetComponentInChildren<Text>();
            canClick = false; //クリックしたら次の問題表示されるまでクリックできないようにする
            GameManager.instance.SetFPPoint(selectButtonText.text); //ボタン押したらテキスト内容によってFPポイント変える
            GameManager.instance.isNextQ = true; //クリックしたら次の問題へ行ける
        }
    }
}
