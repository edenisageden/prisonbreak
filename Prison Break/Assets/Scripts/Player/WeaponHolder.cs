using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weapon;
    [SerializeField] private Animator animator;
    [SerializeField] private float fistWidth, fistRange, fistReloadTime;
    private RangedWeapon rangedWeapon;
    private MeleeWeapon meleeWeapon;
    [HideInInspector] public bool isRanged;
    private bool isAttacking;
    private bool canShoot = true;
    [HideInInspector] public int currentAmmo;
    public static event Action OnFistAttack = delegate { };
    [HideInInspector] public bool canAttack;

    private void Update()
    {
        if (!canAttack) return;
        if (weapon == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FistAttack(fistWidth, fistRange, "Player", fistReloadTime);
            }
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
        if (currentAmmo <= 0 && isRanged && weapon != null) return;
        if (!canShoot) return;
        canShoot = false;
        weapon.Attack(transform.position, transform.rotation, transform.up, "Player", animator);
        currentAmmo -= 1;
        StartCoroutine(ReloadShoot());
    }

    private IEnumerator ReloadShoot()
    {
        yield return new WaitForSeconds(weapon.reloadTime);
        canShoot = true;
    }

    private IEnumerator ReloadFist(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
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

    public void FistAttack(float width, float range, string ignoreLayer, float reloadTime)
    {
        if (!canShoot) return;
        canShoot = false;

        OnFistAttack.Invoke();
        animator.SetTrigger("onAttack");
        if (animator.GetBool("rightPunch")) animator.SetBool("rightPunch", false);
        else animator.SetBool("rightPunch", true);
        Vector2 size = new Vector2(width, range);
        Collider2D[] collisionList = Physics2D.OverlapBoxAll(transform.position, size, transform.rotation.eulerAngles.z);
        for (int i = 0; i < collisionList.Length; i++)
        {
            if (collisionList[i].gameObject.layer != LayerMask.NameToLayer(ignoreLayer))
            {
                IKillable killable = collisionList[i].gameObject.GetComponent<IKillable>();
                if (killable != null) killable.Kill();
            }
        }

        StartCoroutine(ReloadFist(reloadTime));
    }
}
