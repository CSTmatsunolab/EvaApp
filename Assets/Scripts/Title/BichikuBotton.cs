using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class BichikuBotton : MonoBehaviour
{
    // GameObject[] bichiku;
    // GameObject[] title;
    // void Start(){
    //     title = GameObject.FindGameObjectsWithTag("title");
    //     bichiku = GameObject.FindGameObjectsWithTag("bichiku");
    //     foreach(GameObject bi in bichiku){
    //         bi.SetActive (false);
    //     }
    // }
    public void BichikueButtonDown()
    {      
        SceneManager.LoadScene("Bichiku");   
        // foreach(GameObject ti in title){
        //     ti.SetActive (false);
        // }
        // foreach(GameObject bi in bichiku){
        //     bi.SetActive (true);
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
