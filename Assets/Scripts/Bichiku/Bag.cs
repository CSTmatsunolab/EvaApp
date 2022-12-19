using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    public Toggle toggle;
    public GameObject Size;
    // Start is called before the first frame update
    public void OnToggleChanged(){
        // if(toggle.isOn){
        //     Size.GetComponent<UnityEngine.UI.Text>().text = gameObject.name;
        // }
    }
}
