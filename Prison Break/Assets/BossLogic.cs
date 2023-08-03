using Pathfinding;
using System.Collections;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    private bool isCoolingDown = false;

    [Header("New Config")]
    [SerializeField] private float phase1MaxHealth, phase2MaxHealth;
    [SerializeField] private CircleCollider2D playerTooCloseRadius;
    [SerializeField] private Collider2D punchRange;
    [SerializeField] private float knifeSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private int dynamiteCount;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float minCooldownTime, maxCooldownTime;

    [Header("Assignables")]
    [SerializeField] private AIDestinationSetter aiDestinationSetter;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private AIPath aiPath;
    [SerializeField] private BossMeleeCollision bossMeleeCollision;
    private float phase1CurrentHealth, phase2CurrentHealth; 
    private float maxHealth => phase1MaxHealth + phase2MaxHealth;
    private float currentHealth => phase1CurrentHealth + phase2CurrentHealth;
    private bool isPhase2 => phase1CurrentHealth <= 0f;
    private Attacks currentAttack;
    private bool isAttacking;
    private enum BossState
    {
        Attacking, Waiting, Dead
    }
    private enum Attacks
    {
        Punch, KnifeThrow, KnifeThrow2, DynamiteThrow
    }

    private void Awake()
    {
        phase1CurrentHealth = phase1MaxHealth;
        phase2CurrentHealth = phase2MaxHealth;
        LeanTween.init();
        LeanTween.reset();
        aiPath.maxSpeed = chaseSpeed;
    }

    private void Update()
    {
        if (isAttacking)
        {
            switch (currentAttack)
            {
                case Attacks.Punch:
                    Punch();
                    break;
                case Attacks.KnifeThrow:
                    KnifeThrow();
                    break;
                case Attacks.KnifeThrow2:
                    KnifeThrow2();
                    break;
                case Attacks.DynamiteThrow:
                    DynamiteThrow();
                    break;
            }
        }
        else if (!isCoolingDown) DoAttack();
    }

    private Attacks ChooseAttack()
    {
        if (isPhase2)
        {
            int x = UnityEngine.Random.Range(0, 3);
            print(x);
            if (x == 0) return Attacks.Punch;
            else if (x == 1) return Attacks.KnifeThrow2;
            else return Attacks.DynamiteThrow;
        }
        else
        {
            int x = UnityEngine.Random.Range(0, 2);
            print(x);
            if (x == 0) return Attacks.Punch;
            else return Attacks.KnifeThrow;
        }
    }

    private void DoAttack()
    {
        isAttacking = true;
        currentAttack = ChooseAttack();

    }
    private void Punch()
    {
        aiPath.canMove = true;
        aiDestinationSetter.target = playerTransform;
        if (bossMeleeCollision.isTouchingPlayer)
        {
            print("Punch");
            aiDestinationSetter.target = null;
            aiPath.canMove = false;
            StartCoroutine(AttackCooldown());
            isAttacking = false;
        }
    }
    private void KnifeThrow()
    {
        print("Knife throw");
        StartCoroutine(AttackCooldown());
        isAttacking = false;
    }
    private void KnifeThrow2()
    {
        print("Knife throw 2");
    }
    private void DynamiteThrow() 
    {
        print("Dynamite throw");
    }

    private IEnumerator AttackCooldown()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(Random.Range(minCooldownTime, maxCooldownTime));
        isCoolingDown = false;
    }
}
