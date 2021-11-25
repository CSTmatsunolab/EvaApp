using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;//乱数生成のために追加
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class QuizManagement : MonoBehaviour
{
    public Text QuizNo;
    public Text QuizSentence;
    public Text cleartext;
    public Text failtext;
    private GameObject Pdata;
    private GameObject Edata;
    int[] a = new int[10];//選出されたクイズのNo.
    int no = 0;//クイズが何題めか
    int Change = 0;
    int Change2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        Shuffle();
        EdataLoad();
        NoSet();
        QuizLoad();
    }

    private void PdataLoad(){
        Pdata = GameObject.Find("Player_Data");
    }

    private void NoSet(){
        QuizNo.text="第"+(no+1).ToString()+"問";
    } 

    private void EdataLoad(){
        Edata = GameObject.Find("EventData");
    }
    private int Rand(){
        int a = Random.Range(1,3);//1~2
        return a; 
    }
    
    void QuizLoad(){
        //ランダムに選択されたイベントNo.の問題文を読み込む
        QuizSentence.text = Edata.GetComponent<Event_Data>().EventData[a[no]][2];
        Change = Rand();
        if(Change == 1) //正解
        {
            //ランダムに選択されたイベントNo.の正解選択肢を読み込む
            cleartext.text = Edata.GetComponent<Event_Data>().EventData[a[no]][7];
            //ランダムに選択されたイベントNo.の不正解選択肢を読み込む
            failtext.text = Edata.GetComponent<Event_Data>().EventData[a[no]][8];
            Debug.Log("Change = 1");
        }
        else if(Change == 2) //不正解
        {
            //ランダムに選択されたイベントNo.の不正解選択肢を読み込む
            cleartext.text = Edata.GetComponent<Event_Data>().EventData[a[no]][8];
            //ランダムに選択されたイベントNo.の正解選択肢を読み込む
            failtext.text = Edata.GetComponent<Event_Data>().EventData[a[no]][7];
            Debug.Log("Change = 2");
        }
    }

    public void Buttondown1(){
        Change2 = 1;
    }

    public void Buttondown2(){
        Change2 = 2;
    }

    void Answer(){
        if(Change==Change2){
            Debug.Log("正解");
        }else{
            Debug.Log("不正解");
        }
    }

    public void AnswerButtonDown(){
        Answer();
        no++;
        if(no > 9){
            SceneManager.LoadScene("SelectScene");
        }
        else{
        QuizLoad();
        NoSet();
        }
       
    }




    void Shuffle(){
        int x = 16;
        int[] b = new int[x];
        for(int i=0;i<x;i++){
            b[i]=i+3;
        }
        b = b.OrderBy(y => System.Guid.NewGuid()).ToArray();
        for(int i=0;i<10;i++){
            a[i]=b[i];
            Debug.Log(a[i]);
        }
        
    }
}
