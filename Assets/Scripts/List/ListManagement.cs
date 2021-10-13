using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ListManagement : MonoBehaviour
{
    public Text Kanpan;
    public Text Mizu;
    public GameObject Content;
    GameObject[] ListButton;
    GameObject btn;
    GameObject Edata;
    GameObject Pdata;
    GameObject Rdata;
    Image btnimg;
    Text btntext;
    // Start is called before the first frame update
    void Start(){
        TextLoad();
        ListButtonMake();
    }

    private void PdataLoad(){
        Pdata = GameObject.Find("Player_Data");
    }

    private void EdataLoad(){
        Edata = GameObject.Find("EventData");
    }
    
    private void RdataLoad(){
        Rdata = GameObject.Find("ResultData");
    }
    

    private void TextLoad(){
        PdataLoad();
        Kanpan.text = Pdata.GetComponent<Player_Data>().PlayerData[1][3];
        Mizu.text = Pdata.GetComponent<Player_Data>().PlayerData[1][4];
    }

    private void ListButtonMake(){
        EdataLoad();
        RdataLoad();
        int a = Edata.GetComponent<Event_Data>().EventData.Count-1;
        int b = 0;
        btn = (GameObject)Resources.Load("Prefabs/Button");
        ListButton = new GameObject[a];
        for (int i = 0 ;i < a;i++){
            
            ListButton[i] = Instantiate(btn);
            ListButton[i].transform.SetParent(Content.transform,false);
            btnimg = ListButton[i].transform.Find("Image").gameObject.GetComponent<Image>();
            btntext = ListButton[i].transform.Find("Text").gameObject.GetComponent<Text>();
            b = int.Parse(Rdata.GetComponent<Result_Data>().ResultData[i+1][1]);
            if(b == 0){
                ListButton[i].GetComponent<Button>().interactable = false;
                btntext.text = "???";
                btnimg.sprite = Resources.Load<Sprite>("Sprites/NoImage");
            }
            else{
                btnimg.sprite = Resources.Load<Sprite>("Sprites/Event"+(i+1).ToString());
                btntext.text = Edata.GetComponent<Event_Data>().EventData[i+1][1];
            }
        }

    }
}
