using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraParallax : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float lookMultiplier;

    private void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        transform.rotation = Quaternion.Euler(new Vector3(-mousePosition.y, mousePosition.x, 0f) * lookMultiplier);
    }
}
