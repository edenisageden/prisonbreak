using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fistAttackSound;
    [SerializeField] AudioClip enemyDeathSound;

    private void Start()
    {
        Pickup.OnPickup += PlayPickup;
        MeleeWeapon.OnAttack += PlayAttack;
        RangedWeapon.OnAttack += PlayAttack;
        WeaponHolder.OnFistAttack += PlayFistAttack;
        EnemyLogic.OnEnemyDeath += PlayEnemyDeath;
    }
    private void OnDestroy()
    {
        Pickup.OnPickup -= PlayPickup;
        MeleeWeapon.OnAttack -= PlayAttack;
        RangedWeapon.OnAttack -= PlayAttack;
        WeaponHolder.OnFistAttack -= PlayFistAttack;
        EnemyLogic.OnEnemyDeath -= PlayEnemyDeath;
    }
    private void PlayPickup(Weapon weapon)
    {
        audioSource.PlayOneShot(weapon.pickupSound);
    }
    private void PlayAttack(Weapon weapon)
    {
        audioSource.PlayOneShot(weapon.attackSound);
    }
    private void PlayFistAttack()
    {
        audioSource.PlayOneShot(fistAttackSound);
    }
    private void PlayEnemyDeath()
    {
        audioSource.PlayOneShot(enemyDeathSound);
    }
}
