using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Bag_Data : MonoBehaviour
{
    TextAsset csvFile; // CSVファイル
    public List<string[]> BagData = new List<string[]>(); // CSVの中身を入れるリスト;

void Start()
    {
        Debug.Log(Application.persistentDataPath + "/Bichiku_checks.csv");
        string path = Application.persistentDataPath + "/Bichiku_checks.csv";
        //if (path == null){
        //string csv_path = "Player_Data";  // CSVファイルのパス
        csvFile = Resources.Load("Bichiku_checks") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            BagData.Add(line.Split(',')); // , 区切りでリストに追加
        }
            CsvSave();
        //}
        path = Application.persistentDataPath + "/Bichiku_checks.csv";
        using (var fs = new StreamReader(path, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            while (fs.Peek() != -1)
            {
                string line = fs.ReadLine(); // 一行ずつ読み込み
                BagData.Add(line.Split(',')); // , 区切りでリストに追加
            }
        }
        DontDestroyOnLoad(this);

    }

    public void CsvSave()
    {
        string path = Application.persistentDataPath + "/Bichiku_checks.csv";
        using (var fs = new StreamWriter(path, false, System.Text.Encoding.GetEncoding("UTF-8")))
        {
                for(var x=0; x < 34; x++)
                {
                    fs.Write(BagData[0][x]+",");
                    fs.Flush();
                }
        }
    }
}
