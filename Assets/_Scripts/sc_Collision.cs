using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Collision : MonoBehaviour
{
    public scriptGeneralAct1 general;
    public bool click = false;
    public string s_codetypeTool;
    void OnMouseDown()
    {
        if(!click)
        {
            general.fProcessAyB(1, s_codetypeTool);
            click = true;
        }
    }
}
