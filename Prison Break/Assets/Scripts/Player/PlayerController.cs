using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
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
        CalculateDirection();
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
