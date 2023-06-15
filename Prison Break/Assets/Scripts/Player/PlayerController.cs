using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private WeaponHolder holder;
    [SerializeField] private float knifeSpeedBoost;

    #region Variables
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("Assignables")]
    [SerializeField] private Rigidbody2D rb;

    private Vector3 direction;
    #endregion 

    #region Execution
    private void Update()
    {
        if (holder.weapon != null)
        {
            if (holder.weapon.name == "Knife") moveSpeed = knifeSpeedBoost;
            else moveSpeed = 10;
        }
        CalculateDirection();
        
    }
    private void FixedUpdate()
    {
        Move();
    }
    #endregion

    #region Movement
    private void CalculateDirection()
    {
        float horiztonal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horiztonal, vertical, 0);
    }
    private void Move()
    {
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
    }
    #endregion
}
