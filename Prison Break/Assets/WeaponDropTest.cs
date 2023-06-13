using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDropTest : MonoBehaviour
{
    [SerializeField] GameObject weaponItem;
    [SerializeField] Weapon weapon;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            WeaponDropManager.DropWeapon(weaponItem, weapon, transform.position, transform.rotation);
        }
    }
}
