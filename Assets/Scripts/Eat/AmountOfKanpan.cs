using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountOfKanpan : MonoBehaviour
{
    public GameObject Amount = null;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Pdata = GameObject.Find("Player_Data");
        // オブジェクトからTextコンポーネントを取得
        Text Atext = Amount.GetComponent<Text>();
        // テキストの表示を入れ替える
        Atext.text = "現在の食料の数:"+ Pdata.GetComponent<Player_Data>().PlayerData[1][4] + "個" ;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
