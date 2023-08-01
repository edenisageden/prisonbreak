using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkerLogic : MonoBehaviour
{
    [SerializeField] private GameObject outline;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Material normalMat, legendaryMat;

    private void Awake()
    {
        outline.SetActive(false);
    }

    private void Start()
    {
        if (GetComponentInParent<WeaponItemLogic>().weapon.isLegendary)
        {
            spriteRenderer.material = legendaryMat;
        }
        else
        {
            spriteRenderer.material = normalMat;
        }
    }

    public void ShowOutline()
    {
        outline.SetActive(true);
        CancelInvoke("HideOutline");
    }
    public void HideOutline()
    {
        outline.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") ShowOutline();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") HideOutline();
    }
}
