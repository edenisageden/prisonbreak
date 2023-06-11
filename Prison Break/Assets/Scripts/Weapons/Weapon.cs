using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public float reloadTime;
}
