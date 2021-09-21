using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EventImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Image image;
        image=this.GetComponent<Image>();
        //ランダムに選択されたイベントNo.のイラストを読み込む
        int i=ESManagement.index;
        string str=i.ToString();
        image.sprite=Resources.Load<Sprite>(str);
    }
}
