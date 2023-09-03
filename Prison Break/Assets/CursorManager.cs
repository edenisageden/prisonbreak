using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public bool cursorIsCrossHair;
    [SerializeField] private Texture2D mouseCursorTexture, crossHairTexture;

    private void Update()
    {
        if (cursorIsCrossHair)
        {
            Cursor.SetCursor(crossHairTexture, new Vector2(10, 10), CursorMode.Auto);

        }
        else
        {
            Cursor.SetCursor(mouseCursorTexture, new Vector2(10, 10), CursorMode.Auto);
        }
    }
}
