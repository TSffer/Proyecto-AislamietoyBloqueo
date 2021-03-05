using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class sc_ItemSlot : MonoBehaviour, IDropHandler
{
    public scriptGeneralAct1 scriptgeneralact;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            if(scriptgeneralact.i_Step == 4)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Debug.Log("ItemSlot 1");
                scriptgeneralact.fProcessAyB(4, "");
            }
            else if(scriptgeneralact.i_Step == 5)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Debug.Log("ItemSlot 2");
                scriptgeneralact.fProcessAyB(5, "");
            }
        }
    }
}
