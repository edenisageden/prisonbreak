using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WeaponItemLogic : MonoBehaviour, IEquiptable
{
    [Header("Assignables")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    /*[HideInInspector]*/ public Weapon weapon;

    private void Start()
    {
        spriteRenderer.sprite = weapon.sprite;
    }

    public void Equipt(GameObject player)
    {
        print("Equipted");
        player.GetComponent<WeaponHolder>().weapon = weapon;
        Destroy(gameObject);
    }
}
