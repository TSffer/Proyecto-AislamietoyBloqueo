using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Grabbable : MonoBehaviour
{
    private bool bcanGrab;

    private void Update()
    {
        if(bcanGrab)
        {
            if(Input.GetMouseButton(0))
            {
                sc_CursorController.instance.fActivateHandClosed();
            }

            if(Input.GetMouseButtonUp(0))
            {
                sc_CursorController.instance.fActivateHandOpen();
            }
        }
    }
    private void OnMouseEnter()
    {
        sc_CursorController.instance.fActivateHandOpen();
        bcanGrab = true;
    }
    private void OnMouseExit()
    {
        sc_CursorController.instance.fClearCursor();
        bcanGrab = false;
    }
}
