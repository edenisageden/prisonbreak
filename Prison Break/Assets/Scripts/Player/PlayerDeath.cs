using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IKillable
{
    [SerializeField] GameObject deadPrefab;
    [SerializeField] bool immortal = false;
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject ammoMenu;

    public void Kill()
    {
        if (immortal) return;
        Instantiate(deadPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
        deathMenu.SetActive(true);
        ammoMenu.SetActive(false);
    }
}
