using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Weapon", menuName = "Weapons/Ranged Weapon")]
public class RangedWeapon : Weapon
{
    public float bulletSpeed;
    public int maxAmmo;
    public GameObject bulletPrefab;
    public bool isAutomatic;
    public int bulletCount;
    public static event Action<Weapon> OnAttack = delegate { };
    private Quaternion rotationAfterSpread;

    public override void Attack(Vector3 start, Quaternion rotation, float spread, Vector3 direction, string ignoreLayer, Animator animator, float bulletSpeedModifier = 1)
    {
        OnAttack(this);
        animator.SetTrigger("onAttack");
        
        for (int i = 0; i < bulletCount; i++)
        {
            CalculateSpread(rotation, direction);
            Vector3 actualStart = start + direction * 1.5f;
            GameObject newBullet = Instantiate(bulletPrefab, actualStart, rotationAfterSpread);
            newBullet.GetComponent<BulletLogic>().ignoreLayer = ignoreLayer;
            newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.transform.up * bulletSpeed * bulletSpeedModifier;
        }
    }

    private void CalculateSpread(Quaternion rotation, Vector3 direction)
    {
        float randomSpread = UnityEngine.Random.Range(-spread, spread);
        rotationAfterSpread = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z + randomSpread);
    }
}
