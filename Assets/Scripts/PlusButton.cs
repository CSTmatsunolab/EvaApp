using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlusButton : MonoBehaviour
{
    public void PlusButtonDown()
    {
        GameObject Edata = GameObject.Find("Eat_Data");
        //食事量x
        int x = int.Parse(Edata.GetComponent<Eat_Data>().EatData[1][0]);

        if (2 >= x)
        {
            x = x + 1;
            //string型にして格納
            string str = x.ToString();
            Edata.GetComponent<Eat_Data>().EatData[1][0] = str;
        }

    }
}