using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public bool cursorIsCrossHair;
    public bool isMenu = false;
    [SerializeField] private Texture2D mouseCursorTexture, crossHairTexture;
    [SerializeField] private GameObject completionMenu;
    [SerializeField] private GameMenuManager gameMenuManager;

    private void Update()
    {
        if (!isMenu)
        {
            if (completionMenu.activeSelf || gameMenuManager.isPaused) Cursor.SetCursor(mouseCursorTexture, new Vector2(10, 10), CursorMode.Auto);
            else Cursor.SetCursor(crossHairTexture, new Vector2(10, 10), CursorMode.Auto);
            /*if (gameMenuManager.isPaused) cursorIsCrossHair = false;
            else cursorIsCrossHair = true;*/
        }

        /*if (cursorIsCrossHair)
        {
            Cursor.SetCursor(crossHairTexture, new Vector2(10, 10), CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(mouseCursorTexture, new Vector2(10, 10), CursorMode.Auto);
        }*/
    }
}
