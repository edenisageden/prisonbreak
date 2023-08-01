using System.Collections;
using UnityEngine;

public class OutlineBlinker2 : MonoBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] Color chosenColor;
    [SerializeField] float brightnessRange = 0.5f; // Adjust this to control the brightness range

    private bool isFlickeringForward = true;
    private float timeElapsed = 0f;
    [SerializeField] private float transitionDuration = 1.0f; // Adjust this to control the speed of the flickering effect

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        // Calculate the normalized time value for the current transition
        float t = Mathf.Clamp01(timeElapsed / transitionDuration);

        // Interpolate between the darker and brighter versions of the chosen color
        Color darkerColor = chosenColor - new Color(brightnessRange, brightnessRange, brightnessRange, 0f);
        Color targetColor = chosenColor + new Color(brightnessRange, brightnessRange, brightnessRange, 0f);
        Color currentColor;

        if (isFlickeringForward)
            currentColor = Color.Lerp(darkerColor, targetColor, t);
        else
            currentColor = Color.Lerp(targetColor, darkerColor, t);

        mat.SetColor("_Outline_color", currentColor);

        // If the transition duration has elapsed, reverse the direction of interpolation
        if (timeElapsed >= transitionDuration)
        {
            timeElapsed = 0f;
            isFlickeringForward = !isFlickeringForward;
        }
    }
}
