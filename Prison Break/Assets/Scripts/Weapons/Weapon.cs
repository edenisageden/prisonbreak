using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Weapon : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public float reloadTime;
    public int id;
    public float spread;
    public AudioClip pickupSound;
    public AudioClip attackSound;
    public bool isLegendary;
    public Sprite bulletSprite;

    public abstract void Attack(Vector3 start, Quaternion rotation, float spread, Vector3 direction, string ignoreLayer, Animator animator, float bulletSpeedMultiplier = 1);
}
