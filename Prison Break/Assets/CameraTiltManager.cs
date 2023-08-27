using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTiltManager : MonoBehaviour
{
    // 1. Get x distance from center point to player (default the centerPoint to Vector2.zero)
    // 2. Translate the distance number to rotation with a max rotation cap
    // 3. Rotate the camera based on the number

    [SerializeField] private float centerPoint = 0f;
    [SerializeField] private float rotationCap;
    [SerializeField] private float rotationToDistanceRatio;
    private Transform playerTransform;
    private float distanceFromCenter => Mathf.Clamp((playerTransform.position.x - centerPoint) * rotationToDistanceRatio, -rotationCap, rotationCap);

    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        distanceToRotation();
    }

    private void distanceToRotation()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, distanceFromCenter); 
    }
}
