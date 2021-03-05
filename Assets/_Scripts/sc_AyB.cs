using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_AyB : MonoBehaviour
{
    public scriptGeneralAct1 sc_general;
    public bool click = false;

    void OnMouseDown()
    {
        if (!click && !sc_general.bFinish)
        {
            transform.Rotate(90.0f, 0.0f, 0.0f);
            sc_general.tablet_[0].goCanvasStateAyB.GetComponentInChildren<Image>().fillAmount += 0.25f;
            float fvalue = sc_general.tablet_[0].goCanvasStateAyB.GetComponentInChildren<Image>().fillAmount;
            if (fvalue <= 0.50f)
            {
                sc_general.tablet_[0].goCanvasStateAyB.GetComponentInChildren<Image>().color = Color.red;
            }
            if (fvalue >= 0.50f && fvalue <= 0.75f)
            {
                sc_general.tablet_[0].goCanvasStateAyB.GetComponentInChildren<Image>().color = new Color(1.0f, 0.32f, 0.0f);
            }
            if (fvalue >= 1.0f)
            {
                sc_general.tablet_[0].goCanvasStateAyB.GetComponentInChildren<Image>().color = new Color(0.149f, 0.65f, 0.0f);
                sc_general.tablet_[0].goCanvasStateAyB.GetComponentInChildren<Text>().text = "Exito";
                sc_general.fNextStep(4);
            }
            this.GetComponent<BoxCollider>().enabled = false;
            click = true;
        }
    }
}
