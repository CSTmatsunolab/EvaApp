using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BichikuExp : MonoBehaviour
{
    [SerializeField] GameObject Explanation;
    // Start is called before the first frame update
    void Start()
    {
        CloseExplanation();
        GoToExplanation();   
    }

    public void GoToExplanation(){//説明パネル表示
        Explanation.SetActive(true);
    }

    // Update is called once per frame
    public void CloseExplanation(){//説明パネル非表示
        Explanation.SetActive(false);
    }
}
