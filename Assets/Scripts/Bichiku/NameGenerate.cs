using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

public class NameGenerate : MonoBehaviour
{
    public GameObject[] Name;
    public GameObject[] Explain;
    int i;
    int y = 0;
    static List<string[]> nameData = new List<string[]>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(y == 0){
            naming();
        }
        
    }

    void naming(){
        nameData = File.ReadAllLines(@"Assets/Resources/Texts/ItemName.csv").Select(line => line.Split(',')).ToList();
        Name = GameObject.FindGameObjectsWithTag("IName");
        Explain = GameObject.FindGameObjectsWithTag("IExplain");
        int j = Name.Length;
        for(i = 0; i < j; i++){
            Name[i].GetComponent<UnityEngine.UI.Text>().text  = nameData[i][0];
            Explain[i].GetComponent<UnityEngine.UI.Text>().text  = nameData[i][1];
        }
        y = 1;
    }
}
