using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    [SerializeField] private BulletLogic bulletLogic;
    [SerializeField] private int explosionDamage;
    private List<Collider2D> triggerColliders = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            triggerColliders.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            triggerColliders.Remove(collision);
        }
    }

    private void Start()
    {
        BulletLogic.OnBulletCollision += DoExplosion;
    }

    private void OnDestroy()
    {
        BulletLogic.OnBulletCollision -= DoExplosion;
    }

    private void DoExplosion()
    {
        foreach (Collider2D collider in triggerColliders)
        {
            print("Colliders found in triggerColliders");
            EnemyLogic enemyLogic = collider.gameObject.GetComponent<EnemyLogic>();
            if (enemyLogic != null)
            {
                IKillable killable = enemyLogic.GetComponent<IKillable>();

                if (killable != null)
                {
                    killable.Kill();
                }
            }
        }
    }
}

