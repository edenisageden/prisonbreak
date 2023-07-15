using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponDropManager
{
    public static GameObject DropWeapon(GameObject weaponItemPrefab, Weapon weapon, Vector3 position, Quaternion rotation)
    {
        GameObject newWeapon = GameObject.Instantiate(weaponItemPrefab, position, rotation);
        newWeapon.GetComponent<WeaponItemLogic>().weapon = weapon;
        return newWeapon;
    }
}
