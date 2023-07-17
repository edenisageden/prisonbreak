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
    private Vector2 currentVelocity;
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
            weaponHolder.canAttack = false;
            controller.canMove = false;
            currentVelocity = controller.previousDirection.normalized * dashSpeed;
        }
        else
        {
            weaponHolder.canAttack = true;
            controller.canMove = true;
            currentVelocity = Vector2.zero;
        }
    }

    private void Dash()
    {
        isDashDuration = true;
        dashCooldownOver = false;
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
