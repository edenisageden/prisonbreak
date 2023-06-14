using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteManager : MonoBehaviour
{
    [SerializeField] private EnemyShoot enemyShoot;
    [SerializeField] private Animator animator;

    private void Update()
    {
        if (enemyShoot.weapon == null) animator.SetInteger("id", 0);
        else animator.SetInteger("id", enemyShoot.weapon.id);
    }
}
