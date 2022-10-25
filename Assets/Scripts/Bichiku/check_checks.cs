using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class check_checks : MonoBehaviour
{
    public Toggle toggle;
    public GameObject ChecksSave;
    static TextAsset csvFile;
    static List<string[]> checksData = new List<string[]>();
    private StreamWriter sw;
    string[] t = new string[17];
    // Start is called before the first frame update
    void Awake(){
        csvFile = Resources.Load("Texts/Bichiku_checks") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);//
        while (reader.Peek() != -1)//最後まで読み込むと-1になる関数
        {
            string line = reader.ReadLine();//一行ずつ読み込み
            checksData.Add(line.Split(','));
        }
        if(transform.parent.name == "Itembox0"){
            if(checksData[0][0] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox1"){
            if(checksData[0][1] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox2"){
            if(checksData[0][2] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox3"){
            if(checksData[0][3] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox4"){
            if(checksData[0][4] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox5"){
            if(checksData[0][5] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox6"){
            if(checksData[0][6] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox7"){
            if(checksData[0][7] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox8"){
            if(checksData[0][8] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox9"){
            if(checksData[0][9] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox10"){
            if(checksData[0][10] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox11"){
            if(checksData[0][11] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox12"){
            if(checksData[0][12] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox13"){
            if(checksData[0][13] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox14"){
            if(checksData[0][14] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox15"){
            if(checksData[0][15] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
        if(transform.parent.name == "Itembox16"){
            if(checksData[0][16] == "true") {
                toggle.SetIsOnWithoutCallback( true );
            }else {
                toggle.SetIsOnWithoutCallback( false );
            }
        }
    }
    public void OnToggleChanged(){
        ChecksSave.GetComponent<Checks_save>().save();
    }
}
public static class ToggleExt
{
    public static void SetIsOnWithoutCallback( this Toggle self, bool isOn )
    {
        var onValueChanged = self.onValueChanged;
        self.onValueChanged = new Toggle.ToggleEvent();
        self.isOn = isOn;
        self.onValueChanged = onValueChanged;
    }
}
