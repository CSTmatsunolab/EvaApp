using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class ESManagement : MonoBehaviour
{
    public static int index;
    // Start is called before the first frame update
    void Awake()
    {
        index=rand();
        Debug.Log(index);

    }

    int rand()
    {
        int a = Random.Range(1,3);
        return a;
    }

    public void EventButtonDown()
    {
        SceneManager.LoadScene("EventScene"); //ボタンが押されたら遷移
    }
}
