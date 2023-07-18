using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IKillable
{
    [SerializeField] GameObject deadPrefab;
    [SerializeField] private bool debugImmortal = false;
    [HideInInspector] public bool immortal = false;
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject ammoMenu;

    public void Kill()
    {
        if (debugImmortal) return;
        if (immortal) return;
        Instantiate(deadPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
        deathMenu.SetActive(true);
        ammoMenu.SetActive(false);
    }
}
