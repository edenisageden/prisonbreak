using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLogic : BulletLogic
{
    [SerializeField] private int explosionDamage;
    [SerializeField] private CircleCollider2D explosionHitBox;
    [SerializeField] private LayerMask targetLayer;

    public override void ExplodeIfRocket()
    {
        print("Rocket has exploded");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionHitBox.transform.position, explosionHitBox.radius, targetLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            print("Enemy hit");
            EnemyLogic enemyLogic = colliders[i].gameObject.GetComponentInParent<EnemyLogic>();
            IKillable killable = enemyLogic.GetComponent<IKillable>();
            if (killable != null)
            {
                print("Collision killable");
                killable.Kill();
            }
        }
    }
}
