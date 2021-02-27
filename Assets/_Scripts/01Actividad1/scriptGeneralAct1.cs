
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scriptGeneralAct1 : MonoBehaviour
{

    [Serializable]
    public class Tablet
    {
        public AudioClip audio;
        public GameObject goPanel;
        public GameObject goButton;
        public GameObject goImage;
        public Text txtTitle;
        public Text txtInfo;
    }
    [Serializable]
    public class Desarrollo
    {
        public AudioClip audio;
        public GameObject posUser;
        public GameObject posGuia;
        public GameObject goPanel;
    }
  
    public menuWorkshopController menuworkshopcontroller;

    public Tablet[] tablet_;
    
    public AudioSource audioSource;
    public Desarrollo desarrollo_;

    public GameObject goUsuario;
    public GameObject goGuia;
    public GameObject goWorkshop;
    public GameObject goPosTools;

    public GameObject goCircularProgressBar;
    public int i_Step = 0;
    void Start()
    {
        StartCoroutine(enumeratorShowTablet());
    }

    public void fNextStep(int istep)
    {
        switch (istep)
        {
            case 1:
                tablet_[0].txtTitle.text = "Solicitar permiso";
                tablet_[0].txtInfo.text = "Antes de comenzar el proceso de aislamiento y bloqueo se debe solicitar el permiso al Inspector encargado del area";
                tablet_[0].txtInfo.fontSize = 65;
                menuworkshopcontroller.onClicMenu();
                StartCoroutine(enumeratorShowTablet());
                goCircularProgressBar.GetComponent<sc_RadialProgress>().fUpdateProgress();
                break;
            case 2:
                fgoTools(0);
                goCircularProgressBar.GetComponent<sc_RadialProgress>().fUpdateProgress();
                break;
            case 3:
                fgoTools(3);
                goCircularProgressBar.GetComponent<sc_RadialProgress>().fUpdateProgress();
                break;
        }
    }

    public void onAudioFinished()
    {
        goGuia.transform.GetComponent<Animator>().SetTrigger("bEspera");
        if (i_Step == 0)
        {
            tablet_[0].goButton.SetActive(true);
            goGuia.transform.GetComponent<sc_Highlighting>().enabled = true;
            //Bienvenida_[0].goPanel.SetActive(false);
        }        
        else if(i_Step == 1)
        {
            tablet_[0].goButton.SetActive(true);
        }
        else if(i_Step == 2)
        {
            tablet_[0].goButton.SetActive(true);
            GameObject go_tool = GetChildWithName(goWorkshop, "Box030");
            go_tool.transform.GetComponent<sc_Highlighting>().enabled = true;
            //go_tool.GetComponent<sc_Highlighting>().OnEnable();
        }
        else if(i_Step == 3)
        {
            tablet_[0].goButton.SetActive(true);
            GameObject go_tool = GetChildWithName(goWorkshop, "Box030");
            go_tool.GetComponent<sc_Highlighting>().OnEnable();
            go_tool = GetChildWithName(go_tool, "interruptor004");
            go_tool.transform.GetComponent<sc_Highlighting>().enabled = true;
            Debug.Log("Instante step 3 inAudioFinish");
        }
    }
    public void onFin()
    {
    #if UNITY_ANDROID
            SceneManager.LoadScene("00Login");
    #elif UNITY_WEBGL
            SceneManager.LoadScene("00Login_web");
    #endif
    }

    public void onContinue()
    {
        switch (i_Step)
        {
            case 0:
                menuworkshopcontroller.onClicMenu();
                i_Step = 1;
                break;
            case 1:
                menuworkshopcontroller.onClicMenu();
                break;
            case 2:
                menuworkshopcontroller.onClicMenu();
                break;
            case 3:
                menuworkshopcontroller.onClicMenu();
                fNextStep(i_Step);
                break;
        }

    }

    private void fReproducirAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
        goGuia.transform.GetComponent<Animator>().SetTrigger("bExplicacion");
        Invoke("onAudioFinished", audioSource.clip.length - audioSource.time);
    }
  

    IEnumerator enumeratorShowTablet()
    {
        tablet_[0].goButton.SetActive(false);
        yield return new WaitForSeconds(1);
        tablet_[0].goPanel.SetActive(true);
        fReproducirAudio(tablet_[0].audio);
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

    public void fgoTools(int i_op)
    {
        switch (i_op)
        {
            case 0:
                tablet_[0].txtTitle.text = "Identificar Equipo";
                tablet_[0].txtInfo.text = "Codigo del equipo: E05";
                tablet_[0].txtInfo.fontSize = 70;
                menuworkshopcontroller.onClicMenu();
                StartCoroutine(enumeratorShowTablet());
                break;
            case 1:
                GameObject go_postool = GetChildWithName(goPosTools, "posToolE05");
                StartCoroutine(fGoStage(go_postool));
                fgoTools(2);
                break;
            case 2:
                i_Step = 3;
                tablet_[0].txtTitle.text = "Identificar Equipo";
                tablet_[0].txtInfo.text = "Codigo del equipo: E05 \n\n\n El equipo fue identificado correctamente !";
                tablet_[0].txtInfo.fontSize = 65;
                tablet_[0].goImage.SetActive(true);
                menuworkshopcontroller.onClicMenu();
                StartCoroutine(enumeratorShowTablet());
                break;
            case 3:
                GameObject go_tool = GetChildWithName(goWorkshop, "Box030");
                go_tool.transform.GetComponent<BoxCollider>().enabled = false;
                go_tool = GetChildWithName(go_tool, "interruptor004");
                go_tool.GetComponent<sc_AyB>().fTypeSwitch(1);
                break;
        }


    }

    IEnumerator fGoStage(GameObject go_postool)
    {
        yield return new WaitForSeconds(1);
        fPositionUser(go_postool.transform.position, go_postool.transform.eulerAngles);
    }

    private void fPositionUser(Vector3 vPosition, Vector3 vAngles)
    {
        goUsuario.transform.localPosition = vPosition;
        goUsuario.transform.localEulerAngles = vAngles;
    }
}
