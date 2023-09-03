using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public bool cursorIsCrossHair;
    public bool isMenu = false;
    [SerializeField] private Texture2D mouseCursorTexture, crossHairTexture;
    [SerializeField] private NextLevelBox nextLevelBox;
    [SerializeField] private GameMenuManager gameMenuManager;

    private void FixedUpdate()
    {
        print("Hello");
        if (!isMenu)
        {
            if (nextLevelBox.isCompleteFully) cursorIsCrossHair = false;
            else cursorIsCrossHair = true;
            if (gameMenuManager.isPaused) cursorIsCrossHair = false;
            else cursorIsCrossHair = true;
        }
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
