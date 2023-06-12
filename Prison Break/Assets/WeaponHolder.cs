using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weapon;
    private RangedWeapon rangedWeapon;
    private MeleeWeapon meleeWeapon;
    private bool isRanged;
    private bool isAttacking;

    private bool canShoot = true;

    private void Update()
    {
        CheckIfRangedOrMelee();
        if (isRanged)
        {
            if (rangedWeapon.isAutomatic) isAttacking = Input.GetMouseButton(0);
            else isAttacking = Input.GetMouseButtonDown(0);
            if (isAttacking)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        if (!canShoot) return;
        canShoot = false;
        weapon.Attack(transform.position, transform.rotation, transform.up, "Player");
        StartCoroutine(ReloadShoot());
    }

    private IEnumerator ReloadShoot()
    {
        yield return new WaitForSeconds(weapon.reloadTime);
        canShoot = true;
    }

    private void CheckIfRangedOrMelee()
    {
        if (weapon is RangedWeapon)
        {
            rangedWeapon = weapon as RangedWeapon;
            isRanged = true;
        }
        else if (weapon is MeleeWeapon)
        {
            meleeWeapon = weapon as MeleeWeapon;
            isRanged = false;
        }
    }
}
