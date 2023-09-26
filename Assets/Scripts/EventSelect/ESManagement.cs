using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;//乱数生成のために追加
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;


public class ESManagement : MonoBehaviour
{
    TextAsset csvFile;
    [SerializeField] GameObject EventBackground;//イベント選択画面の背景画像UI
    [SerializeField] GameObject EventImage;//イベントの画像UI
    [SerializeField] GameObject TitleText;//イベントのタイトルのTextUI
    [SerializeField] GameObject EventText;//イベントの問題文のTextUI
    [SerializeField] GameObject ClearText;//正解の選択肢のTextUI
    [SerializeField] GameObject FailText;//不正解の選択肢のTextUI
    [SerializeField] GameObject Mondaitext;//不正解の選択肢のTextUI
    [SerializeField] GameObject Sentakutext;//不正解の選択肢のTextUI
    [SerializeField] GameObject Answer1text;//イベントのタイトルのTextUI
    [SerializeField] GameObject Answer2text;//イベントの問題文のTextUI
    [SerializeField] GameObject Answer3text;//正解の選択肢のTextUI
    [SerializeField] GameObject Answer4text;//不正解の選択肢のTextUI
    string[] kaitou = new string[4];
    public GameObject yontaku;
    public Image Maru;//まるの画像
    public Image Batsu;//ばつの画像

    [SerializeField] private string spritesDirectory = "Sprites/Event";//イベント画像が保存されているフォルダへのパス
    private GameObject Rdata;//イベント閲覧フラグのオブジェクト
    private GameObject Bdata;
    private GameObject Pdata;

    public static int index = 0;//イベントのナンバー
    public static int Answer = 0;//イベントの回答
    private int Transform = 0;//
    int[] array={0,0,0,0};
    int[] A = {10,11,12,13};
    int[] B = {14,15,16,17};


    [SerializeField] private AudioSource SEplayer;//EventSelectManagementのAudioSourceコンポーネント
    [SerializeField] private AudioClip SeikaiSE;//正解のSE
    [SerializeField] private AudioClip FuseikaiSE;//不正解のSE

    static List<string[]> checksData = new List<string[]>();

    // Start is called before the first frame update
    void Start(){
        index = rand();//乱数生成
/*        if (index >= 41 && index <= 55) {
            do {
                index++;
            } while (index >= 48 && index <= 53);
        }   */
        Debug.Log(index);//コンソールにイベントNo.を表示
        Transform = Random.Range(1,3);//1~2
        Debug.Log(Transform);
        EventLoad(index);
        Maru.gameObject.SetActive(false);
        Batsu.gameObject.SetActive(false);
    }

    //ResultData読み込み
    private void RdataLoad(){
        Rdata = GameObject.Find("ResultData");
        Bdata = GameObject.Find("BagData");
        Pdata = GameObject.Find("Player_Data");
    }

    //乱数(イベントのナンバー)を生成
    int rand(){
        RdataLoad();
        int flag = MenuPanel.Send();
        int a = 0; //indexに入る値
        int b = 0;
        int kaburiCheck = 2;
        //csvFile = Resources.Load("Bichiku_checks") as TextAsset; // Resouces下のCSV読み込み
        // StringReader reader = new StringReader(csvFile.text);

        // while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        // {
        //     string line = reader.ReadLine(); // 一行ずつ読み込み
        //     checksData.Add(line.Split(',')); // , 区切りでリストに追加
        // }

        if(flag == 0)
        {

            a = Random.Range(3,50);//3~40
            //a = 56;
            //a = Random.Range(21,23);//指定範囲の動作確認用
            Debug.Log(a);

            kaburiCheck = int.Parse(Rdata.GetComponent<Result_Data>().ResultData[a][1]);
            Debug.Log("kaburiCheck = " + kaburiCheck);

            for(int i = 0;i < 20;i++) //もし解放済みのイベントだった場合、再抽選 最大5回
                                    //実験にあたってなるべく被らせたくないので15回に
            {
                if(kaburiCheck == 1)
                {
                    a = Random.Range(3,50);//3~40
                    //a = Random.Range(21,23);//指定範囲の動作確認用
                    //a = 50;
                    kaburiCheck = int.Parse(Rdata.GetComponent<Result_Data>().ResultData[a][1]);
                    Debug.Log("a1 = " + a);
                }
            }

        }
        else if(flag == 1){
            b = Random.Range(0,6);
            //a = Random.Range(3,41);//3~29
            if(b < 5) {
                a = Random.Range(50,60);
            } else{
                a = Random.Range(3,50);
            }

            kaburiCheck = int.Parse(Rdata.GetComponent<Result_Data>().ResultData[a][1]);
            Debug.Log("kaburiCheck = " + kaburiCheck);
            for(int i = 0;i < 3;i++) //もし解放済みのイベントだった場合、再抽選 最大5回
                                        //今回は15回
            {
                if(kaburiCheck == 1)
                {
                    a = Random.Range(50,60);
                    kaburiCheck = int.Parse(Rdata.GetComponent<Result_Data>().ResultData[a][1]);
                    Debug.Log("a1 = " + a);
                }
            }

            for(int i = 0;i < 20;i++) //もし解放済みのイベントだった場合、再抽選 最大5回
                                        //今回は15回
            {
                if(kaburiCheck == 1)
                {
                    a = Random.Range(3,50);//3~40
                    kaburiCheck = int.Parse(Rdata.GetComponent<Result_Data>().ResultData[a][1]);
                    Debug.Log("a1 = " + a);
                }
            }
        }
        else if(flag == 4){
            //a = 101;
            a = Random.Range(50,60);
            Pdata.GetComponent<Player_Data>().PlayerData[1][8] = a.ToString();
            // kaburiCheck = int.Parse(Rdata.GetComponent<Result_Data>().ResultData[a][1]);
            // Debug.Log("kaburiCheck = " + kaburiCheck);
            // for(int i = 0;i < 3;i++) //もし解放済みのイベントだった場合、再抽選 最大5回
            //                             //今回は15回
            // {
            //     if(kaburiCheck == 1)
            //     {
            //         a = Random.Range(48,51);
            //         kaburiCheck = int.Parse(Rdata.GetComponent<Result_Data>().ResultData[a][1]);
            //         Debug.Log("a1 = " + a);
            //     }
            // }
        }
        else if(flag == 3){
            a = 100;//配給用のイベント
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

            //ランダムに選択されたイベントNo.の概要を読み込む
            eventtext.text = EData.GetComponent<Event_Data>().EventData[a][2];

            //ランダムに選択されたイベントNo.の正解選択肢を読み込む
            cleartext.text = EData.GetComponent<Event_Data>().EventData[a][7];
            //ランダムに選択されたイベントNo.の不正解選択肢を読み込む
            failtext.text = EData.GetComponent<Event_Data>().EventData[a][8];

            int Change = 0;
            Change = Transform;
        if(a != 50 && a != 51 && a != 52 &&a != 53 &&a != 54 &&a != 55 &&a != 56 &&a !=57 &&a !=58 &&a !=59){
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
    }

    public void ClearButtonDown()//イベント画面に遷移
    {
        if(index == 50||index == 51||index == 52 ||index == 53 ||index == 54 ||index == 55 ||index == 56||index == 57 ||index == 58 ||index == 59){
            //展開
            yontaku.gameObject.SetActive (true);
            GameObject EData = GameObject.Find("EventData");
            int tempA;
            int tempB;
            Text mondaitext;
            Text answer1text;
            Text answer2text;
            Text answer3text;
            Text answer4text;
            mondaitext = Mondaitext.GetComponent<Text>();
            answer1text = Answer1text.GetComponent<Text>();
            answer2text = Answer2text.GetComponent<Text>();
            answer3text = Answer3text.GetComponent<Text>();
            answer4text = Answer4text.GetComponent<Text>();
            for (int i = 0; i < 4; i++)
            {
                tempA = A[i];
                tempB = B[i];
                int randomIndex = Random.Range(0, 4);
                A[i] = A[randomIndex];
                B[i] = B[randomIndex];
                A[randomIndex] = tempA;
                B[randomIndex] = tempB;
            }

            mondaitext.text = EData.GetComponent<Event_Data>().EventData[index][2];
            answer1text.text = EData.GetComponent<Event_Data>().EventData[index][A[0]];
            answer2text.text = EData.GetComponent<Event_Data>().EventData[index][A[1]];
            answer3text.text = EData.GetComponent<Event_Data>().EventData[index][A[2]];
            answer4text.text = EData.GetComponent<Event_Data>().EventData[index][A[3]];
        }
        if(index != 50 && index != 51 && index != 52 && index != 53 && index != 54 && index != 55 && index != 56 &&index != 57 &&index != 58 &&index != 59){
            int Check = 0;
            Check = Transform;
            if(Check == 1) //正位置　正解
            {
                RdataLoad();
                Rdata.GetComponent<Result_Data>().ResultData[index][1] = "1";
                Rdata.GetComponent<Result_Data>().CsvSave();
                Answer = 0;
                Debug.Log("正解");
                SceneManager.LoadScene("EventScene");
                if(index < 41 || index > 50){
                    SEplayer.PlayOneShot(SeikaiSE);
                    StartCoroutine("Seikai");
                }
            }
            else if(Check == 2) //逆位置　不正解
            {
                RdataLoad();
                Rdata.GetComponent<Result_Data>().ResultData[index][1] = "1";
                Rdata.GetComponent<Result_Data>().CsvSave();
                Answer = 1;
                Debug.Log("不正解");
                SceneManager.LoadScene("EventScene");
                if(index < 41 || index > 50){
                    SEplayer.PlayOneShot(FuseikaiSE);
                    StartCoroutine("Huseikai");
                }
            }
        }
    }

    public void FailButtonDown()//イベント画面に遷移
    {
        if(index == 50 || index == 51 || index == 52 || index == 53 || index == 54 || index == 55 || index == 56|| index == 57 || index == 58 || index == 59){
            GameObject EData = GameObject.Find("EventData");
            int[] ANS = new int[4];
            for (int i = 0; i < 4; i++)
            {
                ANS[i] = int.Parse(EData.GetComponent<Event_Data>().EventData[index][B[i]]);
            }
            if(array[0]==ANS[0] && array[1]==ANS[1] && array[2]==ANS[2] && array[3]==ANS[3]){
                RdataLoad();
                Rdata.GetComponent<Result_Data>().ResultData[index][1] = "1";
                Rdata.GetComponent<Result_Data>().CsvSave();
                Answer = 0;
                Debug.Log("正解");
                SEplayer.PlayOneShot(SeikaiSE);
                StartCoroutine("Seikai");
            }else{
                RdataLoad();
                Rdata.GetComponent<Result_Data>().ResultData[index][1] = "1";
                Rdata.GetComponent<Result_Data>().CsvSave();
                Answer = 1;
                Debug.Log("不正解");
                SEplayer.PlayOneShot(FuseikaiSE);
                StartCoroutine("Huseikai");
            }
        }
        if(index != 50 && index != 51 && index != 52 && index != 53 && index != 54 && index != 55 && index != 56 && index != 57 && index != 58 && index != 59){
            int Check = 0;
            Check = Transform;
            if(Check == 1) //正位置　不正解
            {
                RdataLoad();
                Rdata.GetComponent<Result_Data>().ResultData[index][1] = "1";
                Rdata.GetComponent<Result_Data>().CsvSave();
                Answer = 1;
                Debug.Log("不正解");
                SceneManager.LoadScene("EventScene");
                if(index < 41 || index > 50){
                    SEplayer.PlayOneShot(FuseikaiSE);
                    StartCoroutine("Huseikai");
                }
            }
            else if(Check == 2) //逆位置 正解
            {
                RdataLoad();
                Rdata.GetComponent<Result_Data>().ResultData[index][1] = "1";
                Rdata.GetComponent<Result_Data>().CsvSave();
                Answer = 0;
                Debug.Log("正解");
                SceneManager.LoadScene("EventScene");
                if(index < 41 || index > 50){
                    SEplayer.PlayOneShot(SeikaiSE);
                    StartCoroutine("Seikai");
                }
            }
        }
    }
    public void Answer1ButtonDown(){
        GameObject EData = GameObject.Find("EventData");
        Text sentakutext;
        sentakutext = Sentakutext.GetComponent<Text>();
        if(array[0] == 0){
            array[0] = 1;
            kaitou[0]=EData.GetComponent<Event_Data>().EventData[index][A[0]];
        }
        else{
            array[0] = 0;
            kaitou[0]="";
        }
        sentakutext.text = "";
        for (int i = 0; i < kaitou.Length; i++)
        {
            sentakutext.text = sentakutext.text + kaitou[i] + " "; //テキストの上書き
        }
    }
    public void Answer2ButtonDown(){
        GameObject EData = GameObject.Find("EventData");
        Text sentakutext;
        sentakutext = Sentakutext.GetComponent<Text>();
        if(array[1] == 0){
            array[1] = 1;

            kaitou[1]=EData.GetComponent<Event_Data>().EventData[index][A[1]];
        }
        else{
            array[1] = 0;
            kaitou[1]="";
        }
        sentakutext.text = "";
        for (int i = 0; i < kaitou.Length; i++)
        {
            sentakutext.text = sentakutext.text + kaitou[i] + " "; //テキストの上書き
        }
    }
    public void Answer3ButtonDown(){
        GameObject EData = GameObject.Find("EventData");
        Text sentakutext;
        sentakutext = Sentakutext.GetComponent<Text>();
        if(array[2] == 0){
            array[2] = 1;
            kaitou[2]=EData.GetComponent<Event_Data>().EventData[index][A[2]];
        }
        else{
            array[2] = 0;
            kaitou[2]="";
        }
        sentakutext.text = "";
        for (int i = 0; i < kaitou.Length; i++)
        {
            sentakutext.text = sentakutext.text + kaitou[i] + " "; //テキストの上書き
        }
    }
    public void Answer4ButtonDown(){
        GameObject EData = GameObject.Find("EventData");
        Text sentakutext;
        sentakutext = Sentakutext.GetComponent<Text>();
        if(array[3] == 0){
            array[3] = 1;
            kaitou[3]=EData.GetComponent<Event_Data>().EventData[index][A[3]];
        }
        else{
            array[3] = 0;
            kaitou[3]="";
        }
        sentakutext.text = "";
        for (int i = 0; i < kaitou.Length; i++)
        {
            sentakutext.text = sentakutext.text + kaitou[i] + " "; //テキストの上書き
        }
    }

    IEnumerator Seikai(){//正解の時のアニメーション
        Maru.gameObject.SetActive(true);//MaruをActiveにする
        Color c = Maru.color;
        c.a = 1.3f;
        Maru.color = c; // 画像の不透明度を1にする
        yield return new WaitForSeconds(0.3f);
        while (true)
        {
            yield return null; // 1フレーム待つ
            c.a -= 0.02f;
            Maru.color = c; // 画像の不透明度を下げる

            if (c.a <= 0f) // 不透明度が0以下のとき
            {
                c.a = 0f;
                Maru.color = c; // 不透明度を0
                break; // 繰り返し終了
            }
        }
        Maru.gameObject.SetActive(false); // 画像を非アクティブにする
        SceneManager.LoadScene("EventScene");
    }

    IEnumerator Huseikai(){//不正解の時のアニメーション
        Batsu.gameObject.SetActive(true);//BatsuをActiveにする
        Color c = Batsu.color;
        c.a = 1.3f;
        Batsu.color = c; // 画像の不透明度を1にする
        yield return new WaitForSeconds(0.3f);
        while (true)
        {
            yield return null; // 1フレーム待つ
            c.a -= 0.02f;
            Batsu.color = c; // 画像の不透明度を下げる

            if (c.a <= 0f) // 不透明度が0以下のとき
            {
                c.a = 0f;
                Batsu.color = c; // 不透明度を0
                break; // 繰り返し終了
            }
        }
        Batsu.gameObject.SetActive(false); // 画像を非アクティブにする
        SceneManager.LoadScene("EventScene");
    }

    public static int Send()//イベントナンバーを返す
    {
        return index;
    }

    public static int SendAnswer()//回答を返す
    {
        return Answer;
    }
}