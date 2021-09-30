using UnityEngine;
using UnityEngine.UI;
 
public class CharUIText : MonoBehaviour {
 
    public Text nameText = null;
    public float risePoint = 1.0f;
    Camera cam;
    void Start () {
        GameObject obj = GameObject.Find ("Main Camera");
        cam = obj.GetComponent<Camera> ();
    }
    void Update () {
        nameText.transform.position = cam.WorldToScreenPoint (new Vector3(transform.position.x, transform.position.y + risePoint, transform.position.z));
    }
}