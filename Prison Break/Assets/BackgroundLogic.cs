using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLogic : MonoBehaviour
{
    public List<Color> targetColors; // List of colors to fade between
    public float fadeDuration = 2.0f; // Duration of each fade

    private Camera mainCamera;
    private int currentColorIndex = 0;
    private Color initialColor;
    private Color targetColor;
    private float fadeStartTime;

    void Start()
    {
        mainCamera = Camera.main;
        initialColor = mainCamera.backgroundColor;
        if (targetColors.Count > 0)
            targetColor = targetColors[0];
    }

    void Update()
    {
        // Calculate the progress of the fade
        float progress = (Time.time - fadeStartTime) / fadeDuration;
        mainCamera.backgroundColor = Color.Lerp(initialColor, targetColor, progress);

        // If the fade is complete, move to the next color
        if (progress >= 1.0f)
        {
            currentColorIndex = (currentColorIndex + 1) % targetColors.Count;
            initialColor = mainCamera.backgroundColor;
            targetColor = targetColors[currentColorIndex];
            fadeStartTime = Time.time;
        }
    }
}
