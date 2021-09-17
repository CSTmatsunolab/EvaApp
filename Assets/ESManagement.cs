using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;//乱数生成のために追加
using UnityEngine.SceneManagement;

public class ESManagement : MonoBehaviour
{
    public static int index;
    // Start is called before the first frame update
    void Awake()//Start()よりも早く発動する関数
    {
        index=rand();//乱数生成
        Debug.Log(index);//コンソールにイベントNo.を表示

    }

    int rand()//乱数生成の関数
    {
        int a = Random.Range(1,3);
        return a;
    }

    public void EventButtonDown()//イベント画面に遷移
    {
        SceneManager.LoadScene("EventScene"); //ボタンが押されたら遷移
    }
}
