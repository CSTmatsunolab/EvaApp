using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class EatButton : MonoBehaviour
{
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

    public void EatButtonDown()
    {
        GameObject Edata = GameObject.Find("Eat_Data");
        GameObject Pdata = GameObject.Find("Player_Data");

        int x = int.Parse(Edata.GetComponent<Eat_Data>().EatData[1][0]); //食事量
        int y = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][4]); //食料数
        int z = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][0]); //満腹ゲージ

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
        // 現在のScene名を取得する
        // Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        //SceneManager.LoadScene(loadScene.name);
        
    }

}