using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_CursorController : MonoBehaviour
{
    public static sc_CursorController instance;
    public Texture2D texture_handOpen;
    public Texture2D texture_handClosed;

    private void Awake()
    {
        instance = this;
    }
    public void fActivateHandOpen()
    {
        Cursor.SetCursor(texture_handOpen, new Vector2(texture_handOpen.width / 2, texture_handOpen.height / 2), CursorMode.Auto);
    }
    public void fActivateHandClosed()
    {
        Cursor.SetCursor(texture_handClosed, new Vector2(texture_handClosed.width / 2, texture_handClosed.height / 2), CursorMode.Auto);
    }
    public void fClearCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
