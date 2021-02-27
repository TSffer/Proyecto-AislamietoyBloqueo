using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuWorkshopController : MonoBehaviour
{
    public GameObject arrow;
    public GameObject goTrackingSpace;
    public GameObject goCanvasDisplay;
    public Text txtMessage;
    bool bFlag = true;
    public float fVariacionY = 0;

    //Lerp
    private bool bMoverObj = false;
    private float tDuracion = 0f;
    private float tInicioMov = 0;
    private Vector3 AnguloInicial;
    private Vector3 AnguloFinal;
    public GameObject goObjMover;

    private void Start()
    {
        StartCoroutine(variationAngleCamera());        
    }
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (bMoverObj)
        {
            float tDesdeInicio = Time.time - tInicioMov;
            float pCompleto = tDesdeInicio / tDuracion;
            float yLerp = Mathf.LerpAngle(AnguloInicial.y, AnguloFinal.y, pCompleto);
            goObjMover.transform.localEulerAngles = new Vector3(0, yLerp, 0);
            if (pCompleto >= 1.0f)
            {
                bMoverObj = false;
                goObjMover = null;
            }
        }
    }
    public void onEndShowMenuWorkShop() 
    {
        arrow.transform.localEulerAngles = new Vector3(0, 0, -90);
        txtMessage.text = "Ocultar Tablet";
    }
    public void onEndHideMenuWorkShop()
    {
        arrow.transform.localEulerAngles = new Vector3(0, 0, 90);
        txtMessage.text = "Mostrar Tablet";
    }
    public void onClicMenu() 
    {
        if (!bFlag)
        {
            bFlag = true;
            this.GetComponent<Animator>().SetTrigger("Show");
        }
        else 
        {
            bFlag = false;
            this.GetComponent<Animator>().SetTrigger("Hide");
        }
    }
    void fMoverObjeto(GameObject goObj, Vector3 _v3AngFinal, float _tDuracion)
    {
        bMoverObj = true;
        goObjMover = goObj;
        tDuracion = _tDuracion;
        tInicioMov = Time.time;
        AnguloInicial = goObj.transform.localEulerAngles;
        AnguloFinal = _v3AngFinal;
    }
    IEnumerator variationAngleCamera() 
    {        
        fVariacionY = goTrackingSpace.transform.localEulerAngles.y -  (360 - goCanvasDisplay.transform.localEulerAngles.y) ;
        yield return new WaitForSeconds(1);
        if (Mathf.Abs(fVariacionY) > 15)
        {
            fMoverObjeto(goCanvasDisplay, new Vector3(goCanvasDisplay.transform.localEulerAngles.x, -goTrackingSpace.transform.localEulerAngles.y, goCanvasDisplay.transform.localEulerAngles.z), 0.5f);
         }
        StartCoroutine(variationAngleCamera());
    }
}
