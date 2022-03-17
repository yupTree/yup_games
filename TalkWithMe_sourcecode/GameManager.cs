using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int qNumber = 0; //質問番号

    public bool isNextQ = false; //次の質問を表示するかどうか

    private bool isEnd = false; //エンディングに行くかどうか

    [SerializeField]
    private int questions; //問題数

    private int fpPoint = 0; //選択肢に応じたポイント

    private int score = 0; //スコア累計

    public int QNumber
    {
        get
        {
            return qNumber;
        }
        set
        {
            qNumber = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    void Update()
    {
        //エンドフラグ立ってたらゲーム終了処理
        if(isEnd && !Button.canClick){
            Debug.Log("Endへ");
            isEnd = false;
            Invoke("GameEnd", 1.0f);
        }

        if(isNextQ){
            if(QNumber == 0){ //最初の質問をセット
                Display();
            }
            else{
                Invoke("Display", 1.5f);
            }
            isNextQ = false;
        }
    }

    //選択肢ボタンを押したら次の質問の準備処理
    void Display()
    {   
        UIManager.instance.SetQandA(QNumber); 
        Button.canClick = true; //問題表示されたら選択肢クリックできる
        QNumber++;
        if(QNumber >= questions){ //次で最後の質問であるとき、ゲーム終了フラグたてる
            isEnd = true;
            isNextQ = false;
        }
    }

    //ゲーム終了処理
    public void GameEnd()
    {
        LoadSceneManager.instance.LoadEndScene();
    }

    //ボタンの選択肢によってポイント変える
    public void SetFPPoint(string buttonText)
    {
        List<string[]> selectTextDatas = new List<string[]>();
        selectTextDatas = FileRead.instance.GetCsvFile;

        if(buttonText == selectTextDatas[QNumber-1][2]){
            fpPoint = int.Parse(selectTextDatas[QNumber-1][6]);
        }
        else if(buttonText == selectTextDatas[QNumber-1][3]){
            fpPoint = int.Parse(selectTextDatas[QNumber-1][7]);
        }
        else if(buttonText == selectTextDatas[QNumber-1][4]){
            fpPoint = int.Parse(selectTextDatas[QNumber-1][8]);
        }
        else if(buttonText == selectTextDatas[QNumber-1][5]){
            fpPoint = int.Parse(selectTextDatas[QNumber-1][9]);
        }
        
        ChangeImage.instance.ChangeSprite(fpPoint); //選んだ選択肢によって表情変える

        score += fpPoint; //今のスコアに加算
    }
}
