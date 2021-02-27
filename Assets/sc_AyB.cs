using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_AyB : MonoBehaviour
{
    public scriptGeneralAct1 general;
    public bool click = false;

    void OnMouseDown()
    {
        //if(iType == 1)
        //{
            transform.Rotate(30.0f, 0.0f, 0.0f);
            click = true;
            Debug.Log("Holas");
        //}
        
    }
    public void fDeactivateEquipment(int i_type)
    {
        switch (i_type)
        {
            case 1:
                
                
                break;
        }
    }

    public void fTypeSwitch(int itype)
    {

        Debug.Log("Ejecutando aislamiento");
    }
}
