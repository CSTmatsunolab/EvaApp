using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingManagement : MonoBehaviour
{
    GameObject Pdata;
    public Text ResultText;
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
        PdataLoad();
        ResultText.text = "避難所名：" + Pdata.GetComponent<Player_Data>().PlayerData[1][9]+"\n"
                        + "名前：" + Pdata.GetComponent<Player_Data>().PlayerData[1][10]+"\n"
                        + "経過日数：" + Pdata.GetComponent<Player_Data>().PlayerData[1][5]+"日"+"\n"
                        + "クイズ正解数：" + (QuizManagement.Send()).ToString()+"問";
    }
}
