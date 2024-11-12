using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Days_save : MonoBehaviour
{
    private StreamWriter sw;
    public InputField iF_y1;
    public InputField iF_m1;
    public InputField iF_d1;
    public InputField iF_y2;
    public InputField iF_m2;
    public InputField iF_d2;
    public InputField iF_y3;
    public InputField iF_m3;
    public InputField iF_d3;
    // Start is called before the first frame update
 
    private GameObject Bdata;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save(){
    Bdata = GameObject.Find("BagData");
    string path = Application.persistentDataPath + "/Bichiku_days.csv";
    
    // 1. まずInputFieldの値を取得
    string[] s1 = {iF_y1.text,iF_m1.text,iF_d1.text};
    string[] s2 = {iF_y2.text,iF_m2.text,iF_d2.text};
    string[] s3 = {iF_y3.text,iF_m3.text,iF_d3.text};

    // 空でない値のみ保存するように修正
    // 2. CSVファイルに保存
    using (var fs = new StreamWriter(path, false, System.Text.Encoding.GetEncoding("UTF-8")))
    {
    // 1行目の処理
    string line1;
    if (!string.IsNullOrEmpty(s1[0])) {
        line1 = string.Join(",", s1);
    } else {
        line1 = string.Join(",", Bdata.GetComponent<Days_Data>().DaysData[0]);
    }
    fs.WriteLine(line1);
    
    // 2行目の処理
    string line2;
    if (!string.IsNullOrEmpty(s2[0])) {
        line2 = string.Join(",", s2);
    } else {
        line2 = string.Join(",", Bdata.GetComponent<Days_Data>().DaysData[1]);
    }
    fs.WriteLine(line2);
    
    // 3行目の処理
    string line3;
    if (!string.IsNullOrEmpty(s3[0])) {
        line3 = string.Join(",", s3);
    } else {
        line3 = string.Join(",", Bdata.GetComponent<Days_Data>().DaysData[2]);
    }
    fs.WriteLine(line3);
}

    // 3. BagDataのDaysDataを更新
    for(int i = 0; i < 3; i++) {
        if (!string.IsNullOrEmpty(s1[i])) {
            Bdata.GetComponent<Days_Data>().DaysData[0][i] = s1[i];
        }
        if (!string.IsNullOrEmpty(s2[i])) {
            Bdata.GetComponent<Days_Data>().DaysData[1][i] = s2[i];
        }
        if (!string.IsNullOrEmpty(s3[i])) {
            Bdata.GetComponent<Days_Data>().DaysData[2][i] = s3[i];
        }
    }

    Debug.Log("Saved to both file and BagData!"); 
}
}
