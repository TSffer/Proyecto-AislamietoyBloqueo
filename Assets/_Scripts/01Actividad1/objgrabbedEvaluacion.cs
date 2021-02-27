using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objgrabbedEvaluacion : MonoBehaviour
{
    //private OVRGrabbable grabber;
    private evaluacion sc;
    public GameObject goimgcinta;
    // Start is called before the first frame update
    void Start()
    {
        //grabber = GetComponent<OVRGrabbable>();
        sc = FindObjectOfType<evaluacion>();

    }

    // Update is called once per frame
    void Update()
    {
        //try 
        //{
        //    if (grabber.isGrabbed && !sc.bpreguntaEstrobo && !FindObjectOfType<detectarFin>().estrobofin)
        //    {
        //        FindObjectOfType<detectarFin>().estrobofin = true;
        //        sc.EmpezarPregunta(1);
        //    }
        //}
        //catch { }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "vernier" && tag == "coli" && !FindObjectOfType<detectarFin>().Vernierfin)
        {
            //print("coliciono Vernier");
            FindObjectOfType<detectarFin>().Vernierfin = true;
            sc.EmpezarPregunta(2);
        }

        if (collision.gameObject.name == "cintaMetrica" && tag == "cinta" && !FindObjectOfType<detectarFin>().cintafin)
        {
            //print("coliciono cintaMetrica");
            FindObjectOfType<detectarFin>().cintafin = true;
            sc.EmpezarPregunta(3);
        }
        try
        {
            if (collision.gameObject.name == "cintaMetrica" && tag == "cinta" )
            {
            goimgcinta.GetComponent<Animator>().SetTrigger("bAparecer");
            }
        }
        catch { }
    }
    private void OnTriggerExit(Collider other)
    {
        try
        {
            if (other.gameObject.name == "cintaMetrica" && this.tag == "cinta")
            {
                goimgcinta.GetComponent<Animator>().SetTrigger("bDesaparecer");
            }
        }
        catch { }
    }


}
