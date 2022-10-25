using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using static System.Console;
using System;

public class Checks_save : MonoBehaviour
{
    public Toggle t0;
    public Toggle t1;
    public Toggle t2;
    public Toggle t3;
    public Toggle t4;
    public Toggle t5;
    public Toggle t6;
    public Toggle t7;
    public Toggle t8;
    public Toggle t9;
    public Toggle t10;
    public Toggle t11;
    public Toggle t12;
    public Toggle t13;
    public Toggle t14;
    public Toggle t15;
    public Toggle t16;
    string[] t = new string[17];
    private StreamWriter sw;



    public async void save(){

        if(t0.isOn) t[0] = "true"; 
        else t[0] = "false";

        if(t1.isOn) t[1] = "true"; 
        else t[1] = "false";

        if(t2.isOn) t[2] = "true"; 
        else t[2] = "false";

        if(t3.isOn) t[3] = "true"; 
        else t[3] = "false";

        if(t4.isOn) t[4] = "true"; 
        else t[4] = "false";

        if(t5.isOn) t[5] = "true"; 
        else t[5] = "false";

        if(t6.isOn) t[6] = "true"; 
        else t[6] = "false";

        if(t7.isOn) t[7] = "true";
        else t[7] = "false";

        if(t8.isOn) t[8] = "true"; 
        else t[8] = "false";

        if(t9.isOn) t[9] = "true"; 
        else t[9] = "false";

        if(t10.isOn) t[10] = "true"; 
        else t[10] = "false";

        if(t11.isOn) t[11] = "true"; 
        else t[11] = "false";

        if(t12.isOn) t[12] = "true"; 
        else t[12] = "false";

        if(t13.isOn) t[13] = "true"; 
        else t[13] = "false";

        if(t14.isOn) t[14] = "true"; 
        else t[14] = "false";

        if(t15.isOn) t[15] = "true"; 
        else t[15] = "false";

        if(t16.isOn) t[16] = "true"; 
        else t[16] = "false";
        sw = new StreamWriter(@"Assets/Resources/Texts/Bichiku_checks.csv", false);
        string[] s1 = t;
        string s2 = string.Join(",", s1);
        await sw.WriteLineAsync(s2);
        sw.Close();
        Debug.Log("saved!"); 
    }
}
