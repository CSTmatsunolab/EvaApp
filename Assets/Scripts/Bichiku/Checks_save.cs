using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using static System.Console;
using System.Linq;
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
    public Toggle t17;
    public Toggle t18;
    public Toggle t19;
    public Toggle t20;
    public Toggle t21;
    public Toggle t22;
    public Toggle t23;
    public Toggle t24;
    public Toggle t25;
    public Toggle t26;
    public Toggle t27;
    public Toggle t28;
    public Toggle t29;
    public Toggle t30;
    public Toggle t31;
    public Toggle t32;
    public Toggle t33;
    public GameObject Weight;
    static List<string[]> nameData = new List<string[]>();
    float CurrentWeight;
    string[] ItemWeight = new string[34];
    int i;
    string[] t = new string[34];
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

        if(t17.isOn) t[17] = "true"; 
        else t[17] = "false";

        if(t18.isOn) t[18] = "true"; 
        else t[18] = "false";

        if(t19.isOn) t[19] = "true"; 
        else t[19] = "false";

        if(t20.isOn) t[20] = "true"; 
        else t[20] = "false";

        if(t21.isOn) t[21] = "true"; 
        else t[21] = "false";

        if(t22.isOn) t[22] = "true"; 
        else t[22] = "false";

        if(t23.isOn) t[23] = "true"; 
        else t[23] = "false";

        if(t24.isOn) t[24] = "true"; 
        else t[24] = "false";

        if(t25.isOn) t[25] = "true"; 
        else t[25] = "false";

        if(t26.isOn) t[26] = "true"; 
        else t[26] = "false";

        if(t27.isOn) t[27] = "true"; 
        else t[27] = "false";

        if(t28.isOn) t[28] = "true"; 
        else t[28] = "false";

        if(t29.isOn) t[29] = "true"; 
        else t[29] = "false";

        if(t30.isOn) t[30] = "true"; 
        else t[30] = "false";

        if(t31.isOn) t[31] = "true"; 
        else t[31] = "false";

        if(t32.isOn) t[32] = "true"; 
        else t[32] = "false";

        if(t33.isOn) t[33] = "true"; 
        else t[33] = "false";

        nameData = File.ReadAllLines(@"Assets/Resources/Texts/ItemName.csv").Select(line => line.Split(',')).ToList();
        for(i = 0;i<34; i++){
            ItemWeight[i] = nameData[i][2];
        }
        CurrentWeight = 0;
        for(i = 0;i<34; i++){
            if(t[i] == "true"){
                CurrentWeight = CurrentWeight + float.Parse(ItemWeight[i]);
            }
        }
        Weight.GetComponent<UnityEngine.UI.Text>().text  = CurrentWeight.ToString();


        sw = new StreamWriter(@"Assets/Resources/Texts/Bichiku_checks.csv", false);
        string[] s1 = t;
        string s2 = string.Join(",", s1);
        await sw.WriteLineAsync(s2);
        sw.Close();
        Debug.Log("saved!"); 
    }
}
