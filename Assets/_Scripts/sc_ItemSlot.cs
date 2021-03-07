using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class sc_ItemSlot : MonoBehaviour, IDropHandler
{
    public scriptGeneralAct1 scriptgneral;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            if(scriptgneral.enum_StepCurrent == scriptGeneralAct1.enum_StepAyB.Lockout)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Debug.Log("scriptGeneralAct1.enum_StepAyB.Lockout");
                scriptgneral.fProcessAyB(1, null);
            }
            else if(scriptgneral.enum_StepCurrent == scriptGeneralAct1.enum_StepAyB.Tagout)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Debug.Log("scriptGeneralAct1.enum_StepAyB.Tagout");
                scriptgneral.fProcessAyB(1, null);
            }
        }
    }
}
