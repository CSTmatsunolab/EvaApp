﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class ResultPanel : MonoBehaviour
{
    private GameObject Pdata = null;
    private GameObject Edata = null;
    int index = 0;
    int HG = 0; //満腹ゲージ
    int RE = 0; //安心ゲージ
    int HGC = 0; //イベントによる満腹ゲージの変動値
    int REC = 0; //イベントによる安心ゲージの変動値
    public Text Result;
    

    void Start()
    {
        ResultCalculation();
    }

    private void PdataLoad()
    {
        Pdata = GameObject.Find("Player_Data");
    }

    private void EdataLoad()
    {
        Edata = GameObject.Find("EventData");
    }

    private void ResultMake()
    {
        PdataLoad();
        EdataLoad();
        index = ESManagement.Send();
        HG = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][0]);
        RE = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][1]);
        HGC = int.Parse(Edata.GetComponent<Event_Data>().EventData[index][3]);
        REC = int.Parse(Edata.GetComponent<Event_Data>().EventData[index][4]);
    }

    private void ResultCalculation()
    {
       ResultMake();
       HGC = HG + HGC;
       if(HGC < 0)
           HGC = 0;
       REC = RE + REC;
        if(REC < 0)
           REC = 0;

       Pdata.GetComponent<Player_Data>().PlayerData[1][0] = HGC.ToString();
       Pdata.GetComponent<Player_Data>().PlayerData[1][1] = RE.ToString();
       CsvSave();
       Result.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString() + Environment.NewLine +
                      "安心ゲージ：" + RE.ToString() + "→" + REC.ToString());
    
    }

    public void NextButtonDown()
    {
        SceneManager.LoadScene("EatScene");//食事画面に遷移
    }

    void CsvSave()
    {
        StreamWriter file = new StreamWriter("Assets/Resources/PlayerData.csv",false);
        for (var y=0; y < 2; y++)
        {
            for(var x=0;x<8;x++)
            {
                file.Write(Pdata.GetComponent<Player_Data>().PlayerData[y][x]+",");
                file.Flush();
            }
            file.WriteLine();
        }
    }
}