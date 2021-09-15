using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotEatButton : MonoBehaviour
{
    public void NotEatButtonDown()
    {
        GameObject Pdata = GameObject.Find("Player_Data");
        int i = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][6]);
         if (i == 0)
            {
                //昼ならイベント画面に遷移
                SceneManager.LoadScene("EventScene");
            }
         else if (i == 1)
            {
                //夜ならイベント画面に遷移
                SceneManager.LoadScene("SleepScene");
            }

    }
}