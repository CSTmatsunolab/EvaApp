using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Days_Data : MonoBehaviour
{
    TextAsset csvFile; // CSVファイル
    public List<string[]> DaysData = new List<string[]>(); // CSVの中身を入れるリスト;
    [SerializeField]
    private string[] currentDates = new string[3];

void Start()
    {
        string path = Application.persistentDataPath + "/Bichiku_days.csv";

        if (!File.Exists(path))
        {
            // 初回のみResourcesから読み込み
            csvFile = Resources.Load("Bichiku_days") as TextAsset;
            StringReader reader = new StringReader(csvFile.text);

            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                DaysData.Add(line.Split(','));
            }
            CsvSave();
        }
        else
        {
            // 既存ファイルからの読み込み
            using (var fs = new StreamReader(path, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                {
                    string line = fs.ReadLine();
                    DaysData.Add(line.Split(','));
                }
            }
        }

    // データ確認
    Debug.Log("最終的なDaysDataの状態 Count=" + DaysData.Count);  // 追加
    for (int i = 0; i < DaysData.Count; i++)
    {
        Debug.Log($"最終 - DaysData[{i}] = [{string.Join(", ", DaysData[i])}]");  // 追加
    }

    DontDestroyOnLoad(this);
    UpdateCurrentDates();


    }

    private void UpdateCurrentDates()
    {
        if (DaysData.Count > 0)
        {
            currentDates[0] = DaysData[0][0]; // year
            currentDates[1] = DaysData[0][1]; // month
            currentDates[2] = DaysData[0][2]; // day
        }
    }
     public void CsvSave()
    {
        string path = Application.persistentDataPath + "/Bichiku_days.csv";
        using (var fs = new StreamWriter(path, false, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            for (var y = 0; y < 3; y++)
            {
                if (DaysData != null && DaysData.Count > y && DaysData[y] != null && DaysData[y].Length >= 3)
                {
                    // 配列の要素を結合して書き込み
                    fs.WriteLine($"{DaysData[y][0]},{DaysData[y][1]},{DaysData[y][2]}");
                }
                else
                {
                    // 初期値として "2000,1,1" を書き込む
                    fs.WriteLine("2000,1,1");
                }
            }
        }
    }
}