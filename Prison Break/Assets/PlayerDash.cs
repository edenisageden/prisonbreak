using System;
using System.Collections; 
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float dashSpeed, dashCooldown, dashDuration;
    private bool dashCooldownOver = true, isDashDuration;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerController controller;
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private PlayerDeath playerDeath;
    [SerializeField] private Animator animator;
    [SerializeField] private FaceCursor faceCursor;
    private Vector2 currentVelocity;
    public static event Action OnPlayerDash = delegate { };
    [SerializeField] private Collider2D playerCollider;
    private void FixedUpdate()
    {
        rb.velocity = currentVelocity * Time.deltaTime;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCooldownOver) Dash();
        }

        if (isDashDuration)
        {
            playerDeath.immortal = true;
            playerCollider.enabled = false;
            weaponHolder.canAttack = false;
            controller.canMove = false;
            faceCursor.canTurn = false;
            transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Atan2(controller.previousDirection.normalized.y, controller.previousDirection.normalized.x) * Mathf.Rad2Deg) - 90f);
            currentVelocity = controller.previousDirection.normalized * dashSpeed;
        }
        else
        {
            playerDeath.immortal = false;
            playerCollider.enabled = true;
            weaponHolder.canAttack = true;
            faceCursor.canTurn = true;
            controller.canMove = true;
            currentVelocity = Vector2.zero;
        }
    }

    private void Dash()
    {
        //rb.velocity = Vector2.zero;
        isDashDuration = true;
        dashCooldownOver = false;
        animator.SetTrigger("onRoll");
        OnPlayerDash?.Invoke();
        StartCoroutine(DashCooldown());
        StartCoroutine(DashDuration());
    }
    
    private IEnumerator DashDuration()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashDuration = false;
    }

    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        dashCooldownOver = true;
    }
}
