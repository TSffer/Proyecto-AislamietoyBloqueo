using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectarColicionEval : MonoBehaviour
{
    //public OVRGrabbable grab;
    public GameObject canvas;
    public evaluacion sc;
    public int iElemento;
    public bool bValor = false;
    public UIHover uiListener;
    public bool bDeteccion = false;

    private void Start()
    {
        //grab = GetComponent<OVRGrabbable>();
        sc = FindObjectOfType<evaluacion>();
        //uiListener = FindObjectOfType<UIHover>();
    }

    public void Update()
    {
        //if (grab.isGrabbed && sc.bDesarrollo)
        //{
        //    canvas.SetActive(true);
        //}

    }

    void OnMouseDown()
    {
        if (bDeteccion)
        {
            if (uiListener.isUIOverride)
            {
                Debug.Log("Cancelled OnMouseDown! A UI element has override this object!");
            }
            else
            {
                Debug.Log("Object OnMouseDown");
                if (!bValor)
                    sc.OnElementoMesa(iElemento, false);
                else
                    sc.OnElementoEstrobo(iElemento);
                canvas.SetActive(true);
            }
        }

    }
}
