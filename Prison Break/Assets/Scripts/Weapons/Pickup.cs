using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private GameObject weaponPrefab;
    public static event Action<Weapon> OnPickup = delegate { };

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, itemLayer);
            IEquiptable equiptable = collider?.gameObject.GetComponent<IEquiptable>();
            if (equiptable != null)
            {
                if (weaponHolder.weapon != null)
                {
                    GameObject newWeapon = WeaponDropManager.DropWeapon(weaponPrefab, weaponHolder.weapon, transform.position, transform.rotation);
                    newWeapon.GetComponent<WeaponItemLogic>().currentAmmo = weaponHolder.currentAmmo;
                    weaponHolder.weapon = null;
                    equiptable.Equipt(gameObject);
                    OnPickup?.Invoke(collider.gameObject.GetComponent<WeaponItemLogic>().weapon);
                }
                else
                {
                    equiptable.Equipt(gameObject);
                    OnPickup?.Invoke(collider.gameObject.GetComponent<WeaponItemLogic>().weapon);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && weaponHolder.weapon != null)
        {
            GameObject newWeapon = WeaponDropManager.DropWeapon(weaponPrefab, weaponHolder.weapon, transform.position, transform.rotation);
            newWeapon.GetComponent<WeaponItemLogic>().currentAmmo = weaponHolder.currentAmmo;
            weaponHolder.weapon = null;
        }
    }
}