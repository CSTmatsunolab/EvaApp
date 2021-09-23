using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class ResultText : MonoBehaviour
{
    public GameObject name_object = null;

    void CsvSave()
    {
        GameObject Pdata = GameObject.Find("Player_Data");
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



        // Start is called before the first frame update
    void Start()
    {

            GameObject Edata = GameObject.Find("Eat_Data");
            GameObject Pdata = GameObject.Find("Player_Data");

            int x = int.Parse(Edata.GetComponent<Eat_Data>().EatData[1][0]); //食事量
            int y = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][4]); //食料数
            int y1 = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][4]); //変化前の食料数
            int z = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][0]); //満腹ゲージ
            int z1 = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][0]); //変化前の満腹ゲージ

        if (y > 0)
            {
                y = y - x;
                z = z + x;

                //string型にして格納
                string str1 = y.ToString();
                string str2 = z.ToString();
                Pdata.GetComponent<Player_Data>().PlayerData[1][4] = str1;
                Pdata.GetComponent<Player_Data>().PlayerData[1][0] = str2;

                Debug.Log("PlayerData[" + 1 + "][" + 0 + "]=" + str2); //満腹
                Debug.Log("PlayerData[" + 1 + "][" + 4 + "]=" + str1); //食料数
            }
            CsvSave();
            // オブジェクトからTextコンポーネントを取得
            Text sta_text = name_object.GetComponent<Text>();
            // テキストの表示を入れ替える
            sta_text.text = ("満腹：" + z1 + "→" + Pdata.GetComponent<Player_Data>().PlayerData[1][0] + Environment.NewLine +
                          "食料の数：" + y1 + "→" + Pdata.GetComponent<Player_Data>().PlayerData[1][4]);

        }
    }
