using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileRead : MonoBehaviour
{
    public static FileRead instance;
    private TextAsset csvFile; //CSVファイル

    private List<string[]> csvDatas = new List<string[]>(); //CSVの中身を入れるリスト

    public List<string[]> GetCsvFile
    {
        get
        {
            return csvDatas;
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
        csvFile = Resources.Load("talkText") as TextAsset; //Resourceフォルダ内のCSVファイル読み込み
        StringReader reader = new StringReader(csvFile.text);

        while(reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(',')); //リストに入れる
            //Debug.Log("reading : " + height);
            height++; //行数加算
        }
    }
}
