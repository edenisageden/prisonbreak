using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public float reloadTime;
    public int id;

    public abstract void Attack(Vector3 start, Quaternion rotation, Vector3 direction, string ignoreLayer, Animator animator);
}
