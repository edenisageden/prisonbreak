using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Weapon weapon;
    [SerializeField] private Animator animator;

    [HideInInspector] public bool canShoot = true;

    public void Shoot()
    {
        if (!canShoot) return;
        canShoot = false;
        weapon.Attack(transform.position, transform.rotation, transform.up, "Enemy", animator);
        StartCoroutine(ReloadShoot());
    }

    private IEnumerator ReloadShoot()
    {
        yield return new WaitForSeconds(weapon.reloadTime);
        canShoot = true;
    }
}
