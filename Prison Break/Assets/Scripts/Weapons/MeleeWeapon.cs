using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Weapons/Melee Weapon")]
public class MeleeWeapon : Weapon
{
    public BoxCollider2D hitBox;

    public override void Attack(Vector3 start, Quaternion rotation, Vector3 direction, string ignoreLayer)
    {
        
    }
}
