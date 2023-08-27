using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorLogic : MonoBehaviour
{
    public List<Color> targetColors = new List<Color>();
    public float lerpDuration = 1.0f;

    private SpriteRenderer spriteRenderer;
    private int currentColorIndex = 0;
    private Color startColor;
    private Color endColor;
    private float lerpStartTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (targetColors.Count > 0)
        {
            currentColorIndex = 0;
            UpdateColors();
        }
    }

    void Update()
    {
        if (targetColors.Count > 0)
        {
            float timeSinceLerpStarted = Time.time - lerpStartTime;
            float t = Mathf.Clamp01(timeSinceLerpStarted / lerpDuration);

            Color lerpedColor = Color.Lerp(startColor, endColor, t);
            spriteRenderer.color = lerpedColor;

            if (t >= 1.0f)
            {
                currentColorIndex = (currentColorIndex + 1) % targetColors.Count;
                UpdateColors();
            }
        }
    }

    void UpdateColors()
    {
        startColor = spriteRenderer.color;
        endColor = targetColors[currentColorIndex];
        lerpStartTime = Time.time;
    }
}
