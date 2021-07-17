using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    // 選択画面に遷移
    public void ReturnButtonDown()
    {
        SceneManager.LoadScene("SelectScene");
    }
}