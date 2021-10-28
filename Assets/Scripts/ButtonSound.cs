using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip HoverSound;
    public AudioClip ClickSound;

    public void PlayHover()
    {
        myFx.PlayOneShot(HoverSound);
    }
    
    public void PlayClick()
    {
        myFx.PlayOneShot(ClickSound);
    }
}
