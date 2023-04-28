using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;

public class check : MonoBehaviour
{
    TextAsset csvFile;
    public Toggle toggle;
    public GameObject ChecksSave;
    int c = 0;
    //static TextAsset csvFile;
    //static string[] csvFile;
    static List<string[]> checksData = new List<string[]>();
    private StreamWriter sw;
    string[] t = new string[34];
    private GameObject Bdata;
    // Start is called before the first frame update
    void Update(){
        if(c == 0){
            checkC();
        } 
    }
    public void OnToggleChanged(){
        ChecksSave.GetComponent<Checks_save>().save();
    }
    void checkC(){
        // csvFile = Resources.Load("Texts/Bichiku_checks") as TextAsset;
        // csvFile = Resources.Load("Bichiku_checks") as TextAsset;
        // StringReader reader = new StringReader(csvFile.text);
        // while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        // {
        //     string line = reader.ReadLine(); // 一行ずつ読み込み
        //     checksData.Add(line.Split(',')); // , 区切りでリストに追加
        // }
        // string path = Application.persistentDataPath + "/Bichiku_checks.csv";
        // using (var fs = new StreamReader(path, System.Text.Encoding.GetEncoding("UTF-8")))
        // {
        //     while (fs.Peek() != -1)
        //     {
        //         string line = fs.ReadLine(); // 一行ずつ読み込み
        //         checksData.Add(line.Split(',')); // , 区切りでリストに追加
        //     }
        // }
        GameObject[] ItemBox = new GameObject[34];
        GameObject[] checks = new GameObject[34];
        for(int a = 0; a < 34; a++){
            ItemBox[a] = GameObject.Find(a.ToString());
        }
        for(int a = 0; a < 34; a++){
            checks[a] = ItemBox[a].GetComponent<Transform>().transform.Find("checkbox").gameObject;
        } 
        Bdata = GameObject.Find("BagData");

        for(int i=0;i<34;i++){
                if(Bdata.GetComponent<Bag_Data>().BagData[0][i] == "true") {
                    Debug.Log("true"); 
                    checks[i].SetIsOnWithoutCallback( true );
                }else {
                    Debug.Log("false"); 
                    checks[i].SetIsOnWithoutCallback( false );
                }
        }
    //     if(transform.parent.name == ParentG[0].name){
    //         if(checksData[0][0] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[1].name){
    //         if(checksData[0][1] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[2].name){
    //         if(checksData[0][2] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[3].name){
    //         if(checksData[0][3] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[4].name){
    //         if(checksData[0][4] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[5].name){
    //         if(checksData[0][5] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[6].name){
    //         if(checksData[0][6] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[7].name){
    //         if(checksData[0][7] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[8].name){
    //         if(checksData[0][8] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[9].name){
    //         if(checksData[0][9] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[10].name){
    //         if(checksData[0][10] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[11].name){
    //         if(checksData[0][11] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[12].name){
    //         if(checksData[0][12] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[13].name){
    //         if(checksData[0][13] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[14].name){
    //         if(checksData[0][14] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[15].name){
    //         if(checksData[0][15] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[16].name){
    //         if(checksData[0][16] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[17].name){
    //         if(checksData[0][17] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[18].name){
    //         if(checksData[0][18] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[19].name){
    //         if(checksData[0][19] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[20].name){
    //         if(checksData[0][20] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[21].name){
    //         if(checksData[0][21] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[22].name){
    //         if(checksData[0][22] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[23].name){
    //         if(checksData[0][23] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[24].name){
    //         if(checksData[0][24] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[25].name){
    //         if(checksData[0][25] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[26].name){
    //         if(checksData[0][26] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[27].name){
    //         if(checksData[0][27] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[28].name){
    //         if(checksData[0][28] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[29].name){
    //         if(checksData[0][29] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[30].name){
    //         if(checksData[0][30] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[31].name){
    //         if(checksData[0][31] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[32].name){
    //         if(checksData[0][32] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
    //     if(transform.parent.name == ParentG[33].name){
    //         if(checksData[0][33] == "true") {
    //             toggle.SetIsOnWithoutCallback( true );
    //         }else {
    //             toggle.SetIsOnWithoutCallback( false );
    //         }
    //     }
        c = 1;
        if (transform.parent.name == ItemBox[33].name){
            ChecksSave.GetComponent<Checks_save>().save();
        }
    }
}
public static class ToggleExt
{
    public static void SetIsOnWithoutCallback( this GameObject self, bool isOn )
    {
        var onValueChanged = self.GetComponent<Toggle>().onValueChanged;
        self.GetComponent<Toggle>().onValueChanged = new Toggle.ToggleEvent();
        self.GetComponent<Toggle>().isOn = isOn;
        self.GetComponent<Toggle>().onValueChanged = onValueChanged;
    }
}
