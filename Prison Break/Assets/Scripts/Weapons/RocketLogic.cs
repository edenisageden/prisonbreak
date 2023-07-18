using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLogic : BulletLogic
{
    [SerializeField] private int explosionDamage;
    [SerializeField] private CircleCollider2D explosionHitBox;

    public override void ExplodeIfRocket()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(explosionHitBox.transform.position, explosionHitBox.radius, Vector2.zero);
        for (int i = 0; i < hits.Length; i++)
        {
            IKillable killable = hits[i].collider.gameObject.GetComponent<IKillable>();
            IDamagable damagable = hits[i].collider.gameObject.GetComponent<IDamagable>();
            if (damagable != null) damagable.Damage(explosionDamage);
            else if (killable != null) killable.Kill();
        }
    }
}
