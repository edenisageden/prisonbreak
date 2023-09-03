using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioMiddleMan : MonoBehaviour
{
    private UIAudio uIAudio;

    private void Awake()
    {
        uIAudio = FindObjectOfType<UIAudio>();
    }
    public void PlayUI1()
    {
        uIAudio.PlayUI1();
    }   
    public void PlayUI2()
    {
        uIAudio.PlayUI2();
    }
}
