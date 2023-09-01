using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossDashLogic : MonoBehaviour
{
    [SerializeField] private float dashSpeed, dashDuration;
    [HideInInspector] public bool isDashDuration;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 currentVelocity;
    [SerializeField] private BossLogic bossLogic;
    private Vector2 currentAngle;
    public Vector2 currentRB;
    [SerializeField] private Animator animator;
    private Vector2 movementDirection;
    public event Action OnDash = delegate { };

    private void FixedUpdate()
    {
        rb.velocity = currentVelocity * Time.deltaTime;
    }
    private void Update()
    {
        StartCoroutine(CalculateMovementDirection());
        currentRB = rb.velocity;

        if (isDashDuration)
        {
            currentVelocity = currentAngle * dashSpeed;
        }
        else
        {
            currentVelocity = Vector2.zero;
        }
    }

    public void Dash()
    {
        if (!isDashDuration) animator.SetTrigger("OnDash");
        //rb.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Atan2(currentAngle.y, currentAngle.normalized.x) * Mathf.Rad2Deg) - 90f);
        currentAngle = bossLogic.angle;
        isDashDuration = true;
        StartCoroutine(DashDuration());
    }

    private IEnumerator DashDuration()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashDuration = false;
    }

    private IEnumerator CalculateMovementDirection()
    {
        Vector2 beforePosition = transform.position;
        yield return new WaitForSeconds(0.05f);
        Vector2 afterPosition = transform.position;
        movementDirection = afterPosition - beforePosition;
    }
}
