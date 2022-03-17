using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneUIManager : MonoBehaviour
{
    public static EndSceneUIManager instance;

    [SerializeField]
    private Text hintText;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private string[] scoreComment;  //スコアによるサブコメントはunity上で設定

    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        SetScoreText(GameManager.instance.Score);
    }

    //ファイル読み込んでヒントテキストに設定
    public void SetHintText(int num)
    {
        List<string[]> hintTextDatas = new List<string[]>();
        hintTextDatas = EndSceneFileRead.instance.GetCsvEndFile;

        hintText.text = hintTextDatas[num][1];
    }

    //選んできた選択肢によってサブコメント設定
    void SetScoreText(int score)
    {
        if(0 <= score && score <= 5){
            scoreText.text = scoreComment[0];
        }
        else if(score <= 15){
            scoreText.text = scoreComment[1];
        }
        else if(score <= 25){
            scoreText.text = scoreComment[2];
        }
        else if(score <= 30){
            scoreText.text = scoreComment[3];
        }
    }
}
