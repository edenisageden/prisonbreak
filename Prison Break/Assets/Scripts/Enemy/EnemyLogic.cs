using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(AIDestinationSetter))]
[RequireComponent(typeof(AIPath))]
[RequireComponent(typeof(VisionAndCollision))]
public class EnemyLogic : MonoBehaviour
{
    [Header("Config")]
    //[SerializeField] private Weapon selectedWeapon;
    [SerializeField] private WanderingTypes wanderingType;
    [SerializeField] private float wanderSpeed;
    [SerializeField] private float chasingSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float timeBetweenRotationForRandom;
    [SerializeField] private int randomRotationCountMin, randomRotationCountMax;
    [SerializeField] private bool rotateClockwise;
    [SerializeField] private float rotationTimeMax, rotationTimeMin;

    [Header("Assignables")]
    [SerializeField] private AIDestinationSetter aiDestinationSetter;
    [SerializeField] private AIPath aiPath;
    [SerializeField] private VisionAndCollision visionAndCollision;
    [SerializeField] private Rigidbody2D rb;

    [Header("Debugging")]
    [SerializeField] private EnemyStates enemyState = EnemyStates.Wandering;

    private Transform playerTransform;
    private bool randomRotateTimerTicking = false;
    private bool isDoingRandomRotate = false;
    private bool lookoutTimerTicking = false;
    private float perimeterRotateAmount => rotateClockwise ? -90 : 90;
    private float lookoutRotateAmount => rotateClockwise ? -180 : 180;

    public enum WanderingTypes
    {
        Still, Perimeter, Random, Lookout
    }
    public enum EnemyStates
    {
        Wandering, Chasing, Attacking, Death
    }

    private void Awake()
    {
        LeanTween.reset();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        aiPath.maxSpeed = chasingSpeed;
    }
    private void Update()
    {
        /*CheckIfInRange();
        switch (enemyState)
        {
            case EnemyStates.Wandering:
                DoWandering();
                break;
            case EnemyStates.Chasing:
                DoChasing();
                break;
            case EnemyStates.Attacking:
                DoAttacking();
                break;
        }*/
    }
    private void FixedUpdate()
    {
        // Temporarily fixed bug where multiple rotations happen
        CheckIfInRange();
        switch (enemyState)
        {
            case EnemyStates.Wandering:
                DoWandering();
                break;
            case EnemyStates.Chasing:
                DoChasing();
                break;
            case EnemyStates.Attacking:
                DoAttacking();
                break;
        }
    }

    #region Wandering
    private void DoWandering()
    {
        aiDestinationSetter.target = null;
        switch (wanderingType)
        {
            case WanderingTypes.Still: DoStill(); break;
            case WanderingTypes.Perimeter: DoPerimeter(); break;
            case WanderingTypes.Random: DoRandom(); break;
            case WanderingTypes.Lookout: DoLookout(); break;
        }
        if (visionAndCollision.visionInRange) enemyState = EnemyStates.Chasing;
    }
    private void DoStill()
    {

    }
    private void DoPerimeter()
    {
        transform.position += transform.up * wanderSpeed * Time.deltaTime;
        if (visionAndCollision.frontCollisionInRange) RotateAmount(perimeterRotateAmount, rotationSpeed);
    }
    private void DoRandom()
    {
        if (!isDoingRandomRotate)
        {
            transform.position += transform.up * wanderSpeed * Time.deltaTime;
            if (visionAndCollision.frontCollisionInRange)
            {
                float randomAngle = Random.Range(-180, 180);
                RotateAmount(randomAngle, rotationSpeed);
            }
            if (!randomRotateTimerTicking)
            {
                StartCoroutine(DoRandomRotateTimer());
            }
        }
    }
    private void DoLookout()
    {
        if (!lookoutTimerTicking) StartCoroutine(LookoutTimer());
    }
    private IEnumerator DoRandomRotate()
    {
        isDoingRandomRotate = true;
        int rotateAmount = Random.Range(randomRotationCountMin, randomRotationCountMax);
        for (int i = 0; i < rotateAmount; i++)
        {
            yield return new WaitForSeconds(timeBetweenRotationForRandom);
            float randomAngle = Random.Range(-180, 180);
            RotateAmount(randomAngle, rotationSpeed);
        }
        isDoingRandomRotate = false;
        randomRotateTimerTicking = false;
    }
    private IEnumerator DoRandomRotateTimer()
    {
        randomRotateTimerTicking = true;
        yield return new WaitForSeconds(Random.Range(rotationTimeMin, rotationTimeMax));
        StartCoroutine(DoRandomRotate());
    }
    private IEnumerator LookoutTimer()
    {
        lookoutTimerTicking = true;
        yield return new WaitForSeconds(Random.Range(rotationTimeMin, rotationTimeMax));
        RotateAmount(lookoutRotateAmount, rotationSpeed);
        lookoutTimerTicking = false;
        if (rotateClockwise) rotateClockwise = false;
        else rotateClockwise = true;
    }
    #endregion

    private void DoChasing()
    {
        aiDestinationSetter.target = playerTransform;
    }
    private void DoAttacking()
    {
        aiDestinationSetter.target = playerTransform;
    }

    private void CheckIfInRange()
    {
        if (enemyState == EnemyStates.Chasing || enemyState == EnemyStates.Attacking)
        {
            if (visionAndCollision.rangedInRange) enemyState = EnemyStates.Attacking;
            else enemyState = EnemyStates.Chasing;
        }
    }
    private void RotateAmount(float rotationAmount, float rotationTime)
    {
        LeanTween.init();
        if (LeanTween.isTweening(gameObject)) return;
        LeanTween.reset();
        LeanTween.cancel(gameObject);
        LeanTween.rotateAround(gameObject, Vector3.forward, rotationAmount, rotationTime);
    }
}
