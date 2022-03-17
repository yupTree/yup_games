using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEndScene : MonoBehaviour
{
    void Update()
    {
        if(GameManager.isGameEnd){
            //10問目が終わったらエンドシーン処理
            ChooseEndScene();
            GameManager.isGameEnd = false;
        }

    }

    //スコアによってエンドシーンを選ぶ
    void ChooseEndScene()
    {
        int playerScore = GameManager.score;
        string endSceneName; //エンドシーンの名前格納

        //スコアによってエンディングを変える
        //0 --- End1
        //10~50 --- End2
        //60~90 --- End3
        //100 --- End4
        if(playerScore <= 0){
            endSceneName = "End1";
        }
        else if(0 < playerScore && playerScore <= 50){
            endSceneName = "End2";
        }
        else if(50 < playerScore && playerScore <= 90){
            endSceneName = "End3";
        }
        else{
            endSceneName = "End4";
        }

        SceneManager.LoadScene(endSceneName);
    }
}
