using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoSpriteLogic : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private Sprite nothingSprite;

    private void Update()
    {
        if (weaponHolder.weapon != null)
        {
            image.sprite = weaponHolder.weapon.bulletSprite;
        }
        else image.sprite = nothingSprite;
    }
}
