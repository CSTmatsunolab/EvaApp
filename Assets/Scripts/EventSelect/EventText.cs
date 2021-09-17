using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class EventText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject event_object = null;
    void Start()
    {
        GameObject EData = GameObject.Find("EventData");
        Text title_text = event_object.GetComponent<Text>();
        //ランダムに選択されたイベントNo.の概要を読み込む
        title_text.text=EData.GetComponent<Event_Data>().EventData[ESManagement.index][2];

        
    }
}