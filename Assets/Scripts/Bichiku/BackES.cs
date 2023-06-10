using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackES : MonoBehaviour
{
    // GameObject[] bichiku;
    // GameObject[] title;
    // void Awake(){
    //     bichiku = GameObject.FindGameObjectsWithTag("bichiku");
    //     title = GameObject.FindGameObjectsWithTag("title");
    // }
    public void BackESButtonDown()
    {
        SceneManager.LoadScene("EventSelectScene");
        // foreach(GameObject bi in bichiku){
        //     bi.SetActive (false);
        // }
        // foreach(GameObject ti in title){
        //     ti.SetActive (true);
        // }
    }
    // bool ContainsScene(string sceneName)
    // {
    //     for (int i = 0; i < SceneManager.sceneCount; i++)
    //     {
    //         if (SceneManager.GetSceneAt(i).name == sceneName)
    //         {
    //             return true;
    //         }
    //     }
    //     return false;
    // }
}
