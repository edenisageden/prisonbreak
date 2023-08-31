using Pathfinding;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

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
    [SerializeField] private float rotationTime;
    private Vector2 currentVelocity;

    [Header("Assignables")]
    [SerializeField] private AIDestinationSetter aiDestinationSetter;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private AIPath aiPath;
    [SerializeField] private BossMeleeCollision bossMeleeCollision;
    private float phase1CurrentHealth, phase2CurrentHealth;
    [SerializeField] private TooCloseColliderLogic tooCloseColliderLogic;
    [SerializeField] private BossDashLogic bossDashLogic;
    [SerializeField] private Animator animator;

    private float maxHealth => phase1MaxHealth + phase2MaxHealth;
    [HideInInspector] public Vector2 angle;
    private float currentHealth => phase1CurrentHealth + phase2CurrentHealth;
    private bool isPhase2 => phase1CurrentHealth <= 0f;
    private Attacks currentAttack;
    private bool isAttacking;
    private bool justDashed;
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
        CalculateAngle();

        if (justDashed && !bossDashLogic.isDashDuration)
        {
            FacePlayer();
            justDashed = false;
            print("Knife throw");
            StartCoroutine(AttackCooldown());
            isAttacking = false;
        }

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
            if (x == 0) return Attacks.Punch;
            else if (x == 1) return Attacks.KnifeThrow2;
            else return Attacks.DynamiteThrow;
        }
        else
        {
            int x = UnityEngine.Random.Range(0, 2);
            if (x == 0) return Attacks.Punch;
            else return Attacks.KnifeThrow;
        }
    }
    private void CalculateAngle()
    {
        angle = GetPlayerAngle() * -1;
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
            animator.Play("slash_2");
            
            aiDestinationSetter.target = null;
            aiPath.canMove = false;
            StartCoroutine(AttackCooldown());
            isAttacking = false;
        }
    }
    private void KnifeThrow()
    {
        if (tooCloseColliderLogic.isTooClose)
        {
            bossDashLogic.Dash();
            justDashed = true;
        }
        else
        {
            print("Knife throw");
            StartCoroutine(AttackCooldown());
            isAttacking = false;
        }
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

    private Vector2 GetPlayerAngle()
    {
        float y = playerTransform.position.y - transform.position.y;
        float x = playerTransform.position.x - transform.position.x;
        Vector2 angle = new Vector2(x, y).normalized;  
        return angle;
    }
  
    private void FacePlayer()
    {
        print("G");
        float rotateAngle = (Mathf.Atan2(GetPlayerAngle().y, GetPlayerAngle().x) * Mathf.Rad2Deg) - 90f;
        RotateTo(rotateAngle, rotationTime);
    }

    private void RotateAmount(float rotationAmount, float rotationTime)
    {
        LeanTween.init();
        if (LeanTween.isTweening(gameObject)) return;
        LeanTween.reset();
        LeanTween.cancel(gameObject);
        LeanTween.rotateAround(gameObject, Vector3.forward, rotationAmount, rotationTime);
    }

    private void RotateTo(float rotateTo, float rotationTime)
    {
        LeanTween.init();
        if (LeanTween.isTweening(gameObject)) return;
        LeanTween.reset();
        LeanTween.cancel(gameObject);
        LeanTween.rotate(gameObject, new Vector3(0, 0, rotateTo), rotationTime);
    }
}
