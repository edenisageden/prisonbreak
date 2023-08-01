using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OutlineBlinker : MonoBehaviour
{
    [SerializeField] Material mat;
    public enum RGBPhase
    {
        p1, p2, p3, p4, p5, p6
    }
    public RGBPhase phase = RGBPhase.p1;

    private float timeElapsed = 0f;
    [SerializeField] private float transitionDuration = 1.0f; // Adjust this to control the speed of the flickering effect

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        // Calculate the normalized time value for the current phase
        float t = Mathf.Clamp01(timeElapsed / transitionDuration);

        // Interpolate the RGB values based on the current phase
        switch (phase)
        {
            case RGBPhase.p1:
                mat.SetColor("_Outline_color", Color.Lerp(Color.red, Color.yellow, t));
                break;
            case RGBPhase.p2:
                mat.SetColor("_Outline_color", Color.Lerp(Color.yellow, Color.green, t));
                break;
            case RGBPhase.p3:
                mat.SetColor("_Outline_color", Color.Lerp(Color.green, Color.cyan, t));
                break;
            case RGBPhase.p4:
                mat.SetColor("_Outline_color", Color.Lerp(Color.cyan, Color.blue, t));
                break;
            case RGBPhase.p5:
                mat.SetColor("_Outline_color", Color.Lerp(Color.blue, Color.magenta, t));
                break;
            case RGBPhase.p6:
                mat.SetColor("_Outline_color", Color.Lerp(Color.magenta, Color.red, t));
                break;
        }

        // If the transition duration has elapsed, move to the next phase
        if (timeElapsed >= transitionDuration)
        {
            timeElapsed = 0f;
            phase = (RGBPhase)(((int)phase + 1) % 6);
        }
    }
}
