using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class UIAudioMiddleMan : MonoBehaviour
{
    public void PlayUI1()
    {
        FindObjectOfType<UIAudio>().PlayUI1();
    }   
    public void PlayUI2()
    {
        FindObjectOfType<UIAudio>().PlayUI2();
    }
}
