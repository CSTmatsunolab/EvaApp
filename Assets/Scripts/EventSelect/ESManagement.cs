using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;//乱数生成のために追加
using UnityEngine.SceneManagement;

public class ESManagement : MonoBehaviour
{
    [SerializeField] GameObject EventBackground;
    [SerializeField] GameObject EventImage;
    [SerializeField] GameObject TitleText;
    [SerializeField] GameObject EventText;

    public static int index = 0;

    // Start is called before the first frame update
    void Start(){        
        index = rand();//乱数生成
        Debug.Log(index);//コンソールにイベントNo.を表示
        EventLoad(index);
    }
    //乱数(イベントのナンバー)を生成
    int rand(){
        int a = Random.Range(1,3);//1or2
        return a;
    }

    //イベント画面のテキストや画像関係のロード
    void EventLoad(int a){
        Image eventbg;
        Image eventimg;
        Text titletext;
        Text eventtext;
        GameObject EData = GameObject.Find("EventData");

        eventbg = EventBackground.GetComponent<Image>();
        eventimg = EventImage.GetComponent<Image>();
        titletext = TitleText.GetComponent<Text>();
        titletext = TitleText.GetComponent<Text>();
        eventtext = EventText.GetComponent<Text>();

        //イベントセレクトシーンの背景の色(半透明)
        string str = a.ToString();
        eventbg.sprite = Resources.Load<Sprite>(str);
        var c = eventbg.color;
        eventbg.color = new Color(c.r, c.g, c.b, 100.0f/255.0f);//透明度を上げる

        //ランダムに選択されたイベントNo.のイラストを読み込む
        eventimg.sprite = Resources.Load<Sprite>(str);

        //ランダムに選択されたイベントNo.のタイトルを読み込む
        titletext.text = EData.GetComponent<Event_Data>().EventData[a][1];

        //ランダムに選択されたイベントNo.の概要を読み込む
        eventtext.text = EData.GetComponent<Event_Data>().EventData[a][2];
    }

    public void EventButtonDown()//イベント画面に遷移
    {
        SceneManager.LoadScene("EventScene"); //ボタンが押されたら遷移
    }

    public static int Send()
    {
        return index;
    }
}