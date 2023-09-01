using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUtility : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip UI1, UI2;

    public void PlayUI1()
    {
        audioSource.PlayOneShot(UI1);
    }

    public void PlayUI2()
    {
        audioSource.PlayOneShot(UI2);
    }
}
