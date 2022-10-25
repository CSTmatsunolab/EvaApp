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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save(){
        sw = new StreamWriter(@"Assets/Resources/Texts/Bichiku_days.csv", false);
        string[] s1 = {iF_y1.text,iF_m1.text,iF_d1.text};
        string[] s2 = {iF_y2.text,iF_m2.text,iF_d2.text};
        string s3 = string.Join(",", s1);
        string s4 = string.Join(",", s2);
        sw.WriteLine(s3);
        sw.WriteLine(s4);
        sw.Close();
    }
}
