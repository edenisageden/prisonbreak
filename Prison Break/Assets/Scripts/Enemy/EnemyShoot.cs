using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Weapon weapon;
    [SerializeField] private Animator animator;
    [SerializeField] private float reloadTimeModifier = 1;
    [SerializeField] private float bulletSpeedModifier = 1;
    [HideInInspector] public bool canShoot = true;

    private void Start()
    {
        if (weapon is RangedWeapon)
        {
            RangedWeapon rangedWeapon = weapon as RangedWeapon;
            rangedWeapon.bulletPrefab.GetComponent<BulletLogic>().ignoreLayer = "Enemy";
        }
    }

    public void Shoot()
    {
        if (!canShoot) return;
        canShoot = false;
        weapon.Attack(transform.position, transform.rotation, weapon.spread, transform.up, "Enemy", animator, bulletSpeedModifier);
        StartCoroutine(ReloadShoot());
    }

    private IEnumerator ReloadShoot()
    {
        yield return new WaitForSeconds(weapon.reloadTime * reloadTimeModifier);
        canShoot = true;
    }
}
