using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class EatMainPanel : MonoBehaviour
{
    int x = 0;//食べる食料の数
    int i = 0;//食料の貯蓄量
    int j = 0;//まんぷくゲージ
    int k = 0;//時間
    int l = 0;//安心ゲージ
    private GameObject Pdata = null;
    public GameObject KText = null;
    public GameObject RText = null;
    Text ktext;
    // Start is called before the first frame update
    void Start()
    {
        Pdata = GameObject.Find("Player_Data");
        ktext=KText.GetComponent<Text>();
        x = 0;
        i = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][4]);
        Debug.Log(i);
        j = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][0]);
        k = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][5]);
        l = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][1]);
        ktext.text=x.ToString();
    }

    public void PlusButtondown()    {
        if((i>0)&&(x<3))        {
            --i;//貯蓄を減らす
            ++x;//食べる量を増やす
            ktext.text=x.ToString();
        }
    }

    public void MinusButtondown()   {
        if(x>0)　//食べる量が0以上の時のみ
        {
            ++i;//貯蓄を増やす
            --x;//食べる量を減らす
            ktext.text=x.ToString();
        } 
    }

    public void EatButtondown()
    {
        j = j + x;　//まんぷくゲージに加算
        Debug.Log(x);
        Debug.Log(i);
        if(j > 10){
            j = 10;
        }
        Pdata.GetComponent<Player_Data>().PlayerData[1][0]=j.ToString();//配列に格納
        Pdata.GetComponent<Player_Data>().PlayerData[1][4]=i.ToString();//配列に格納

        TimeCheck();
        Result();
        CsvSave();
    }

    public void NotEatButtondown()
    {
        x=0;
        TimeCheck();
        Result();
        CsvSave();
    }

    void CsvSave()//CSVに保存
    {
        StreamWriter file = new StreamWriter("Assets/Resources/PlayerData.csv", false);
        for (var y = 0; y < 2; y++)
        {
            for (var x = 0; x < 8; x++)
            {
                file.Write(Pdata.GetComponent<Player_Data>().PlayerData[y][x] + ",");
                file.Flush();
            }
            file.WriteLine();
        }
    }

    void Result()//食事結果の表示
    {
        Text rtext = RText.GetComponent<Text>();
        //rtext.text = "まんぷくゲージが"+x.ToString()+"回復した！";
        if(x==0)//食べた量が0の時に分岐
        {
            rtext.text = "何も食べなかった...";
        }
        else
        {
            rtext.text = ("満腹：" + (j - x).ToString() + "→" + j + Environment.NewLine +
                      "食料の数：" + (i + x).ToString() + "→" + i);
        }
    }

    void TimeCheck()//昼と夜の変更
    {
        if(Pdata.GetComponent<Player_Data>().PlayerData[1][6]=="0"){
            Pdata.GetComponent<Player_Data>().PlayerData[1][6]="1";
        }
        else{
            Pdata.GetComponent<Player_Data>().PlayerData[1][6]="0";
            k=k+1;
            Pdata.GetComponent<Player_Data>().PlayerData[1][5]=k.ToString();
        }
    }

    public void GoToHungry()
    {
        //一日の終わり(sleepの閉じるボタンを押した時)に満腹や安心の操作を行う
        //２日目以降の昼(一日の最初)に満腹-1       
        if(j>0){
            j = j -1 ;
            Debug.Log("満腹-1操作");
            Pdata.GetComponent<Player_Data>().PlayerData[1][0]=j.ToString();//配列に格納
        }
        else{    //0のまま寝て起きたら安心-1
            l = l -1;
            Debug.Log("安心-1操作");
            Pdata.GetComponent<Player_Data>().PlayerData[1][1]=l.ToString();//配列に格納
        }
        CsvSave();
        GoToSelect();//選択シーンに遷移
    }

    public void GoToSelect()
    {
        SceneManager.LoadScene("SelectScene");//選択シーンに遷移
    }
    

}
