using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteManager : MonoBehaviour
{
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private Animator animator;

    private void Update()
    {
        if (weaponHolder.weapon == null) animator.SetInteger("id", 0);
        else animator.SetInteger("id", weaponHolder.weapon.id);
    }
}
