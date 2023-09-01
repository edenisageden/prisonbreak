using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSoundEffectManager : MonoBehaviour
{
    [SerializeField] private AudioClip Dash, Throw, Slash, DynamiteThrow, DynamiteExplode;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        BossDashLogic.OnDash += PlayDashSound;
        DynamiteScript.OnDynamiteExplode += PlayDynamiteExplodeSound;
        BossLogic.OnThrow += PlayThrowSound;
        BossLogic.OnSlash += PlaySlashSound;
        BossLogic.OnDynamiteThrow += PlayDynamiteThrowSound;
    }

    private void OnDestroy()
    {
        BossDashLogic.OnDash -= PlayDashSound;
        DynamiteScript.OnDynamiteExplode -= PlayDynamiteExplodeSound;
        BossLogic.OnThrow -= PlayThrowSound;
        BossLogic.OnSlash -= PlaySlashSound;
        BossLogic.OnDynamiteThrow -= PlayDynamiteThrowSound;
    }

    private void PlayDashSound()
    {
        audioSource.PlayOneShot(Dash);
    }

    private void PlayDynamiteExplodeSound()
    {
        audioSource.PlayOneShot(DynamiteExplode);
    }

    private void PlayThrowSound()
    {
        audioSource.PlayOneShot(Throw);
    }

    private void PlaySlashSound()
    {
        audioSource.PlayOneShot(Slash);
    }

    private void PlayDynamiteThrowSound()
    {
        audioSource.PlayOneShot(DynamiteThrow);
    }
}
