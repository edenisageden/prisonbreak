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
                    WeaponDropManager.DropWeapon(weaponPrefab, weaponHolder.weapon, transform.position, transform.rotation);
                    weaponHolder.weapon = null;
                    equiptable.Equipt(gameObject);
                }
                else
                {
                    equiptable.Equipt(gameObject);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && weaponHolder.weapon != null)
        {
            WeaponDropManager.DropWeapon(weaponPrefab, weaponHolder.weapon, transform.position, transform.rotation);
            weaponHolder.weapon = null;
        }
    }
}