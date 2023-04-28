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
        string path = Application.persistentDataPath + "/Bichiku_checks.csv";
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
}
