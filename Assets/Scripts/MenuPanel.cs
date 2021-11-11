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
    [SerializeField] GameObject Explanation;
    GameObject Pdata;
    static public int flag = 0;



    void Start()
    {
        BackToMenu();
        BackToDrink();
        EventClose();
        RandomEvent();
        ExplanationClose();
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

    public void GoToExplanation()
    {
        Explanation.SetActive(true); //説明を表示
    }

    public void ExplanationClose()
    {
        Explanation.SetActive(false); //説明を非表示
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
        if(i == 1){
            int a = Random.Range(1,100);
            Debug.Log(a);
            if(a >= 33){
                Event.SetActive(true);
            }
        }
    }

    private void StartExplanation() //起動時に説明を表示
    {
        PdataLoad();
        int y = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][8]);
        if(y == 0)
        {
            Explanation.SetActive(true);
        }
    }


    //行動するボタンからイベント選択画面に遷移する場合
    public void GoButtonDown(){
        flag = 0;
        SceneManager.LoadScene("EventSelectScene");//イベント選択画面に遷移
    }

    //ランダムイベントんお進むボタンからイベント選択画面に遷移する場合
    public void GoButtonDown2(){
        flag = 1;
        SceneManager.LoadScene("EventSelectScene");//イベント選択画面に遷移
    }

    static public int Send(){
        return flag;
    }


}
