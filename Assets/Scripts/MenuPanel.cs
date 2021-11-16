using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class MenuPanel : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Drink;
    [SerializeField] GameObject Event;
    [SerializeField] GameObject GaugeExplanation;//説明パネル1
    [SerializeField] GameObject GaugeExplanation2;//説明パネル2
    [SerializeField] GameObject CharacterExplanation;//説明パネル3
    [SerializeField] GameObject ButtonExplanation;//説明パネル4
    GameObject Pdata;
    static public int flag = 0;//行動するボタンからイベント選択画面に行くか、ランダムイベントからイベント選択画面に行くか
    static public int Randflag = 0;



    void Start()
    {
        BackToMenu();
        BackToDrink();
        EventClose();
        RandomEvent();
        AllExplanationClose();
        OpenGaugeExplanation();
    }

    public void BackToMenu()
    {
        Menu.SetActive(false);//Menuパネルを非表示
    }

    public void GoToMenu()
    {
        Menu.SetActive(true);//Menuパネルを表示
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("StartScene");//スタートシーンに遷移
    }

    public void GoToDrink()
    {
        Drink.SetActive(true);//Drinkパネルを表示
    }

    public void BackToDrink()
    {
        Drink.SetActive(false);//Drinkパネルを非表示
    }

    public void GoToGaugeExplanation()
    {
        GaugeExplanation.SetActive(true); //説明パネル1を表示
        GaugeExplanation2.SetActive(false); //説明パネル2を非表示
    }

    public void GoToGaugeExplanation2()
    {
        GaugeExplanation2.SetActive(true); //説明パネル2を表示
        GaugeExplanation.SetActive(false); //説明パネル1を非表示
        CharacterExplanation.SetActive(false); //説明パネル3を非表示
    }
    
    public void GoToCharacterExplanation()
    {
        CharacterExplanation.SetActive(true); //説明パネル3を表示
        GaugeExplanation2.SetActive(false); //説明パネル2を非表示
        ButtonExplanation.SetActive(false); //説明パネル4を非表示
    }

    public void GoToButtonExplanation()
    {
        ButtonExplanation.SetActive(true); //説明パネル4を表示
        CharacterExplanation.SetActive(false); //説明パネル3を非表示
    }

    public void GaugeExplanationClose()
    {
        GaugeExplanation.SetActive(false); //説明パネル1を非表示
    }

    public void GaugeExplanation2Close()
    {
        GaugeExplanation2.SetActive(false); //説明パネル2を非表示
    }

    public void CharacterExplanationClose()
    {
        CharacterExplanation.SetActive(false); //説明パネル3を非表示
    }

    public void ButtonExplanationClose()
    {
        ButtonExplanation.SetActive(false); //説明パネル4を非表示
    }

    public void AllExplanationClose()
    {
        ButtonExplanation.SetActive(false); //説明を非表示
        CharacterExplanation.SetActive(false); 
        GaugeExplanation.SetActive(false);
        GaugeExplanation2.SetActive(false);
    }

    private void EventClose()
    {
        Event.SetActive(false);
    }

    private void PdataLoad(){
        Pdata = GameObject.Find("Player_Data");
    }

    private void RandomEvent(){
        PdataLoad();
        int i = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][6]);
        if(i == 0){
            Randflag = 0;
        }
        if(i == 1){
            int a = Random.Range(1,100);
            Debug.Log(a);
            if(Randflag == 0){
                if(a >= 33){
                    Randflag = 1;
                    Event.SetActive(true);
                }
            }
            
        }
    }

    private void OpenGaugeExplanation() //起動時に説明パネル1を表示
    {
        PdataLoad();
        int x = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][5]);
        int y = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][6]);
        if(x == 2)
        {
            if(y == 0)
            {
                GaugeExplanation.SetActive(true);
            }
        }
    }


    //行動するボタンからイベント選択画面に遷移する場合
    public void GoButtonDown(){
        flag = 0;
        SceneManager.LoadScene("EventSelectScene");//イベント選択画面に遷移
    }

    //ランダムイベントの進むボタンからイベント選択画面に遷移する場合
    public void GoButtonDown2(){
        flag = 1;
        SceneManager.LoadScene("EventSelectScene");//イベント選択画面に遷移
    }

    static public int Send(){
        return flag;
    }
}
