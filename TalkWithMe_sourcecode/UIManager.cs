using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private Text questionText; //質問テキスト

    [SerializeField]
    private Text selectText1, selectText2, selectText3, selectText4; //選択肢テキスト

    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    //num番目の質問と選択肢を設定
    public void SetQandA(int num)
    {
        List<string[]> TextDatas = new List<string[]>();
        TextDatas = FileRead.instance.GetCsvFile;

        ChangeImage.instance.ChangeSprite(2); //普通の表情にする

        questionText.text = TextDatas[num][1];
        selectText1.text = TextDatas[num][2];
        selectText2.text = TextDatas[num][3];
        selectText3.text = TextDatas[num][4];
        selectText4.text = TextDatas[num][5];
    }
}
