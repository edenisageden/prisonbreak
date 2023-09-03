using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fistAttackSound;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] AudioClip rollSound;
    [SerializeField] AudioClip explodeSound;
    [SerializeField] AudioClip doorSound;
    [SerializeField] AudioClip completeSound;
    [SerializeField] AudioClip emptySound;

    private void Start()
    {
        Pickup.OnPickup += PlayPickup;
        MeleeWeapon.OnAttack += PlayAttack;
        RangedWeapon.OnAttack += PlayAttack;
        WeaponHolder.OnFistAttack += PlayFistAttack;
        EnemyLogic.OnEnemyDeath += PlayEnemyDeath;
        PlayerDash.OnPlayerDash += PlayRoll;
        RocketExplosion.OnExplode += PlayExplode;
        DoorLogic.OnDoorOpen += PlayDoor;
        NextLevelBox.OnComplete += PlayComplete;
        WeaponHolder.OnEmptyShoot += PlayEmpty;

    }
    private void OnDestroy()
    {
        Pickup.OnPickup -= PlayPickup;
        MeleeWeapon.OnAttack -= PlayAttack;
        RangedWeapon.OnAttack -= PlayAttack;
        WeaponHolder.OnFistAttack -= PlayFistAttack;
        EnemyLogic.OnEnemyDeath -= PlayEnemyDeath;
        PlayerDash.OnPlayerDash -= PlayRoll;
        RocketExplosion.OnExplode -= PlayExplode;
        DoorLogic.OnDoorOpen -= PlayDoor;
        NextLevelBox.OnComplete -= PlayComplete;
        WeaponHolder.OnEmptyShoot -= PlayEmpty;
    }
    private void PlayEmpty()
    {
        audioSource.PlayOneShot(emptySound);
    }
    private void PlayComplete()
    {
        audioSource.PlayOneShot(completeSound);
    }
    private void PlayDoor()
    {
        audioSource.PlayOneShot(doorSound);
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
    private void PlayRoll()
    {
        audioSource.PlayOneShot(rollSound);
    }
    private void PlayExplode()
    {
        audioSource.PlayOneShot(explodeSound);
    }
}
