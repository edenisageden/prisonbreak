using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Weapons/Melee Weapon")]
public class MeleeWeapon : Weapon
{
    public float range, width;
    public static event Action<Weapon> OnAttack = delegate { };

    public override void Attack(Vector3 start, Quaternion rotation, float spread, Vector3 direction, string ignoreLayer, Animator animator)
    {
        OnAttack(this);
        animator.SetTrigger("onAttack");
        Vector2 size = new Vector2(width, range);
        Collider2D[] collisionList = Physics2D.OverlapBoxAll(start, size, rotation.eulerAngles.z);
        for (int i = 0; i < collisionList.Length; i++)
        {
            if (collisionList[i].gameObject.layer != LayerMask.NameToLayer(ignoreLayer))
            {
                IKillable killable = collisionList[i].gameObject.GetComponent<IKillable>();
                if (killable != null) killable.Kill();
            }
        }
    }
}
