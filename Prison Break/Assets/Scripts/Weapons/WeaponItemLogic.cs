using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItemLogic : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [HideInInspector] public Weapon weapon;

    private void Start()
    {
        spriteRenderer.sprite = weapon.sprite;
    }
}
