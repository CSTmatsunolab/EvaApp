using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class DrinkButton : MonoBehaviour
{
    Button DButton;
    void Start(){        
        GameObject Pdata = GameObject.Find("Player_Data");
        DButton = GameObject.Find ("Canvas/DrinkButton").GetComponent<Button>();

        //水分x
        int x = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][2]);
        //水の所持数(ペットボトル)y
        int y = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][3]);

        //水の所持数が0のとき or 水分が満タンの時ボタン無効化
        if(y==0 || x==3){
            DButton.interactable=false;
        }
    }

    public void DrinkButtonDown()
    {
        GameObject Pdata = GameObject.Find("Player_Data");
        DButton = GameObject.Find ("Canvas/DrinkButton").GetComponent<Button>();

        //水分x
        int x = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][2]);
        //水の所持数(ペットボトル)y
        int y = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][3]);

        if(y>0){
            x=x+3;
            y=y-1;
            if(x>3) x=3;
            
            //string型にして格納
            string str=x.ToString();
            Pdata.GetComponent<Player_Data>().PlayerData[1][2]=str;
            str=y.ToString();
            Pdata.GetComponent<Player_Data>().PlayerData[1][3]=str;
        }
        CsvSave();
        
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
    }

    void CsvSave()
    {
        GameObject Pdata = GameObject.Find("Player_Data");
        StreamWriter file = new StreamWriter("Assets/Resources/PlayerData.csv",false);
        for (var y=0; y < 2; y++)
        {
            for(var x=0; x < 11; x++)
            {
                file.Write(Pdata.GetComponent<Player_Data>().PlayerData[y][x]+",");
                file.Flush();
            }
            file.WriteLine();
        }
    }
}