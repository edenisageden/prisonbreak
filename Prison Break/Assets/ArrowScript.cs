using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer.enabled = false;
        NextLevelBox.OnComplete += ShowSprite;
    }
    private void OnDestroy()
    {
        NextLevelBox.OnComplete -= ShowSprite;
    }

    private void ShowSprite()
    {
        spriteRenderer.enabled = true;
    }
}
