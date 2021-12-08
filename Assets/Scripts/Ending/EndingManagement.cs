using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingManagement : MonoBehaviour
{
    GameObject Pdata;
    public Text ResultText;
    public Text ScoreText;
    public Image ScoreImage;
    public Sprite S;
    public Sprite A;
    public Sprite B;
    public Sprite C;

    public GameObject Cloud;
    public GameObject Score;
    public Animator ScorePoints;
    int ScorePoint;
    
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

    private void TextSet(){
        Score.SetActive(false);
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
        Score.SetActive(true);
        ScorePoints.SetTrigger("PanelOn");
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
}
