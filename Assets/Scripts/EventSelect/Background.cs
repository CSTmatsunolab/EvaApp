using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Background : MonoBehaviour
{
    void Start()
    {
        Image image;
        image=this.GetComponent<Image>();
        int i=ESManagement.index;
        string str=i.ToString();
        image.sprite=Resources.Load<Sprite>(str);
        var c = image.color;
        image.color = new Color(c.r, c.g, c.b, 100.0f/255.0f);
    }
}
