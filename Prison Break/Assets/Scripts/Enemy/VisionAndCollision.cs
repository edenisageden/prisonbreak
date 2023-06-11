using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionAndCollision : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask environmentLayer;
    [SerializeField] private LayerMask playerLayer;

    [Header("Assignables")]
    [SerializeField] private PolygonCollider2D visionCollider;
    [SerializeField] private BoxCollider2D rangedCollider;
    [SerializeField] private BoxCollider2D meleeCollider;
    [SerializeField] private BoxCollider2D frontCollider;

    private Transform playerTransform;
    [HideInInspector] public bool frontCollisionInRange;
    [HideInInspector] public bool rangedInRange;
    [HideInInspector] public bool meleeInRange;
    [HideInInspector] public bool visionInRange;
    [HideInInspector] public bool playerBehindWall;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        CheckCollidersTouchingPlayer();
        CheckPlayerBehindWall();
    }

    private void CheckCollidersTouchingPlayer()
    {
        if (frontCollider.IsTouchingLayers(environmentLayer)) frontCollisionInRange = true;
        else frontCollisionInRange = false;
        if (visionCollider.IsTouchingLayers(playerLayer) && !playerBehindWall) visionInRange = true;
        else visionInRange = false;
        if (rangedCollider.IsTouchingLayers(playerLayer) && !playerBehindWall) rangedInRange = true;
        else rangedInRange = false;
        if (meleeCollider.IsTouchingLayers(playerLayer) && !playerBehindWall) meleeInRange = true;
        else meleeInRange = false;
    }
    private void CheckPlayerBehindWall()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 20000f, ~enemyLayer);
        if (hit)
        {
            Debug.DrawLine(transform.position, hit.transform.position);
            if (hit.transform.CompareTag("Player")) playerBehindWall = false;
            else playerBehindWall = true;
        }
    }
}
