using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //問題番号
    public static int quizNum;

    //スコア
    public static int score;

    //問題の正解
    [SerializeField]
    private string[] answerWord;

    public static bool isNextQuiz = true; //次の問題にいけるか

    public static bool isGameEnd = false; //エンドシーンにいくか

    void Start()
    {
        score = 0;
        quizNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Button.isButton){
            //ボタンが押されたら答えがあっているかチェック
            checkButtonWordAndAnswerWord(Button.selectButtonText.text);

            Button.isButton = false;
        }

        if(quizNum >= 10){
            //10問目を終えたらエンドシーンへ
            isGameEnd = true;
        }
        
    }

    //ボタンの選択肢と正解のワードが一致しているか
    void checkButtonWordAndAnswerWord(string buttonText)
    {
        //一致していたら正解処理
        if(buttonText == answerWord[quizNum]){
            //正解処理
            quizNum++; //問題番号を１増やす
            score += 10; //スコア１０加算
            isNextQuiz = true; //次の問題へ
        }
        else{
            //不正解ならスコア加算せずに次の問題へ
            quizNum++; //問題番号を１増やす
            isNextQuiz = true;
        }
    }
}
