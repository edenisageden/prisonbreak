using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossLogic : MonoBehaviour
{
    [Header("New Config")]
    [SerializeField] private float phase1MaxHealth, phase2MaxHealth;
    [SerializeField] private float p1Attack1Chance, p1Attack2Chance, p1Attack3Chance, p2Attack1Chance, p2Attack2Chance;
    [SerializeField] private CircleCollider2D playerTooCloseRadius;
    [SerializeField] private float knifeSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private int dynamiteCount;
    [SerializeField] private float turnSpeed;

    [Header("Assignables")]
    [SerializeField] private AIDestinationSetter aiDestinationSetter;
    [SerializeField] private AIPath aiPath;
    private Transform playerTransform;
    private float phase1CurrentHealth, phase2CurrentHealth; 
    private float maxHealth => phase1MaxHealth + phase2MaxHealth;
    private float currentHealth => phase1CurrentHealth + phase2CurrentHealth;
    private bool isPhase2 => phase1CurrentHealth <= 0f;
    private enum BossState
    {
        Attacking, Waiting, Dead
    }
    private enum Attacks
    {
        Punch, KnifeThrow, KnifeThrow2, DynamiteThrow
    }

    private void Awake()
    {
        phase1CurrentHealth = phase1MaxHealth;
        phase2CurrentHealth = phase2MaxHealth;
        LeanTween.init();
        LeanTween.reset();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        aiPath.maxSpeed = chaseSpeed;
    }

    private void ChooseAttack()
    {
        /*if (isPhase2)
        {
            int x = Random.Range(1, p2Attack1Chance + p2Attack2Chance);
            Attacks attack = 
        }
        else
        {
            
        }*/
    }
}
