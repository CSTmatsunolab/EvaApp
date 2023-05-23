using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Days_Data : MonoBehaviour
{
    TextAsset csvFile; // CSVファイル
    public List<string[]> DaysData = new List<string[]>(); // CSVの中身を入れるリスト;

void Start()
    {
        string path = Application.persistentDataPath + "/Bichiku_days.csv";
        if (!File.Exists(path)){
        //string csv_path = "Player_Data";  // CSVファイルのパス
        csvFile = Resources.Load("Bichiku_days") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            DaysData.Add(line.Split(',')); // , 区切りでリストに追加
        }
        // データ確認用
        
        for (int i = 0; i < DaysData.Count; i++)
            {
            for (int j = 0; j < DaysData[0].Length; j++)
                {
                Debug.Log("DaysData[" + i + "][" + j + "]=" + DaysData[i][j]);
                }
            }
            CsvSave();
        }
        //path = Application.persistentDataPath + "/Bichiku_days.csv";
        using (var fs = new StreamReader(path, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            while (fs.Peek() != -1)
            {
                string line = fs.ReadLine(); // 一行ずつ読み込み
                DaysData.Add(line.Split(',')); // , 区切りでリストに追加
            }
        }
        DontDestroyOnLoad(this);


    }
     public void CsvSave()
    {
        string path = Application.persistentDataPath + "/Bichiku_days.csv";
        using (var fs = new StreamWriter(path, false, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            for (var y=0; y < 3; y++)
            {
                for(var x=0; x < 2; x++)
                {
                    fs.Write(DaysData[y][x]+",");
                    fs.Flush();
                }
                fs.WriteLine();
            }
        }
    }
}