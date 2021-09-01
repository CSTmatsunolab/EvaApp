using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
    // 選択画面に遷移
    public void SelectButtonDown()
    {
        SceneManager.LoadScene("SelectScene");
    }
}