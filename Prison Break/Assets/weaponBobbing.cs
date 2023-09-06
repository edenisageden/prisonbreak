using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBobbing : MonoBehaviour
{
    [SerializeField] private float maxScale, maxUp, scaleDuration, pulseDuration;
    [SerializeField] private bool doScale, doPulse;

    private void Start()
    {
        LeanTween.reset();
        LeanTween.init();
        if (doScale) ScaleUp();
        if (doPulse) PulseUp();
    }

    private void ScaleUp()
    {
        LeanTween.scale(gameObject, new Vector3(maxScale, maxScale, maxScale), scaleDuration).setOnComplete(ScaleDown);
    }
    private void ScaleDown()
    {
        LeanTween.scale(gameObject, Vector3.one, scaleDuration).setOnComplete(ScaleUp);
    }
    private void PulseUp()
    {
        LeanTween.moveY(gameObject, transform.position.y + maxUp, pulseDuration).setOnComplete(PulseDown);
    }
    private void PulseDown()
    {
        LeanTween.moveY(gameObject, transform.position.y - maxUp, pulseDuration).setOnComplete(PulseUp);
    }
}
