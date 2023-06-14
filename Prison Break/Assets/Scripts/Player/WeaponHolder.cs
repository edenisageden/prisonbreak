using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weapon;
    [SerializeField] private Animator animator;
    private RangedWeapon rangedWeapon;
    private MeleeWeapon meleeWeapon;
    private bool isRanged;
    private bool isAttacking;
    private bool canShoot = true;

    private void Update()
    {
        if (weapon == null)
        {
            // Fist
        }
        else
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
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                }
            }
        }
    }

    private void Shoot()
    {
        if (!canShoot) return;
        canShoot = false;
        weapon.Attack(transform.position, transform.rotation, transform.up, "Player", animator);
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
