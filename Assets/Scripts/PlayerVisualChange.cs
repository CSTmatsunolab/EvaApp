using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class PlayerVisualChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    public Sprite onaka_heru_man;
    public Sprite utsu_man;
    public Sprite sick_kokoro_yamu_man;
    public Sprite nodo_kawaku_dassui_man;

    private Sprite sprite;
    private GameObject Pdata = null;
    int manpuku = 0;//まんぷくゲージ
    int anshin = 0;//安心ゲージ
    int suibun = 0;//水分

    // Start is called before the first frame update
    void Start()
    {
        Pdata = GameObject.Find("Player_Data");
        manpuku = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][0]);
        anshin = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][1]);
        suibun = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][2]);

    }
 
    // Update is called once per frame
    void Update () {
        if (manpuku < 4) //満腹だけが３以下
        {
            image.enabled = true;
            image.sprite = onaka_heru_man;
        }
        if (anshin < 4) //安心だけが３以下
        {
            image.enabled = true;
            image.sprite = utsu_man;
        }
        if (manpuku < 4 && anshin < 4) //満腹と安心が３以下
        {
            image.enabled = true;
            image.sprite = sick_kokoro_yamu_man;
        }
        if (anshin < 4 && suibun < 1) //安心が３以下かつ水分が０
        {
            image.enabled = true;
            image.sprite = nodo_kawaku_dassui_man;
        }
        if (manpuku < 4 && suibun < 1) //満腹が３以下かつ水分が０
        {
            image.enabled = true;
            image.sprite = nodo_kawaku_dassui_man;
        }
        if (suibun < 1) //水分が０
        {
            image.enabled = true;
            image.sprite = nodo_kawaku_dassui_man;
        }
        else //通常
        {
            image.enabled = true;
        }
        
    }
    
}
