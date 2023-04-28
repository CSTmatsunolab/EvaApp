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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save(){
        
        string path = Application.persistentDataPath + "/Bichiku_days.csv";
        string[] s1 = {iF_y1.text,iF_m1.text,iF_d1.text};
        string[] s2 = {iF_y2.text,iF_m2.text,iF_d2.text};
        string[] s3 = {iF_y3.text,iF_m3.text,iF_d3.text};
        string s4 = string.Join(",", s1);
        string s5 = string.Join(",", s2);
        string s6 = string.Join(",", s3);
        using (var fs = new StreamWriter(path, false, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            fs.Write(s4);
            fs.Flush();
            fs.WriteLine();
            fs.Write(s5);
            fs.Flush();
            fs.WriteLine();
            fs.Write(s6);
            fs.Flush();
            fs.WriteLine();
        }
    }
}
