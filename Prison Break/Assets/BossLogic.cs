using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossLogic : MonoBehaviour, IDamagable
{
    private bool isCoolingDown = false;

    [Header("New Config")]
    [SerializeField] private float maxHealth, phase2Health;
    [SerializeField] private CircleCollider2D playerTooCloseRadius;
    [SerializeField] private Collider2D punchRange;
    [SerializeField] private float knifeSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private int dynamiteCount;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float minCooldownTime, maxCooldownTime;
    [SerializeField] private float rotationTime;
    [SerializeField] private float indicatorTime;
    private Vector2 currentVelocity;

    [Header("Assignables")]
    [SerializeField] private AIDestinationSetter aiDestinationSetter;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private AIPath aiPath;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private BossMeleeCollision bossMeleeCollision;
    [SerializeField] private TooCloseColliderLogic tooCloseColliderLogic;
    [SerializeField] private BossDashLogic bossDashLogic;
    [SerializeField] private GameObject indicator1, indicator2, indicator3;
    [SerializeField] private GameObject knifeProjectile;
    [SerializeField] private Animator animator;

    [HideInInspector] public Vector2 angle;
    private bool isDoingKnifeThrow;
    public float currentHealth;
    private bool isPhase2 => currentHealth <= phase2Health;
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
        currentHealth = maxHealth;
        LeanTween.init();
        LeanTween.reset();
        aiPath.maxSpeed = chaseSpeed;
    }
    private void Update()
    {
        CalculateAngle();

        if (justDashed && !bossDashLogic.isDashDuration)
        {
            isDoingKnifeThrow = true;
            FacePlayer();
            justDashed = false;
            print("Knife throw");
            if (isPhase2) StartCoroutine(DoTheKnifeThrow2());
            else StartCoroutine(DoTheKnifeThrow());
        }

        if (isAttacking)
        {
            switch (currentAttack)
            {
                case Attacks.Punch:
                    Punch();
                    break;
                case Attacks.KnifeThrow:
                    if (isDoingKnifeThrow) return;
                    KnifeThrow();
                    break;
                case Attacks.KnifeThrow2:
                    if (isDoingKnifeThrow) return;
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
            print("Punch");
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
            justDashed = true;
        }
    }
    private void KnifeThrow2()
    {
        if (tooCloseColliderLogic.isTooClose)
        {
            bossDashLogic.Dash();
            justDashed = true;
        }
        else
        {
            justDashed = true;
        }
    }
    private void DynamiteThrow()
    {
        print("Dynamite throw");
        isAttacking = false;
    }

    private IEnumerator DoTheKnifeThrow()
    {
        // 1. Display indicator
        indicator1.SetActive(true);
        animator.SetTrigger("OnThrow1");

        // 2. Wait for time
        yield return new WaitForSeconds(indicatorTime);

        // 3. Hide indicator, instantiate knife and give it velocity
        indicator1.SetActive(false);
        GameObject newKnife = Instantiate(knifeProjectile, projectileSpawnPoint.position, indicator1.transform.rotation);
        newKnife.GetComponent<Rigidbody2D>().velocity = newKnife.transform.up * knifeSpeed;

        // 4. Set the thingy
        StartCoroutine(AttackCooldown());
        isDoingKnifeThrow = false;
        isAttacking = false;
    }

    private IEnumerator DoTheKnifeThrow2()
    {
        // 1. Display indicator
        indicator1.SetActive(true);
        indicator2.SetActive(true);
        indicator3.SetActive(true);
        animator.SetTrigger("OnThrow2");

        // 2. Wait for time
        yield return new WaitForSeconds(indicatorTime);

        // 3. Hide indicator, instantiate knife and give it velocity
        indicator1.SetActive(false);
        indicator2.SetActive(false);
        indicator3.SetActive(false);
        GameObject newKnife = Instantiate(knifeProjectile, projectileSpawnPoint.position, indicator1.transform.rotation);
        GameObject newKnife2 = Instantiate(knifeProjectile, projectileSpawnPoint.position, indicator2.transform.rotation);
        GameObject newKnife3 = Instantiate(knifeProjectile, projectileSpawnPoint.position, indicator3.transform.rotation);
        newKnife.GetComponent<Rigidbody2D>().velocity = newKnife.transform.up * knifeSpeed;
        newKnife2.GetComponent<Rigidbody2D>().velocity = (indicator2.transform.rotation * Vector2.up).normalized * knifeSpeed;
        newKnife3.GetComponent<Rigidbody2D>().velocity = (indicator3.transform.rotation * Vector2.up).normalized * knifeSpeed;

        // 4. Set the thingy
        StartCoroutine(AttackCooldown());
        isDoingKnifeThrow = false;
        isAttacking = false;
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

    public void Damage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // Death
            print("Boss killed");
        }
    }
}
