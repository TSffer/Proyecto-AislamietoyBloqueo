using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelEval : MonoBehaviour
{
    public evaluacion sc;
    public GameObject goElemento;
    // Start is called before the first frame update
    void Start()
    {
        sc = FindObjectOfType<evaluacion>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onCerrar() 
    {
        goElemento.SetActive(false);
        this.gameObject.SetActive(false);
        sc.fActivarMovimientoJugador(true);
    }
}
