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
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Debug.Log("ItemSlot");
            scriptgeneralact.fProcessAyB(4, "");
        }
    }
}
