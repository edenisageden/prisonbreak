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
    public AudioClip pickupSound;
    public AudioClip attackSound;

    public abstract void Attack(Vector3 start, Quaternion rotation, Vector3 direction, string ignoreLayer, Animator animator);
}
