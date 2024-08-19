using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Linq;

public class ResultPanel : MonoBehaviour
{
    TextAsset csvFile;
    private GameObject Pdata = null;
    private GameObject Edata = null;
    private GameObject Bdata;
    int index = 0;
    int Answer = 0;
    int HG = 0; //満腹ゲージ
    int RE = 0; //安心ゲージ
    int HGC = 0; //イベントによる満腹ゲージの変動値
    int REC = 0; //イベントによる安心ゲージの変動値
    public Text Result1;
    public Text Result2;
    private string path;
    public List<string[]> checksData = new List<string[]>();
    

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

        int introcheck = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][8]);
        Debug.Log(introcheck);
        if(introcheck == 0||introcheck == 1){        //イントロシナリオにいく
            index = 1;
        }
        else if(introcheck==100){
            index = 100;
        }
        

        else{
            index = introcheck;
            
            index = ESManagement.Send();
            Answer = ESManagement.SendAnswer();
        }
        HG = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][0]);
        RE = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][1]);

        if(Answer == 0)
        {
            HGC = int.Parse(Edata.GetComponent<Event_Data>().EventData[index][3]);
            REC = int.Parse(Edata.GetComponent<Event_Data>().EventData[index][4]);
        }
        else if(Answer == 1)
        {
            HGC = int.Parse(Edata.GetComponent<Event_Data>().EventData[index][5]);
            REC = int.Parse(Edata.GetComponent<Event_Data>().EventData[index][6]);
        }
        if(introcheck==101){
            index = 101;
            HGC = 0;
            REC = 0;
        }
    }

    private void ResultCalculation()
    {
        //csvFile = Resources.Load("Bichiku_checks") as TextAsset;
        //StringReader reader = new StringReader(csvFile.text);
        // while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        // {
        //     string line = reader.ReadLine(); // 一行ずつ読み込み
        //     checksData.Add(line.Split(',')); // , 区切りでリストに追加
        // }
        Bdata = GameObject.Find("BagData");
        Debug.Log(Bdata.GetComponent<Bag_Data>().BagData[0][11]);
        Debug.Log(Bdata.GetComponent<Bag_Data>().BagData[0][14]);
        Debug.Log(Bdata.GetComponent<Bag_Data>().BagData[0][1]);
        ResultMake();
        if(index==52){
            if(Bdata.GetComponent<Bag_Data>().BagData[0][11] == "true") {
                if(Answer == 0){
                    HGC = 0;
                    REC = 2;
                }else if(Answer == 1){
                    HGC = -1;
                    REC = -2;
                }
            }
        }
        if(index==53){
             if(Bdata.GetComponent<Bag_Data>().BagData[0][26] == "true") {
                 if(Answer == 0){
                     HGC = 0;
                     REC = 2;
                 }else if(Answer == 1){
                     HGC = -1;
                     REC = -2;
                 }
             }
        }
        if(index==54){
            if(Bdata.GetComponent<Bag_Data>().BagData[0][20] == "true") {
                if(Answer == 0){
                    HGC = 0; 
                    REC = 2;
                }else if(Answer == 1){
                    HGC = 0;
                    REC = -2;
                }
            }
        }
        if(index==55){
             if(Bdata.GetComponent<Bag_Data>().BagData[0][15] == "true") {
                 if(Answer == 0){
                     HGC = 0;
                     REC = 2;
                 }else if(Answer == 1){
                     HGC = -1;
                     REC = -2;
                 }
             }
        }
        if(index==56){
             if(Bdata.GetComponent<Bag_Data>().BagData[0][31] == "true") {
                 if(Answer == 0){
                     HGC = 0;
                     REC = 2;
                 }else if(Answer == 1){
                     HGC = -0;
                     REC = -1;
                 }
             }
         }
        if(index==57){
            if(Bdata.GetComponent<Bag_Data>().BagData[0][18] == "true") {
                if(Answer == 0){
                    HGC = 0; 
                    REC = 2;
                }else if(Answer == 1){
                    HGC = -2;
                    REC = -2;
                }
            }
        }
         if(index==58){
             if(Bdata.GetComponent<Bag_Data>().BagData[0][23] == "true") {
                 if(Answer == 0){
                     HGC = 0;
                     REC = 2;
                 }else if(Answer == 1){
                     HGC = -1;
                     REC = -2;
                 }
             }
         }
         if(index==59){
             if(Bdata.GetComponent<Bag_Data>().BagData[0][27] == "true") {
                 if(Answer == 0){
                     HGC = 0;
                     REC = 2;
                 }else if(Answer == 1){
                     HGC = -1;
                     REC = -2;
                 }
             }
         }
        
        HGC = HG + HGC;
        if(HGC < 0)
        {
            HGC = 0;
        }
        else if(HGC > 10)
        {
            HGC = 10;
        }
        REC = RE + REC;
        if(REC < 0)
        {
            REC = 0;
        }else if(REC > 10)
        {
            REC = 10;
        }
        if(index==50){
            if(Bdata.GetComponent<Bag_Data>().BagData[0][14] == "true") {
                if(Answer == 0){
                    int WaterStock = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][3]);
                    WaterStock = WaterStock + 1;
                    Pdata.GetComponent<Player_Data>().PlayerData[1][3]=WaterStock.ToString();
                    Debug.Log(Pdata.GetComponent<Player_Data>().PlayerData[1][3]);
                }
            }
        }
        if(index==51){
            if(Bdata.GetComponent<Bag_Data>().BagData[0][1] == "true") {
                if(Answer == 0){
                    int FoodStock = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][4]);
                    FoodStock = FoodStock + 1;
                    Pdata.GetComponent<Player_Data>().PlayerData[1][4]=FoodStock.ToString();
                    Debug.Log(Pdata.GetComponent<Player_Data>().PlayerData[1][4]);
                }
            }
        }
        

        Pdata.GetComponent<Player_Data>().PlayerData[1][0] = HGC.ToString();
        Pdata.GetComponent<Player_Data>().PlayerData[1][1] = REC.ToString();
        Pdata.GetComponent<Player_Data>().CsvSave();

        if(index == 100){
            Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            Result1.text = "水が増えた！";
            Result2.text = "食料が増えた！";
            
        }else if(index == 50){
            Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            Result1.text = "水が増えた！";
            Result2.text = "";
            if(Bdata.GetComponent<Bag_Data>().BagData[0][14] == "false") {
                Result1.text = "チェックリストにアイテムがないため";
                Result2.text = "報酬はもらえなかった";
            }
            if(Answer == 1){
                Result1.text = "不正解のため";
                Result2.text = "水はもらえなかった";
            }
        }else if(index ==  51){
            Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            Result1.text = "食料が増えた！";
            Result2.text = "";
            if(Bdata.GetComponent<Bag_Data>().BagData[0][1] == "false") {
                Result1.text = "チェックリストにアイテムがないため";
                Result2.text = "報酬はもらえなかった";
            }
            if(Answer == 1){
                Result1.text = "不正解のため";
                Result2.text = "食量はもらえなかった";
            }
        }else if(index == 52)
        {
            if (HG > HGC)
            {
                Result1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (HG < HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (RE > REC)
            {
                Result2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (RE < REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (HG == HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            if (RE == REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            Result1.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString());
            Result2.text = ("安心ゲージ：" + RE.ToString() + "→" + REC.ToString());
            if(Bdata.GetComponent<Bag_Data>().BagData[0][11] == "false") {
                Result1.text = "チェックリストにアイテムがないため";
                Result2.text = "安心度は変動しなかった";
            }
            if(Answer == 1){
                Result1.text = "不正解のため";
                Result2.text = "安心度が減った";
            }
        }else if(index == 53)
        {
            if (HG > HGC)
            {
                Result1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (HG < HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (RE > REC)
            {
                Result2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (RE < REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (HG == HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            if (RE == REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            Result1.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString());
            Result2.text = ("安心ゲージ：" + RE.ToString() + "→" + REC.ToString());
            if(Bdata.GetComponent<Bag_Data>().BagData[0][26] == "false") {
                Result1.text = "チェックリストにアイテムがないため";
                Result2.text = "安心度は変動しなかった";
            }
            if(Answer == 1){
                Result1.text = "不正解のため";
                Result2.text = "安心度が減った";
            }
        }else if(index == 54)
        {
            if (HG > HGC)
            {
                Result1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (HG < HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (RE > REC)
            {
                Result2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (RE < REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (HG == HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            if (RE == REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            Result1.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString());
            Result2.text = ("安心ゲージ：" + RE.ToString() + "→" + REC.ToString());
            if(Bdata.GetComponent<Bag_Data>().BagData[0][20] == "false") {
                Result1.text = "チェックリストにアイテムがないため";
                Result2.text = "安心度は変動しなかった";
            }
            if(Answer == 1){
                Result1.text = "不正解のため";
                Result2.text = "安心度が減った";
            }
        }else if(index == 55)
        {
            if (HG > HGC)
            {
                Result1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (HG < HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (RE > REC)
            {
                Result2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (RE < REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (HG == HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            if (RE == REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            Result1.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString());
            Result2.text = ("安心ゲージ：" + RE.ToString() + "→" + REC.ToString());
            if(Bdata.GetComponent<Bag_Data>().BagData[0][15] == "false") {
                //Result1.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString());
                //Result2.text = ("安心ゲージ：" + RE.ToString() + "→" + REC.ToString());
                Result1.text = "チェックリストにアイテムがないため";
                Result2.text = "安心度は変動しなかった";
            }
            if(Answer == 1){
                Result1.text = "不正解のため";
                Result2.text = "安心度が減った";
            }
        
        }else if(index == 56)
        {
            if (HG > HGC)
            {
                Result1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (HG < HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (RE > REC)
            {
                Result2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (RE < REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (HG == HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            if (RE == REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            Result1.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString());
            Result2.text = ("安心ゲージ：" + RE.ToString() + "→" + REC.ToString());
            if(Bdata.GetComponent<Bag_Data>().BagData[0][31] == "false") {
                //Result1.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString());
                //Result2.text = ("安心ゲージ：" + RE.ToString() + "→" + REC.ToString());
                Result1.text = "チェックリストにアイテムがないため";
                Result2.text = "安心度は変動しなかった";
            }
            if(Answer == 1){
                Result1.text = "不正解のため";
                Result2.text = "安心度が減った";
            }
        
        }else if(index == 57)
        {
            if (HG > HGC)
            {
                Result1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (HG < HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (RE > REC)
            {
                Result2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (RE < REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (HG == HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            if (RE == REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            Result1.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString());
            Result2.text = ("安心ゲージ：" + RE.ToString() + "→" + REC.ToString());
            if(Bdata.GetComponent<Bag_Data>().BagData[0][18] == "false") {
                Result1.text = "チェックリストにアイテムがないため";
                Result2.text = "安心度は変動しなかった";
            }
            if(Answer == 1){
                Result1.text = "不正解のため";
                Result2.text = "安心度が減った";
            }
        }else if(index == 58)
        {
            if (HG > HGC)
            {
                Result1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (HG < HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (RE > REC)
            {
                Result2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (RE < REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (HG == HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            if (RE == REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            Result1.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString());
            Result2.text = ("安心ゲージ：" + RE.ToString() + "→" + REC.ToString());
            if(Bdata.GetComponent<Bag_Data>().BagData[0][23] == "false") {
                Result1.text = "チェックリストにアイテムがないため";
                Result2.text = "安心度は変動しなかった";
            }
            if(Answer == 1){
                Result1.text = "不正解のため";
                Result2.text = "安心度が減った";
            }
         }else if(index == 59)
        {
            if (HG > HGC)
            {
                Result1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (HG < HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (RE > REC)
            {
                Result2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (RE < REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (HG == HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            if (RE == REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            Result1.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString());
            Result2.text = ("安心ゲージ：" + RE.ToString() + "→" + REC.ToString());
            if(Bdata.GetComponent<Bag_Data>().BagData[0][27] == "false") {
                Result1.text = "チェックリストにアイテムがないため";
                Result2.text = "安心度は変動しなかった";
            }
            if(Answer == 1){
                Result1.text = "不正解のため";
                Result2.text = "安心度が減った";
            }
        }
        else{
            if (HG > HGC)
            {
                Result1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (HG < HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (RE > REC)
            {
                Result2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //赤
            }
            if (RE < REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 1.0f, 1.0f); //青
            }
            if (HG == HGC)
            {
                Result1.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            if (RE == REC)
            {
                Result2.color = new Color(0.0f, 0.0f, 0.0f, 1.0f); //黒
            }
            
            Result1.text = ("満腹ゲージ：" + HG.ToString() + "→" + HGC.ToString());
            Result2.text = ("安心ゲージ：" + RE.ToString() + "→" + REC.ToString());

        }
        
    
    }

    public void NextButtonDown()
    {
        int flag = MenuPanel.Send();
        if(flag == 1){
            SceneManager.LoadScene("SelectScene");//選択画面に遷移
        }
        /*if(flag == 2){
            SceneManager.LoadScene("SelectScene");//選択画面に遷移
        }
        */
        else if(flag == 3){
            Pdata.GetComponent<Player_Data>().PlayerData[1][8] = "2";
            SceneManager.LoadScene("SelectScene");//選択画面に遷移
        }
        else if(flag == 4){
            SceneManager.LoadScene("SelectScene");//選択画面に遷移
        }
        else{
            SceneManager.LoadScene("EatScene");//食事画面に遷移
        }
    }
}
