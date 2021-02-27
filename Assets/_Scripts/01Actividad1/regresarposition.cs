using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regresarposition : MonoBehaviour
{
   // private OVRGrabbable grabber;
    private Vector3 posInit;
    private Vector3 rotInit;
    private Transform posInicial;
    // Start is called before the first frame update
    void Start()
    {
        //grabber = GetComponent<OVRGrabbable>();
        posInit = transform.localPosition;
        rotInit = transform.localEulerAngles;
        posInicial = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!grabber.isGrabbed)
        //{
            
        //    this.transform.localPosition = posInit;
        //    this.transform.localEulerAngles = rotInit;
            
        //}
    }
}
