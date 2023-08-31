using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour, IKillable
{
    [SerializeField] GameObject deadPrefab;
    [SerializeField] private bool debugImmortal = false;
    [HideInInspector] public bool immortal = false;
    [SerializeField] GameObject ammoMenu;
    public static event Action OnPlayerDeath = delegate { };
    [HideInInspector] public bool isDead = false;

    public void Kill()
    {
        if (debugImmortal) return;
        if (immortal) return;
        OnPlayerDeath?.Invoke();
        isDead = true;
        Instantiate(deadPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
        ammoMenu.SetActive(false);
    }
}
