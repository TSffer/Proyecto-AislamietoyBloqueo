using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectarFin : MonoBehaviour
{
    public bool estrobofin = false;
    public bool Vernierfin = false;
    public bool cintafin = false;

    //public OVRGrabbable grabbervernier;
    //public OVRGrabbable grabberestrobo;
    //public OVRGrabbable grabbercinta;

    public GameObject panelfin;
    public scriptGeneralAct1 sc;


    // Start is called before the first frame update
    void Start()
    {
        sc = FindObjectOfType<scriptGeneralAct1>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(estrobofin && Vernierfin && cintafin)
        //{
        //    if(!grabbercinta.isGrabbed && !grabberestrobo.isGrabbed && !grabbervernier.isGrabbed)
        //    {
        //        sc.bPractica = false;
        //        panelfin.SetActive(true);
        //    }
        //}
    }
}
