using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MinusButton : MonoBehaviour
{
    public void MInusButtonDown()
    {
        GameObject Pdata = GameObject.Find("Eat_Data");
        //食事量x
        int x = int.Parse(Pdata.GetComponent<Eat_Data>().EatData[1][0]);

        if (x >= 1)
        {
            x = x - 1;
            //string型にして格納
            string str = x.ToString();
            Pdata.GetComponent<Eat_Data>().EatData[1][0] = str;
        }

    }
}