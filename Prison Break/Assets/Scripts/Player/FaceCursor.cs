using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCursor : MonoBehaviour
{
    [SerializeField] Transform cameraTransform; // Reference to the camera transform
    public bool canTurn = true;

    private void Update()
    {
        // Get the position of the mouse cursor in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position from screen coordinates to world coordinates
        Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction from the player's position to the cursor position
        Vector3 directionToCursor = cursorWorldPosition - transform.position;
        directionToCursor.z = 0f; // Ensure the z-axis is zero (assuming 2D gameplay)

        // Rotate the player to face the cursor
        if (directionToCursor != Vector3.zero && canTurn)
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, directionToCursor);
            transform.rotation = rotation;
        }

        // Reset the camera rotation
        cameraTransform.rotation = Quaternion.identity;
    }
}
