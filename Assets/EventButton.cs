using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventButton : MonoBehaviour
{
    // イベントシーンに遷移
    public void EventButtonDown()
    {
        Debug.Log("Test");
        SceneManager.LoadScene("EventScene"); //ボタンが押されたら遷移
    }
}