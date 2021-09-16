using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 追加

public class TimeBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトの取得
        GameObject image_object = GameObject.Find("TimeBase");
        GameObject Pdata = GameObject.Find("Player_Data");
        // コンポーネントの取得
        Image image_component = image_object.GetComponent<Image>();
        Texture2D texture0 = Resources.Load("hiru") as Texture2D;
        Texture2D texture1 = Resources.Load("yoru") as Texture2D;
        
        int i = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][6]);
        if (i == 0)
            {
                image_component.sprite = Sprite.Create(texture0,new Rect(0, 0, texture0.width, texture0.height),Vector2.zero);
            }
        else if(i == 1)
            {
                image_component.sprite = Sprite.Create(texture1,new Rect(0, 0, texture1.width, texture1.height),Vector2.zero);
            }
    }
}
