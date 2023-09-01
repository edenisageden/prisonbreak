using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponSpawnManager : MonoBehaviour
{
    // 1. Check if there are any weapons on the floor or all the weapons on the floor are empty
    private bool isAllEmpty()
    {
        if (FindObjectsOfType<WeaponItemLogic>() != null)
        {
            for (int i = 0; i < FindObjectsOfType<WeaponItemLogic>().Length; i++)
            {
                if (FindObjectsOfType<WeaponItemLogic>()[i].currentAmmo > 0) return false;
            }
            return true;
        }
        else return true;
    }

    // 2. If all empty, spawn a random weapon in a random location

    // a. Get Random weapon
    [SerializeField] private Weapon[] weaponList;
    private Weapon GetRandomWeapon()
    {
        return weaponList[Random.Range(0, weaponList.Length)];
    }

    // b. Get Random location
    [SerializeField] private float xMin, xMax, yMin, yMax;
    private Vector2 GetRandomLocation()
    {
        return new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
    }

    // c. Instantiate weapon
    [SerializeField] private GameObject weaponItemPrefab;
    [SerializeField] private int ammoMin, ammoMax;
    private GameObject SpawnWeapon()
    {
        GameObject newWeapon = Instantiate(weaponItemPrefab, GetRandomLocation(), Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f)));
        newWeapon.GetComponent<WeaponItemLogic>().weapon = GetRandomWeapon();
        newWeapon.GetComponent<WeaponItemLogic>().currentAmmo = Random.Range(ammoMin, ammoMax);
        return newWeapon;
    }

    // Delete all empty weapons
    private void DeleteEmpty()
    {
        for (int i = 0; i < FindObjectsOfType<WeaponItemLogic>().Length; i++)
        {
            if (FindObjectsOfType<WeaponItemLogic>()[i].currentAmmo == 0)
            {
                Destroy(FindObjectsOfType<WeaponItemLogic>()[i].gameObject);
            }
        }
    }

    private void Update()
    {
        if (isAllEmpty())
        {
            SpawnWeapon();
        }
        DeleteEmpty();
    }
}
