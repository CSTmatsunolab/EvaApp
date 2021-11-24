using UnityEngine;
using System.Collections;
 
public class MusicFadeOut : MonoBehaviour
{
    AudioSource audioSource;
    /*public bool IsFade;
    public double FadeOutSeconds = 1.0;
    bool IsFadeOut = false;
    double FadeDeltaTime = 0;
    int ChangeMusic = MenuPanel.SendChangeMusic();
    */
 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //DontDestroyOnLoad(this);
    }
 
    /*void Update()
    {
        if(ChangeMusic == 1)
        {  
            IsFadeOut = true;
            if (IsFadeOut)
            {
                FadeOutSeconds = 3;
                FadeDeltaTime += Time.deltaTime;
                if (FadeDeltaTime == FadeOutSeconds)
                {
                    FadeDeltaTime = FadeOutSeconds;
                    IsFadeOut = false;
                }
                audioSource.volume = (float)(1.0 - FadeDeltaTime / FadeOutSeconds);
            }
        }
    }*/
}