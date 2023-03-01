using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownButton : MonoBehaviour
{
    public Toggle toggle;
    public GameObject[] ItemBox;
    public GameObject content14;
    public Scrollbar scroll;

    public void OffToggleChanged(){
        if(toggle.isOn == false){
        ItemBox = GameObject.FindGameObjectsWithTag("Itembox");
        int i = ItemBox.Length - 1;
        Debug.Log(i);
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
        content14.GetComponent<RectTransform>().sizeDelta = new Vector2 ((content14.GetComponent<RectTransform>().sizeDelta.x),(content14.GetComponent<RectTransform>().sizeDelta.y + 444f));
        if(transform.parent.name == ItemBox[33].name){
            for(int j  = 0 ; j < 5 ; j++){
                    scroll.value = scroll.value - 1;
            }
        }
        }
    }
    public void OnToggleChanged(){
        if(toggle.isOn){
        ItemBox = GameObject.FindGameObjectsWithTag("Itembox");

        int i = ItemBox.Length - 1;
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
        content14.GetComponent<RectTransform>().sizeDelta = new Vector2 ((content14.GetComponent<RectTransform>().sizeDelta.x),(content14.GetComponent<RectTransform>().sizeDelta.y - 444f));
        }
    }
}
