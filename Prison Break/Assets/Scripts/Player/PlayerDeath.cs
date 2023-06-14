using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IKillable
{
    [SerializeField] GameObject deadPrefab;

    public void Kill()
    {
        Instantiate(deadPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
