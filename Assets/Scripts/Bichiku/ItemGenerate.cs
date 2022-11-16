using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;

public class ItemGenerate : MonoBehaviour
{
    int c = 0;
    public Transform Content;
    GameObject prefabf;
    GameObject prefab;

    static List<string[]> itemData = new List<string[]>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(c == 0){
            generateI();
        } 
    }

     void generateI(){
        prefabf = (GameObject)Resources.Load("Prefabs/Itemboxf");
        prefab = (GameObject)Resources.Load("Prefabs/Itembox");
        Vector3 position = new Vector3(0, 0, 0);
        Instantiate (prefabf,position,Quaternion.identity,Content);
        
        itemData = File.ReadAllLines(@"Assets/Resources/Texts/Item_list.csv").Select(line => line.Split(',')).ToList();
         
        c = 1;
     }
}
