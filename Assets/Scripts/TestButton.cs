using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestButton : MonoBehaviour
{
    // 選択画面に遷移
    public void TestButtonDown()
    {
        SceneManager.LoadScene("EatScene");
    }
}