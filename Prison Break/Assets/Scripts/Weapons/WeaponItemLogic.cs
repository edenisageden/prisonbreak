using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WeaponItemLogic : MonoBehaviour, IEquiptable
{
    [Header("Assignables")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [HideInInspector] public int currentAmmo;
    [SerializeField] private int setCurrentAmmo;

    /*[HideInInspector]*/ public Weapon weapon;

    private void Awake()
    {
        currentAmmo = setCurrentAmmo;
    }

    private void Start()
    {
        spriteRenderer.sprite = weapon.sprite;
    }

    public void Equipt(GameObject player)
    {
        print("Equipted");
        WeaponHolder weaponHolder = player.GetComponent<WeaponHolder>();
        weaponHolder.weapon = weapon;
        weaponHolder.currentAmmo = currentAmmo;
        Destroy(gameObject);
    }
}
