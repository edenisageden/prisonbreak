using System.Collections.Generic;
using UnityEngine;

public class ImageBackgroundColorLogic : MonoBehaviour
{
    public List<Color> targetColors = new List<Color>();
    public float lerpDuration = 1.0f;

    [SerializeField] private UnityEngine.UI.Image image;
    private int currentColorIndex = 0;
    private Color startColor;
    private Color endColor;
    private float lerpStartTime;

    void Start()
    {
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
            float timeSinceLerpStarted = Time.unscaledTime - lerpStartTime;
            float t = Mathf.Clamp01(timeSinceLerpStarted / lerpDuration);

            Color lerpedColor = Color.Lerp(startColor, endColor, t);
            image.color = lerpedColor;

            if (t >= 1.0f)
            {
                currentColorIndex = (currentColorIndex + 1) % targetColors.Count;
                UpdateColors();
            }
        }
    }

    void UpdateColors()
    {
        startColor = image.color;
        endColor = targetColors[currentColorIndex];
        lerpStartTime = Time.unscaledTime;
    }
}
