using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class check_year : MonoBehaviour
{
    public InputField inputField_y;
    public InputField inputField_m;
    public InputField inputField_d;
    public GameObject DaysSave;
    DateTime TodayNow;
    static TextAsset csvFile;
    static List<string[]> daysData = new List<string[]>();
    int year;
    int month;
    int day;
    bool y_flag = false;
    bool m_flag = false;
    bool d_flag = false;
    
    void Awake(){
        csvFile = Resources.Load("Texts/Bichiku_days") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);//
        while (reader.Peek() != -1)//最後まで読み込むと-1になる関数
        {
            string line = reader.ReadLine();//一行ずつ読み込み
            daysData.Add(line.Split(','));
        }
        if(transform.parent.name == "Itembox1"){
            inputField_y.text = daysData[0][0];
            inputField_m.text = daysData[0][1];
            inputField_d.text = daysData[0][2];
        }
        if(transform.parent.name == "Itembox2"){
            inputField_y.text = daysData[1][0];
            inputField_m.text = daysData[1][1];
            inputField_d.text = daysData[1][2];
        }
        year = int.Parse(inputField_y.text);
        month = int.Parse(inputField_m.text);
        day = int.Parse(inputField_d.text);
        y_flag = true;
        m_flag = true;
        d_flag = true;
    }

   // Update is called once per frame
   public void InputYear()
   {
       TodayNow = DateTime.Now;
       if(inputField_y.text.Length == 4){
           year = int.Parse(inputField_y.text);
           y_flag = true;
       }else{
           y_flag = false;
       }
       Debug.Log("y_flag="+ y_flag);
       check();
   }

   public void InputMonth()
   {
       TodayNow = DateTime.Now;
       if(inputField_m.text.Length == 2 || inputField_m.text.Length == 1){
           month = int.Parse(inputField_m.text);
           m_flag = true;
       }else{
           m_flag = false;
       }
       Debug.Log("m_flag="+ m_flag);
       check();
   }
   public void InputDay()
   {
       TodayNow = DateTime.Now;
       if(inputField_d.text.Length == 2 || inputField_d.text.Length == 1){
           day = int.Parse(inputField_d.text);
           d_flag = true;
       }else{
           d_flag = false;
       }
       Debug.Log("d_flag="+ d_flag);
       check();
   }


   void check(){
       if(y_flag == true && m_flag == true && d_flag == true){
           if(TodayNow.Year == year && TodayNow.Month == month && TodayNow.Day >= day){
               Debug.Log("本日:"+TodayNow+"以降以降で入力してください");
               inputField_d.text = null;
               d_flag = false;
           }else if(TodayNow.Year == year && TodayNow.Month > month){
               Debug.Log("本日:"+TodayNow+"以降以降で入力してください");
               inputField_m.text = null;
               inputField_d.text = null;
               m_flag = false;
               d_flag = false;
           }else if(TodayNow.Year > year){
               Debug.Log("本日:"+TodayNow+"以降以降で入力してください");
               inputField_y.text = null;
               inputField_m.text = null;
               inputField_d.text = null;
               y_flag = false;
               m_flag = false;
               d_flag = false;
           }else{
                Debug.Log("ok"); 
                DaysSave.GetComponent<Days_save>().save();
           }
       }
   }
}