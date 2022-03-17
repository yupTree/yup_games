using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Unity上から問題文入力
    [SerializeField, Header("問題文")]
    private string[] quizLine;

    //問題文を格納するText
    [SerializeField]
    private Text quizText;

    //Unity上から答えの選択肢を入力
    [SerializeField, Header("選択肢")]
    private string[] answerLine0, answerLine1, answerLine2, answerLine3, answerLine4, answerLine5, answerLine6, answerLine7, answerLine8, answerLine9;

    //選択肢ボタンのテキスト
    [SerializeField]
    private Text btText1, btText2, btText3, btText4;

    //スコア表示のテキスト
    [SerializeField]
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //ShowQuiz();
    }

    // Update is called once per frame
    void Update()
    {
        //ボタンが押されて次の問題に行く
       if(GameManager.isNextQuiz){
           ShowQuiz();
           GameManager.isNextQuiz = false;
       }
    }

    //問題を表示
    void ShowQuiz()
    {
        quizText.text = "Q" + (GameManager.quizNum+1) + ". " + quizLine[GameManager.quizNum]; //問題文表示
        scoreText.text = "SCORE:" + GameManager.score.ToString(); //スコア表示

        //答え
        switch(GameManager.quizNum){
            case 0 : AnswerEnter(answerLine0);
                     break;
            case 1 : AnswerEnter(answerLine1);
                     break;
            case 2 : AnswerEnter(answerLine2);
                     break;
            case 3 : AnswerEnter(answerLine3);
                     break;
            case 4 : AnswerEnter(answerLine4);
                     break;
            case 5 : AnswerEnter(answerLine5);
                     break;
            case 6 : AnswerEnter(answerLine6);
                     break;
            case 7 : AnswerEnter(answerLine7);
                     break;
            case 8 : AnswerEnter(answerLine8);
                     break;
            case 9 : AnswerEnter(answerLine9);
                     break;
        }
    }

    //選択肢に答えをランダムに格納
    void AnswerEnter(string[] selectButtonLine)
    {
        int start = 0;
        int end = 3;

        List<int> numbers = new List<int>();
        for(int i = start; i <= end; i++)
        {
            numbers.Add(i);
        }

        int count = 0;
        while(numbers.Count > 0)
        {
            int index = Random.Range(0, numbers.Count);
            int ransu = numbers[index];

            switch(count){
                case 0 : btText1.text = selectButtonLine[ransu];
                         break;
                case 1 : btText2.text = selectButtonLine[ransu];
                         break;
                case 2 : btText3.text = selectButtonLine[ransu];
                         break;
                case 3 : btText4.text = selectButtonLine[ransu];
                         break;
            }

            numbers.RemoveAt(index);
            count++;
        }
    }
}
