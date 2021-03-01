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
        texture_handOpen = Resize(texture_handOpen, 70, 70);
        texture_handClosed = Resize(texture_handClosed, 70, 70);
    }
    private void Start()
    {

       
    }
    public void fActivateHandOpen()
    {
     #if UNITY_WEBGL
            
            Cursor.SetCursor(texture_handOpen, new Vector2(texture_handOpen.width / 2, texture_handOpen.height / 2), CursorMode.ForceSoftware);
    #else
            Cursor.SetCursor(texture_handOpen, new Vector2(texture_handOpen.width / 2, texture_handOpen.height / 2), CursorMode.Auto);
    #endif
    }
    public void fActivateHandClosed()
    {
#if UNITY_WEBGL
       
        Cursor.SetCursor(texture_handClosed, new Vector2(texture_handClosed.width / 2, texture_handClosed.height / 2), CursorMode.ForceSoftware);
    #else
            Cursor.SetCursor(texture_handClosed, new Vector2(texture_handClosed.width / 2, texture_handClosed.height / 2), CursorMode.Auto);
    #endif
    }
    public void fClearCursor()
    {
    #if UNITY_WEBGL
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    #else
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    #endif
    }

    Texture2D Resize(Texture2D texture2D, int targetX, int targetY)
    {
        RenderTexture rt = new RenderTexture(targetX, targetY, 24);
        RenderTexture.active = rt;
        Graphics.Blit(texture2D, rt);
        Texture2D result = new Texture2D(targetX, targetY);
        result.ReadPixels(new Rect(0, 0, targetX, targetY), 0, 0);
        result.Apply();
        return result;
    }
}

