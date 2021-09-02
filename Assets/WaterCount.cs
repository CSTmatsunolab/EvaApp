using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class WaterCount : MonoBehaviour
{
    void Start()
    {
         GameObject Pdata = GameObject.Find("Player_Data");
         
         int x = int.Parse(Pdata.GetComponent<Player_Data>().PlayerData[1][2]);
         int y = int.Parse(this.name);

         if(y<=x)
         {
             this.gameObject.SetActive(true);
         }
         else
         {
             this.gameObject.SetActive(false);
         }
    }
}
