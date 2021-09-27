using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class MenuPanel : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Drink;


    void Start()
    {
        BackToMenu();
        BackToDrink();
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


}
