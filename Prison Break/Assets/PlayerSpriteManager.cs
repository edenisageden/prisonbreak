using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteManager : MonoBehaviour
{
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite fistSprite;

    private void Update()
    {
        if (weaponHolder.weapon != null) spriteRenderer.sprite = weaponHolder.weapon.playerSprite;
        else spriteRenderer.sprite = fistSprite;
    }
}
