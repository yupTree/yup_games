using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneFileRead : MonoBehaviour
{
    public static EndSceneFileRead instance;
    private TextAsset csvEndFile; //CSVファイル

    private List<string[]> csvEndDatas = new List<string[]>(); //CSVの中身を入れるリスト

    public List<string[]> GetCsvEndFile
    {
        get
        {
            return csvEndDatas;
        }
    }

    private int height = 0; //CSVの行数

    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        csvEndFile = Resources.Load("hintText") as TextAsset; //Resourceフォルダ内のCSVファイル読み込み
        StringReader reader = new StringReader(csvEndFile.text);

        while(reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvEndDatas.Add(line.Split(',')); //リストに入れる
            //Debug.Log("reading : " + height);
            height++; //行数加算
        }

        EndSceneUIManager.instance.SetHintText(Random.Range(0,11)); //ヒントコメントを10個のうちからランダムで表示
    }
}
