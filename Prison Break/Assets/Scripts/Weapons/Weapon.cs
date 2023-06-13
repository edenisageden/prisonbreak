using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public Sprite playerSprite;
    public Sprite enemySprite;
    public float reloadTime;

    public abstract void Attack(Vector3 start, Quaternion rotation, Vector3 direction, string ignoreLayer);
}
