using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Weapon", menuName = "Weapons/Ranged Weapon")]
public class RangedWeapon : Weapon
{
    public float bulletSpeed;
    public float spread;
    public GameObject bulletPrefab;
    public bool isAutomatic;
    public static event Action<Weapon> OnAttack = delegate { };

    public override void Attack(Vector3 start, Quaternion rotation, Vector3 direction, string ignoreLayer, Animator animator)
    {
        Vector3 actualStart = start + direction * 1.5f;
        OnAttack(this);
        animator.SetTrigger("onAttack");
        GameObject newBullet = Instantiate(bulletPrefab, actualStart, rotation);
        newBullet.GetComponent<BulletLogic>().ignoreLayer = ignoreLayer;
        newBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
