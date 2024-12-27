using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL : MonoBehaviour
{
   public void onClick()
    {
        Application.OpenURL("https://www.matsulab.org/#/");//""の中には開きたいWebページのURLを入力します
    }
}