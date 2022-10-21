using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownButton : MonoBehaviour
{
    public Toggle toggle;
    public GameObject[] ItemBox = new GameObject[17];
    public GameObject content14;
    public Scrollbar scroll;

    public void OffToggleChanged(){
        if(toggle.isOn == false){
        ItemBox[0] = GameObject.Find("Itembox0");
        ItemBox[1] = GameObject.Find("Itembox1");
        ItemBox[2] = GameObject.Find("Itembox2");
        ItemBox[3] = GameObject.Find("Itembox3");
        ItemBox[4] = GameObject.Find("Itembox4");
        ItemBox[5] = GameObject.Find("Itembox5");
        ItemBox[6] = GameObject.Find("Itembox6");
        ItemBox[7] = GameObject.Find("Itembox7");
        ItemBox[8] = GameObject.Find("Itembox8");
        ItemBox[9] = GameObject.Find("Itembox9");
        ItemBox[10] = GameObject.Find("Itembox10");
        ItemBox[11] = GameObject.Find("Itembox11");
        ItemBox[12] = GameObject.Find("Itembox12");
        ItemBox[13] = GameObject.Find("Itembox13");
        ItemBox[14] = GameObject.Find("Itembox14");
        ItemBox[15] = GameObject.Find("Itembox15");
        ItemBox[16] = GameObject.Find("Itembox16");

        int i =16;
        bool flag = true;
        while(flag == true){
            print("親の名前は、" + transform.parent.name);
            print("自分は、" + ItemBox[i].name);
            if(ItemBox[i].name != transform.parent.name){
                Vector3 Idou;
                Idou = ItemBox[i].transform.position;
                Idou.y = Idou.y - 2.5f;
                ItemBox[i].transform.position = Idou;
                print("移動した");
            }
            if(ItemBox[i].name == transform.parent.name){
                flag = false;
            }
            i = i - 1;
        }
        content14.GetComponent<RectTransform>().sizeDelta = new Vector2 ((content14.GetComponent<RectTransform>().sizeDelta.x),(content14.GetComponent<RectTransform>().sizeDelta.y + 160f));
        if(transform.parent.name == "Itembox16"){
            for(int j  = 0 ; j < 5 ; j++){
                    scroll.value = scroll.value - 1;
            }
        }
        }
    }
    public void OnToggleChanged(){
        if(toggle.isOn){
        ItemBox[0] = GameObject.Find("Itembox0");
        ItemBox[1] = GameObject.Find("Itembox1");
        ItemBox[2] = GameObject.Find("Itembox2");
        ItemBox[3] = GameObject.Find("Itembox3");
        ItemBox[4] = GameObject.Find("Itembox4");
        ItemBox[5] = GameObject.Find("Itembox5");
        ItemBox[6] = GameObject.Find("Itembox6");
        ItemBox[7] = GameObject.Find("Itembox7");
        ItemBox[8] = GameObject.Find("Itembox8");
        ItemBox[9] = GameObject.Find("Itembox9");
        ItemBox[10] = GameObject.Find("Itembox10");
        ItemBox[11] = GameObject.Find("Itembox11");
        ItemBox[12] = GameObject.Find("Itembox12");
        ItemBox[13] = GameObject.Find("Itembox13");
        ItemBox[14] = GameObject.Find("Itembox14");
        ItemBox[15] = GameObject.Find("Itembox15");
        ItemBox[16] = GameObject.Find("Itembox16");

        int i =16;
        bool flag = true;
        while(flag == true){
            print("親の名前は、" + transform.parent.name);
            print("自分は、" + ItemBox[i].name);
            if(ItemBox[i].name != transform.parent.name){
                Vector3 Idou;
                Idou = ItemBox[i].transform.position;
                Idou.y = Idou.y + 2.5f;
                ItemBox[i].transform.position = Idou;
                print("移動した");
            }   
            if(ItemBox[i].name == transform.parent.name){
                flag = false;
            }
            i = i - 1;
        }
        content14.GetComponent<RectTransform>().sizeDelta = new Vector2 ((content14.GetComponent<RectTransform>().sizeDelta.x),(content14.GetComponent<RectTransform>().sizeDelta.y - 160f));
        }
    }
}
