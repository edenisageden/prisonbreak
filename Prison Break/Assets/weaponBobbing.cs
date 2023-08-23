using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBobbing : MonoBehaviour
{
    [SerializeField] private float maxScale, ogScale, duration;

    private void FixedUpdate()
    {
        PulsingUpdate2(1f);
    }

    private void PulsingUpdate(float value)
    {
        LeanTween.reset();
        LeanTween.init();
        LeanTween.scale(gameObject, new Vector3(ogScale, ogScale, ogScale), duration)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong()
            .setOnUpdate(PulsingUpdate2);
    }

    private void PulsingUpdate2(float value)
    {
        LeanTween.reset();
        LeanTween.init();
        LeanTween.scale(gameObject, new Vector3(maxScale, maxScale, maxScale), duration)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong()
            .setOnUpdate(PulsingUpdate);
    }
}
