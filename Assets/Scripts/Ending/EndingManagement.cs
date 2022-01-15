using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class EndingManagement : MonoBehaviour
{
    GameObject Pdata;
    GameObject Rdata;
    public Text ResultText;
    public Text ScoreText;
    public Text PName;
    public Image ScoreImage;
    public Sprite S;
    public Sprite A;
    public Sprite B;
    public Sprite C;

    public GameObject Cloud;
    public GameObject Score;
    public GameObject Result;
    public GameObject Endroll;
    public GameObject NextButton;
    public Animator ScorePoints;
    int ScorePoint;
    private string path;
    private string path2;
    
    // Start is called before the first frame update
    void Start()
    {
        TextSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PdataLoad(){
        Pdata = GameObject.Find("Player_Data");
    }

    private void RdataLoad(){
        Rdata = GameObject.Find("ResultData");
    }

    private void TextSet(){
        Score.SetActive(false);
        Endroll.SetActive(false);
        PdataLoad();
        ResultText.text = "避難所名：" + Pdata.GetComponent<Player_Data>().PlayerData[1][9]+"\n"
                        + "名前：" + Pdata.GetComponent<Player_Data>().PlayerData[1][10]+"\n"
                        + "経過日数：" + Pdata.GetComponent<Player_Data>().PlayerData[1][5]+"日"+"\n"
                        + "クイズ正解数：" + (QuizManagement.Send()).ToString()+"問";
        ScoreCalculation();
        ScoreOutput(ScorePoint);
    }

    private void ScoreCalculation(){
        int Correct = QuizManagement.Send();
        int Manpuku = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][0]);
        int Stress = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][1]);
        int Water = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][2]);

        Correct = Correct * 1000;
        Manpuku = Cal(Manpuku);
        Stress = Cal(Stress);
        Water = Cal(Water); 
        ScorePoint = Correct + Manpuku + Stress + Water;
        ScoreText.text = ScorePoint.ToString();
    } 

    public void CloudPanelClose(){
        Cloud.SetActive(false);
        NextButton.SetActive(false);
        Score.SetActive(true);
        ScorePoints.SetTrigger("PanelOn");
        NextButton.SetActive(true);
    }

    private int Cal(int a){
        a = a * 100;
        return a;
    }

    private void ScoreOutput(int a){
        if(a>=10000){
            ScoreImage.sprite = S;
        }else if(a>=8000){
            ScoreImage.sprite = A;
        }else if(a>=6000){
            ScoreImage.sprite = B;
        }else{
            ScoreImage.sprite = C;
        }
    }

    public void next(){
        PName.text = Pdata.GetComponent<Player_Data>().PlayerData[1][10];

        Endroll.SetActive(true);
        Result.SetActive(false);
        Reset();
    }
    
    public void GoToTitle()
    {
        SceneManager.LoadScene("StartScene");//スタートシーンに遷移
    }
    private void EndCheck(){
        int a = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][8]);
        Rdata.GetComponent<Result_Data>().ResultData[a][1]="1";

    }

    private void Reset(){
        RdataLoad();
        EndCheck();
        Pdata.GetComponent<Player_Data>().PlayerData[1][0] = "5";
        Pdata.GetComponent<Player_Data>().PlayerData[1][1] = "5";
        Pdata.GetComponent<Player_Data>().PlayerData[1][2] = "3";
        Pdata.GetComponent<Player_Data>().PlayerData[1][3] = "3";
        Pdata.GetComponent<Player_Data>().PlayerData[1][4] = "3";
        Pdata.GetComponent<Player_Data>().PlayerData[1][5] = "1";
        Pdata.GetComponent<Player_Data>().PlayerData[1][6] = "0";
        Pdata.GetComponent<Player_Data>().PlayerData[1][7] = "0";
        Pdata.GetComponent<Player_Data>().PlayerData[1][8] = "0";
        Pdata.GetComponent<Player_Data>().PlayerData[1][9] = "避難所";
        Pdata.GetComponent<Player_Data>().PlayerData[1][10] = "あなた";
        Pdata.GetComponent<Player_Data>().PlayerData[1][11] = "0" ;
        Pdata.GetComponent<Player_Data>().PlayerData[1][12] = "0" ;
        for(int i=3;i<=48;i++){
            Rdata.GetComponent<Result_Data>().ResultData[i][1]="0";
        }
        CsvSave();
        EventSave();   
    }

    private void CsvSave()
    {
        path = Application.persistentDataPath + "/PlayerData.csv";
        StreamWriter file = new StreamWriter(path,false);
        for (var y=0; y < 2; y++)
        {
            for(var x=0; x < 13; x++)
            {
                file.Write(Pdata.GetComponent<Player_Data>().PlayerData[y][x]+",");
                file.Flush();
            }
            file.WriteLine();
        }
    }
    private void EventSave()
    {
        path2 = Application.persistentDataPath + "/EventResult.csv";
        StreamWriter file = new StreamWriter(path2,false);
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
