﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player_Data : MonoBehaviour
{
    TextAsset csvFile; // CSVファイル
    public List<string[]> PlayerData = new List<string[]>(); // CSVの中身を入れるリスト;

void Start()
    {

        //string csv_path = "Player_Data";  // CSVファイルのパス
        csvFile = Resources.Load("PlayerData") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            PlayerData.Add(line.Split(',')); // , 区切りでリストに追加
        }
        // データ確認用
        for (int i = 0; i < PlayerData.Count; i++)
        {
            for (int j = 0; j < PlayerData[0].Length; j++)
            {
                Debug.Log("PlayerData[" + i + "][" + j + "]=" + PlayerData[i][j]);
            }
        }
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
    }
}