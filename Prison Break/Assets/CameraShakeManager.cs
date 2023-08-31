using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShakeManager : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin cinemachineShake;
    [SerializeField] float amplitude, frequency, duration;

    private void Awake()
    {
        virtualCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
        cinemachineShake = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        RangedWeapon.OnAttack += CallScreenShake;
        MeleeWeapon.OnAttack += CallScreenShake;
        WeaponHolder.OnFistAttack += CallScreenShake;
    }
    private void OnDestroy()
    {
        RangedWeapon.OnAttack -= CallScreenShake;
        MeleeWeapon.OnAttack -= CallScreenShake;
        WeaponHolder.OnFistAttack -= CallScreenShake;
    }

    void CallScreenShake(Weapon weapon)
    {
        StartCoroutine(ShakeCamera());
    }

    void CallScreenShake()
    {
        StartCoroutine(ShakeCamera());
    }

    IEnumerator ShakeCamera()
    {
        cinemachineShake.m_AmplitudeGain = amplitude;
        cinemachineShake.m_FrequencyGain = frequency;

        yield return new WaitForSecondsRealtime(duration);

        cinemachineShake.m_AmplitudeGain = 0f;
        cinemachineShake.m_FrequencyGain = 0f;
    }
}
