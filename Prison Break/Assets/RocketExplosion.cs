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
    private List<IKillable> pendingToKillList = new List<IKillable>();
    [SerializeField] private GameObject explosion;
    public static event Action OnExplode = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        {
            triggerColliders.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        {
            triggerColliders.Remove(collision);
        }
    }

    private void Start()
    {
        bulletLogic.OnBulletCollision += DoExplosion;
    }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        bulletLogic.OnBulletCollision -= DoExplosion;
    }

    private void DoExplosion()
    {
        OnExplode?.Invoke();

        foreach (Collider2D collider in triggerColliders)
        {
            if (bulletLogic.ignoreLayer == "Player")
            {
                EnemyLogic enemyLogic = collider.gameObject.GetComponent<EnemyLogic>();
                if (enemyLogic != null)
                {
                    IKillable killable = enemyLogic.GetComponent<IKillable>();

                    if (killable != null)
                    {
                        pendingToKillList.Add(killable);
                    }
                }
            }
            else if (bulletLogic.ignoreLayer == "Enemy")
            {
                PlayerDeath playerDeath = collider.gameObject.GetComponent<PlayerDeath>();
                if (playerDeath != null)
                {
                    IKillable killable = playerDeath.GetComponent<IKillable>();

                    if (killable != null)
                    {
                        pendingToKillList.Add(killable);
                    }
                }
            }
        }
        foreach (IKillable killable in pendingToKillList)
        {
            killable.Kill();
        }
    }
}

