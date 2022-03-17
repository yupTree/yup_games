using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneUIManager : MonoBehaviour
{
    //エンドシーンでのスコア表示のためのテキスト
    [SerializeField]
    private Text scoreText;

    void Start()
    {
        scoreText.text = "SCORE : " + GameManager.score;
    }
}
