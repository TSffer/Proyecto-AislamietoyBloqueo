﻿
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class scriptGeneralAct1 : MonoBehaviour
{

    [Serializable]
    public class Tablet
    {
        public AudioClip audio;
        public GameObject goPanel;
        public GameObject goButton;
        public GameObject goImageCorrect;
        public GameObject goImageIncorrect;
        public GameObject goCanvasStateAyB;
        public GameObject goCanvasBackpack;
        public Text txtTitle;
        public Text txtInfo;
        public VideoPlayer videoplayer;
    }
    [Serializable]
    public class Desarrollo
    {
        public AudioClip audio;
        public GameObject posUser;
        public GameObject posGuia;
        public GameObject goPanel;
    }
    [Serializable]
    public class LockoutTagout
    {
        public GameObject goEquipment;
        public GameObject goTagout;
        public GameObject[] goElements;
    }


    public menuWorkshopController menuworkshopcontroller;

    public enum enum_StepLT {Welcome, RequestPermission, IdentifyEquipment, Isolation, Lockout, Tagout, StoredEnergyCheck};
    public enum enum_IDEquipment {E01, E02, E03, E04, E05};

    public enum_StepLT enum_StepCurrent;
    public enum_IDEquipment enum_IDCurrent;

    public Tablet[] tablet_;
    public LockoutTagout[] lockouttagout;
    public GameObject[] goSlotsLockoutTagout;

    public AudioSource audioSource;
    public GameObject goUsuario;
    public GameObject goGuia;
    public GameObject goWorkshop;
    public GameObject goPosTools;
    public GameObject goCircularProgressBar;
    
    public int i_Step = 0;
    public bool bFinish = false;
    
    void Start()
    {
        tablet_[0].videoplayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "VideoFacebook.mp4");
        enum_StepCurrent = enum_StepLT.Welcome;
        StartCoroutine(enumeratorShowTablet());
    }
    public void fNextStep(int istep)
    {
        switch (istep)
        {
            case 1: // Solicitar permiso al Inspector
                i_Step = istep;
                tablet_[0].txtTitle.text = "Solicitar permiso";
                tablet_[0].txtInfo.text = "Antes de comenzar el proceso de aislamiento y bloqueo se debe solicitar el permiso al Inspector encargado del area";
                tablet_[0].txtInfo.fontSize = 65;
                menuworkshopcontroller.onClicMenu();
                StartCoroutine(enumeratorShowTablet());
                goCircularProgressBar.GetComponent<sc_RadialProgress>().fUpdateProgress();
                break;
            case 2: // Identificar Equipo
                i_Step = istep;
                tablet_[0].txtTitle.text = "Identificar Equipo";
                tablet_[0].txtInfo.text = "Identifique el equipo donde se realizará el aislamiento y bloqueo \n\n Código del equipo: " + "E05";
                tablet_[0].txtInfo.fontSize = 70;
                fProcessAyB(0,"");
                goCircularProgressBar.GetComponent<sc_RadialProgress>().fUpdateProgress();
                break;
            case 3: // Aislar
                i_Step = istep;
                tablet_[0].txtTitle.text = "Aislar";
                tablet_[0].txtInfo.text = "Una vez identificado el equipo procedemos a realizar el proceso de Aislamiento ";
                tablet_[0].txtInfo.fontSize = 65;
                tablet_[0].goImageCorrect.SetActive(false);
                //menuworkshopcontroller.onClicMenu();
                StartCoroutine(enumeratorShowTablet());
                fProcessAyB(2,"");
                goCircularProgressBar.GetComponent<sc_RadialProgress>().fUpdateProgress();
                break;
            case 4: // Bloquear
                i_Step = istep;
                tablet_[0].txtTitle.text = "Bloquear";
                tablet_[0].txtInfo.text = "Se ha realizado el aislamiento correctamente ahora el siguiente paso es el bloqueo del equipo";
                tablet_[0].txtInfo.fontSize = 65;
                tablet_[0].goCanvasStateAyB.SetActive(false);
                menuworkshopcontroller.onClicMenu();
                StartCoroutine(enumeratorShowTablet());
                fProcessAyB(3, "");
                break;
            case 5: // Etiquetado
                i_Step = istep;
                tablet_[0].txtTitle.text = "Etiquetado";
                tablet_[0].txtInfo.text = "Se ha realizado el bloqueo correctamente ahora el siguiente paso es el etiquetado del equipo";
                tablet_[0].txtInfo.fontSize = 65;
                tablet_[0].goCanvasBackpack.SetActive(true);
                //menuworkshopcontroller.onClicMenu();
                StartCoroutine(enumeratorShowTablet());
                break;
            case 6: // Prueba de energía cero
                break;
            case 7: // Bloqueo caja grupal
                break;
        }
    }
    public void fProcessAyB(int i_op, string s_codetypeTool)
    {
        switch (i_op)
        {
            case 0:
                menuworkshopcontroller.onClicMenu();
                StartCoroutine(enumeratorShowTablet());
                break;
            case 1:
                tablet_[0].txtTitle.text = "Identificar Equipo";
                tablet_[0].txtInfo.fontSize = 65;
                tablet_[0].goImageIncorrect.SetActive(false);
                tablet_[0].goImageCorrect.SetActive(false);
                tablet_[0].goButton.GetComponentInChildren<Text>().text = "Continuar";

                if (String.Equals("E05", s_codetypeTool))
                {
                    tablet_[0].txtInfo.text = "Codigo del equipo: " + s_codetypeTool + "\n\n\n El equipo fue identificado correctamente !";
                    tablet_[0].goImageCorrect.SetActive(true);
                    GameObject go_postool = GetChildWithName(goPosTools, "posTool" + s_codetypeTool);
                    StartCoroutine(fGoStage(go_postool));
                    i_Step = 3;
                    menuworkshopcontroller.onClicMenu();
                    StartCoroutine(enumeratorShowTablet());
                }
                else
                {
                    tablet_[0].txtInfo.text = "Codigo del equipo: " + s_codetypeTool + "\n\n\n El equipo seleccionado es incorrecto intente de nuevo!";
                    tablet_[0].goImageIncorrect.SetActive(true);
                    menuworkshopcontroller.onClicMenu();
                    tablet_[0].goButton.GetComponentInChildren<Text>().text = "Reintentar";
                }
                break;
            case 2:
                GameObject go_tool = GetChildWithName(goWorkshop, "Box030");
                go_tool.transform.GetComponent<BoxCollider>().enabled = false;
                break;
            case 3:

                break;
            case 4:
                lockouttagout[0].goElements[0].SetActive(true);
                lockouttagout[0].goElements[1].SetActive(true);
                lockouttagout[0].goElements[2].SetActive(true);
                i_Step = 5;
                menuworkshopcontroller.onClicMenu();
                StartCoroutine(enumeratorShowTablet());
                break;
            case 5:
                lockouttagout[0].goTagout.SetActive(true);
                break;
        }
    }
    public void onContinue()
    {
        if(i_Step == 2)
        {
            menuworkshopcontroller.onClicMenu();
        }
        else if(i_Step == 3)
        {
            //menuworkshopcontroller.onClicMenu();
            if(!bFinish)
            {
                fNextStep(3);
                bFinish = true;
            }
            else
            {
                bFinish = false;
                menuworkshopcontroller.onClicMenu();
                tablet_[0].goCanvasStateAyB.SetActive(true);
            }
                
        }
        else if(i_Step == 4)
        {
            menuworkshopcontroller.onClicMenu();
            goSlotsLockoutTagout[0].SetActive(true);
            tablet_[0].goCanvasBackpack.SetActive(true);
        }
        else if(i_Step == 5)
        {
            menuworkshopcontroller.onClicMenu();
            goSlotsLockoutTagout[1].SetActive(true);
            fNextStep(5);
        }
        else
        {
            menuworkshopcontroller.onClicMenu();
        }
    }

    IEnumerator enumeratorShowTablet()
    {
        tablet_[0].goButton.SetActive(false);
        yield return new WaitForSeconds(1);
        tablet_[0].goPanel.SetActive(true);
        fReproducirAudio(tablet_[0].audio);
    }
    private void fReproducirAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
        goGuia.transform.GetComponent<Animator>().SetTrigger("bExplicacion");
        Invoke("onAudioFinished", audioSource.clip.length - audioSource.time);
    }
    public void onAudioFinished()
    {
        goGuia.transform.GetComponent<Animator>().SetTrigger("bEspera");
        if (i_Step == 0)
        {
            tablet_[0].goButton.SetActive(true);
            goGuia.transform.GetComponent<sc_Highlighting>().OnTurnOn();
        }
        else if (i_Step == 1)
        {
            tablet_[0].goButton.SetActive(true);
        }
        else if (i_Step == 2)
        {
            tablet_[0].goButton.SetActive(true);
            GameObject go_tool = GetChildWithName(goWorkshop, "Box030");
            go_tool.transform.GetComponent<sc_Highlighting>().enabled = true;
        }
        else if (i_Step == 3)
        {
            tablet_[0].goButton.SetActive(true);
        }
        else if (i_Step == 4)
        {
            tablet_[0].goButton.SetActive(true);
        }
        else if (i_Step == 5)
        {
            tablet_[0].goButton.SetActive(true);
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
    public void onFin()
    {
        #if UNITY_ANDROID
                    SceneManager.LoadScene("00Login");
        #elif UNITY_WEBGL
                    SceneManager.LoadScene("00Login_web");
        #endif
    }
}
