using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Collision : MonoBehaviour
{
    public scriptGeneralAct1 general;
    public bool click = false;
    void OnMouseDown()
    {
        if(!click)
        {
            general.fgoTools(1);
            click = true;
        }
    }
}
