using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MissionCompletedAudioManager : MonoBehaviour
{
    [SerializeField] AudioClip completeSound;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private float waitForSeconds;

    private void Start()
    {
        NextLevelBox.OnComplete += PlayComplete;
    }

    private void OnDestroy()
    {
        NextLevelBox.OnComplete -= PlayComplete;
    }

    private void PlayComplete()
    {
        StartCoroutine(PlayCompleteEnum());
    }

    private IEnumerator PlayCompleteEnum()
    {
        audioSource.PlayOneShot(completeSound);
        yield return new WaitForSeconds(waitForSeconds);
        audioSource.Stop();
    }
}
