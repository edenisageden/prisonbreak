using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void FixedUpdate()
    {
        rb.velocity = currentVelocity * Time.deltaTime;
    }
    private void Update()
    {
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
        currentAngle = bossLogic.angle;
        isDashDuration = true;
        StartCoroutine(DashDuration());
    }

    private IEnumerator DashDuration()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashDuration = false;
    }
}
