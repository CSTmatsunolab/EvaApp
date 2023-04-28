using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

public class NameGenerate : MonoBehaviour
{
    TextAsset csvFile;
    // public GameObject[] Name;
    // public GameObject[] Explain;
    // int i;
    // int y = 0;
    public List<string[]> nameData = new List<string[]>();

    // Start is called before the first frame update
    void Start()
    {
        csvFile = Resources.Load("ItemName") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            nameData.Add(line.Split(',')); // , 区切りでリストに追加
        }
        // Name = GameObject.FindGameObjectsWithTag("IName");
        // Explain = GameObject.FindGameObjectsWithTag("IExplain");
        // int j = Name.Length;
        // for(i = 0; i < j; i++){
        //     Name[i].GetComponent<UnityEngine.UI.Text>().text  = nameData[i][0];
        //     Explain[i].GetComponent<UnityEngine.UI.Text>().text  = nameData[i][1];
        // }
    }

    // Update is called once per frame
}
