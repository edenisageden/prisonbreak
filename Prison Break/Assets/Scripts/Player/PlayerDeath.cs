using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IKillable
{
    [SerializeField] GameObject deadPrefab;
    [SerializeField] bool immortal = false;

    public void Kill()
    {
        if (immortal) return;
        Instantiate(deadPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
