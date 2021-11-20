using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;//乱数生成のために追加
using UnityEngine.SceneManagement;
using System.IO;

public class ESManagement : MonoBehaviour
{
    [SerializeField] GameObject EventBackground;
    [SerializeField] GameObject EventImage;
    [SerializeField] GameObject TitleText;
    [SerializeField] GameObject EventText;
    [SerializeField] GameObject ClearText;
    [SerializeField] GameObject FailText;

    [SerializeField] private string spritesDirectory = "Sprites/Event";
    GameObject Rdata;

    public static int index = 0;
    public static int Answer = 0;
    public static int Transform = 0;

    // Start is called before the first frame update
    void Start(){        
        index = rand();//乱数生成
        Debug.Log(index);//コンソールにイベントNo.を表示
        Transform = Random.Range(1,3);//1~2
        Debug.Log(Transform);
        EventLoad(index);
    }

    //ResultData読み込み
    private void RdataLoad(){
        Rdata = GameObject.Find("ResultData");
    }

    //乱数(イベントのナンバー)を生成
    int rand(){
        int flag = MenuPanel.Send();
        int a = 0;
        if(flag == 0){

            a = Random.Range(3,16);//3~15
            //a = Random.Range(3,5);//指定範囲の動作確認用

            if(a == 6)
            {
                a = 3; //イベント6の場合用の仮の設定
            }
        }
        else if(flag == 1){
            a = 16;
        }
        return a;
    }

    //イベント画面のテキストや画像関係のロード
    void EventLoad(int a){
        Image eventbg;
        Image eventimg;
        Text titletext;
        Text eventtext;
        Text cleartext;
        Text failtext;

        GameObject EData = GameObject.Find("EventData");

        eventbg = EventBackground.GetComponent<Image>();
        eventimg = EventImage.GetComponent<Image>();
        titletext = TitleText.GetComponent<Text>();
        eventtext = EventText.GetComponent<Text>();
        cleartext = ClearText.GetComponent<Text>();
        failtext = FailText.GetComponent<Text>();


        //イベントセレクトシーンの背景の色(半透明)
        string str = spritesDirectory+a.ToString();
        eventbg.sprite = Resources.Load<Sprite>(str);
        var c = eventbg.color;
        eventbg.color = new Color(c.r, c.g, c.b, 100.0f/255.0f);//透明度を上げる

        //ランダムに選択されたイベントNo.のイラストを読み込む
        eventimg.sprite = Resources.Load<Sprite>(str);

        //ランダムに選択されたイベントNo.のタイトルを読み込む
        titletext.text = EData.GetComponent<Event_Data>().EventData[a][1];

        //ランダムに選択されたイベントNo.の概要を読み込む
        eventtext.text = EData.GetComponent<Event_Data>().EventData[a][2];

        //ランダムに選択されたイベントNo.の正解選択肢を読み込む
        cleartext.text = EData.GetComponent<Event_Data>().EventData[a][7];
        //ランダムに選択されたイベントNo.の不正解選択肢を読み込む
        failtext.text = EData.GetComponent<Event_Data>().EventData[a][8];

        int Change = 0;
        Change = Transform;

        if(Change == 1) //正解
        {
            //ランダムに選択されたイベントNo.の正解選択肢を読み込む
            cleartext.text = EData.GetComponent<Event_Data>().EventData[a][7];
            //ランダムに選択されたイベントNo.の不正解選択肢を読み込む
            failtext.text = EData.GetComponent<Event_Data>().EventData[a][8];
            Debug.Log("Change = 1");
        }
        else if(Change == 2) //不正解
        {
            //ランダムに選択されたイベントNo.の不正解選択肢を読み込む
            cleartext.text = EData.GetComponent<Event_Data>().EventData[a][8];
            //ランダムに選択されたイベントNo.の正解選択肢を読み込む
            failtext.text = EData.GetComponent<Event_Data>().EventData[a][7];
            Debug.Log("Change = 2");
        }
    }

    public void ClearButtonDown()//イベント画面に遷移
    {
        int Check = 0;
        Check = Transform;
        if(Check == 1) //正位置　正解
        {
            RdataLoad();
            Rdata.GetComponent<Result_Data>().ResultData[index][1] = "1";
            EventSave();
            Answer = 0;
            SceneManager.LoadScene("EventScene"); //ボタンが押されたら遷移
        }
        else if(Check == 2) //逆位置　不正解
        {
            RdataLoad();
            Rdata.GetComponent<Result_Data>().ResultData[index][1] = "1";
            EventSave();
            Answer = 1;
            SceneManager.LoadScene("EventScene"); //ボタンが押されたら遷移
        }
    }

    public void FailButtonDown()//イベント画面に遷移
    {
        int Check = 0;
        Check = Transform;
        if(Check == 1) //正位置　不正解
        {
            RdataLoad();
            Rdata.GetComponent<Result_Data>().ResultData[index][1] = "1";
            EventSave();
            Answer = 1;
            SceneManager.LoadScene("EventScene"); //ボタンが押されたら遷移
        }
        else if(Check == 2) //逆位置 正解
        {
            RdataLoad();
            Rdata.GetComponent<Result_Data>().ResultData[index][1] = "1";
            EventSave();
            Answer = 0;
            SceneManager.LoadScene("EventScene"); //ボタンが押されたら遷移
        }
    }

    public static int Send()
    {
        return index;
    }

    public static int SendAnswer()
    {
        return Answer;
    }

    void EventSave()
    {
        StreamWriter file = new StreamWriter("Assets/Resources/EventResult.csv",false);
        for (var y=0; y < Rdata.GetComponent<Result_Data>().ResultData.Count; y++)
        {
            for(var x=0;x < 2;x++)
            {
                file.Write(Rdata.GetComponent<Result_Data>().ResultData[y][x]+",");
                file.Flush();
            }
            file.WriteLine();
        }
    }
}