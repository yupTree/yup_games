using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    //押したボタンのテキスト取得
    public static Text selectButtonText;

    public static bool isButton = false; //ボタンが押された判定

    //答えのボタンを押したとき、次の問題に移る
    public void OnClickButtonAnswer()
    {
        //ボタンのテキスト取得
        selectButtonText = GetComponentInChildren<Text>();
        isButton = true;
        //Debug.Log(selectButtonText.text);
    }

    //Endシーンでタイトルに戻るときの処理
    public void OnClickButtonToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
