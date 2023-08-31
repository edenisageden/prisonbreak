using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Rendering;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    public static event Action OnDoorOpen = delegate { };
    private bool isOpen;

    public void OpenDoor(bool clockwise = true)
    {
        if (isOpen) return;
        OnDoorOpen?.Invoke();
        col.enabled = false;

        Vector3 currentRotation = transform.eulerAngles;

        float newRotationX = currentRotation.x;
        float newRotationY = currentRotation.y;
        float newRotationZ = currentRotation.z;
        if (clockwise) newRotationZ -= 90f;       
        else newRotationZ += 90f;

        transform.eulerAngles = new Vector3(newRotationX, 0, newRotationZ);

        isOpen = true;
    }
}
