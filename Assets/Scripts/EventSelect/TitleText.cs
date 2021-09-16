using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class TitleText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject title_object = null;
    void Start()
    {
        GameObject EData = GameObject.Find("EventData");
        Text title_text = title_object.GetComponent<Text>();
        title_text.text=EData.GetComponent<Event_Data>().EventData[ESManagement.index][1];

        
    }
}