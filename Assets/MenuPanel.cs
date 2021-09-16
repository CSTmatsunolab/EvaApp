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
        Menu.SetActive(false);
    }

    public void GoToMenu()
    {
        Menu.SetActive(true);
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void GoToDrink()
    {
        Drink.SetActive(true);
    }

    public void BackToDrink()
    {
        Drink.SetActive(false);
    }


}
