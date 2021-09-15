using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class KanpanQuantity : MonoBehaviour
{
    public GameObject name_object = null;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject Pdata = GameObject.Find("Eat_Data");
        // オブジェクトからTextコンポーネントを取得
        //Text sta_text = name_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        //sta_text.text = (" × " + Pdata.GetComponent<Eat_Data>().EatData[1][0] + " 個 " );
    }

    // 更新
    void Update()
    {
        GameObject Pdata = GameObject.Find("Eat_Data");
        // オブジェクトからTextコンポーネントを取得
        Text sta_text = name_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        sta_text.text = (" × " + Pdata.GetComponent<Eat_Data>().EatData[1][0] + " 個 ");
    }
}