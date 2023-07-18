using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardenLogic : EnemyLogic, IDamagable
{
    [Header("Warden")]
    [SerializeField] private int maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) 
        { 
            Kill();
        }
    }
}
