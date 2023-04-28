using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Name_Text : MonoBehaviour{
    //GameObject Event;
    GameObject Bdata;
    GameObject ItemName;
    GameObject ItemExplain;
    int y = 0;

    void Update()
    {
        if(y == 0){
            naming();
        }
        
    }

    private void BdataLoad(){
        Bdata = GameObject.Find("BagData");
    }
        
    void naming(){
        BdataLoad();
        ItemName = transform.Find("Item").gameObject;
        ItemExplain = transform.Find("Item explain").gameObject;;
        int a = int.Parse(this.name);    //イベント画像までのパスを作ってる
        ItemName.GetComponent<Text>().text = Bdata.GetComponent<NameGenerate>().nameData[a][0];
        ItemExplain.GetComponent<Text>().text = Bdata.GetComponent<NameGenerate>().nameData[a][1];
        y = 1;
    }
}
