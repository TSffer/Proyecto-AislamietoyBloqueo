
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
        public GameObject goCanvasRadio;
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

    public enum enum_StepAyB {Welcome, RequestPermission, IdentifyEquipment, Isolation, Lockout, Tagout, StoredEnergyCheck, GroupBoxLock};
    public enum enum_IDEquipment {E01, E02, E03, E04, E05};

    public enum_StepAyB enum_StepCurrent;
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
        enum_StepCurrent = enum_StepAyB.Welcome;
        fNextStep();
    }
    public void fNextStep()
    {
        switch (enum_StepCurrent)
        {
            case enum_StepAyB.Welcome: // Bienvenida
                fProcessAyB(0, null);
                break;
            case enum_StepAyB.RequestPermission: // Solicitar permiso al Inspector
                bFinish = false;
                tablet_[0].txtTitle.text = "Solicitar permiso";
                tablet_[0].txtInfo.text = "Antes de comenzar el proceso de aislamiento y bloqueo se debe solicitar el permiso al Inspector encargado del area";
                tablet_[0].txtInfo.fontSize = 65;
                fProcessAyB(0, null);
                break;
            case enum_StepAyB.IdentifyEquipment: // Identificar Equipo
                bFinish = false;
                tablet_[0].txtTitle.text = "Identificar Equipo";
                tablet_[0].txtInfo.text = "Identifique el equipo donde se realizará el aislamiento y bloqueo \n\n Código del equipo: " + "E05";
                tablet_[0].txtInfo.fontSize = 70;
                fProcessAyB(0, null);
                break;
            case enum_StepAyB.Isolation: // Aislar
                bFinish = false;
                tablet_[0].txtTitle.text = "Aislar";
                tablet_[0].txtInfo.text = "Una vez identificado el equipo procedemos a realizar el proceso de Aislamiento ";
                tablet_[0].txtInfo.fontSize = 65;
                tablet_[0].goImageCorrect.SetActive(false);
                fProcessAyB(0,null);
                break;
            case enum_StepAyB.Lockout: // Bloquear
                bFinish = false;
                tablet_[0].txtTitle.text = "Bloquear";
                tablet_[0].txtInfo.text = "Se ha realizado el aislamiento correctamente ahora el siguiente paso es el bloqueo del equipo";
                tablet_[0].txtInfo.fontSize = 65;
                tablet_[0].goCanvasStateAyB.SetActive(false);
                fProcessAyB(0, null);
                break;
            case enum_StepAyB.Tagout: // Etiquetado
                tablet_[0].txtTitle.text = "Etiquetado";
                tablet_[0].txtInfo.text = "Se ha realizado el bloqueo correctamente ahora el siguiente paso es el etiquetado del equipo";
                tablet_[0].txtInfo.fontSize = 65;
                tablet_[0].goCanvasBackpack.SetActive(true);
                fProcessAyB(0, null);
                break;
            case enum_StepAyB.StoredEnergyCheck: // Prueba de energía cero
                bFinish = false;
                tablet_[0].txtTitle.text = "Prueba de energía cero";
                tablet_[0].txtInfo.text = "Se ha realizado el Etiquetado correctamente ahora el siguiente paso es la prueba de energia cero";
                tablet_[0].txtInfo.fontSize = 65;
                tablet_[0].goCanvasBackpack.SetActive(false);
                fProcessAyB(0, null);
                break;
            case enum_StepAyB.GroupBoxLock: // Bloqueo caja grupal
                tablet_[0].txtTitle.text = "Bloqueo caja grupal";
                tablet_[0].txtInfo.text = "Se ha realizado el Etiquetado correctamente ahora el siguiente paso es la prueba de energia cero";
                tablet_[0].txtInfo.fontSize = 65;
                tablet_[0].goCanvasRadio.SetActive(false);
                fProcessAyB(0, null);
                break;
        }
    }
    public void fProcessAyB(int i_state, string s_codetypeTool)
    {
        switch (enum_StepCurrent)
        {
            case enum_StepAyB.Welcome:
                StartCoroutine(enumeratorShowTablet());
                break;
            case enum_StepAyB.RequestPermission:

                if (i_state == 0)
                {
                    menuworkshopcontroller.onClicMenu();
                }
                else if (i_state == 1)
                {
                    menuworkshopcontroller.onClicMenu();
                    StartCoroutine(enumeratorShowTablet());
                    goCircularProgressBar.GetComponent<sc_RadialProgress>().fUpdateProgress();
                }
                else if (i_state == 2)
                {
                    enum_StepCurrent = enum_StepAyB.IdentifyEquipment;
                    fNextStep();
                }
                break;
            case enum_StepAyB.IdentifyEquipment:
                if (i_state == 0)
                {
                    menuworkshopcontroller.onClicMenu();
                    StartCoroutine(enumeratorShowTablet());
                }
                else if (i_state == 1)
                {
                    tablet_[0].goImageIncorrect.SetActive(false);
                    tablet_[0].goImageCorrect.SetActive(false);
                    tablet_[0].goButton.GetComponentInChildren<Text>().text = "Continuar";

                    if (String.Equals("E05", s_codetypeTool))
                    {
                        tablet_[0].txtInfo.text = "Codigo del equipo: " + s_codetypeTool + "\n\n\n El equipo fue identificado correctamente !";
                        tablet_[0].goImageCorrect.SetActive(true);
                        GameObject go_postool = GetChildWithName(goPosTools, "posTool" + s_codetypeTool);
                        StartCoroutine(fGoStage(go_postool));

                        goCircularProgressBar.GetComponent<sc_RadialProgress>().fUpdateProgress();
                        bFinish = true;
                        fProcessAyB(0, null);
                    }
                    else
                    {
                        tablet_[0].txtInfo.text = "Codigo del equipo: " + s_codetypeTool + "\n\n\n El equipo seleccionado es incorrecto intente de nuevo!";
                        tablet_[0].goImageIncorrect.SetActive(true);
                        tablet_[0].goButton.GetComponentInChildren<Text>().text = "Reintentar";
                        fProcessAyB(0, null);
                    }
                }
                break;
            case enum_StepAyB.Isolation:
                if (i_state == 0)
                {
                    StartCoroutine(enumeratorShowTablet());
                }
                else if (i_state == 1)
                {
                    bFinish = true;
                    GameObject go_tool = GetChildWithName(goWorkshop, "Box030");
                    go_tool.transform.GetComponent<BoxCollider>().enabled = false;
                    tablet_[0].goCanvasStateAyB.SetActive(true);
                }
                else if (i_state == 2)
                {
                    tablet_[0].goCanvasStateAyB.SetActive(false);
                    enum_StepCurrent = enum_StepAyB.Lockout;
                    fNextStep();
                }
                break;
            case enum_StepAyB.Lockout:
                if(i_state == 0)
                {
                    menuworkshopcontroller.onClicMenu();
                    StartCoroutine(enumeratorShowTablet());
                }
                else if(i_state == 1)
                {
                    lockouttagout[0].goElements[0].SetActive(true);
                    lockouttagout[0].goElements[1].SetActive(true);
                    lockouttagout[0].goElements[2].SetActive(true);
                    enum_StepCurrent = enum_StepAyB.Tagout;
                    fNextStep();
                }
                break;
            case enum_StepAyB.Tagout:
                if(i_state == 0)
                {
                    menuworkshopcontroller.onClicMenu();
                    StartCoroutine(enumeratorShowTablet());
                }
                else if(i_state == 1)
                {
                    lockouttagout[0].goTagout.SetActive(true);
                    enum_StepCurrent = enum_StepAyB.StoredEnergyCheck;
                    fNextStep();
                }
                break;
            case enum_StepAyB.StoredEnergyCheck:
                if(i_state == 0)
                {
                    menuworkshopcontroller.onClicMenu();
                    StartCoroutine(enumeratorShowTablet());
                }
                else if(i_state == 1)
                {
                    //enum_StepCurrent = enum_StepAyB.GroupBoxLock;
                    //fNextStep();
                }
                break;
            case enum_StepAyB.GroupBoxLock:
                if (i_state == 0)
                {
                    menuworkshopcontroller.onClicMenu();
                    StartCoroutine(enumeratorShowTablet());
                }
                else if (i_state == 1)
                {
                    
                }
                break;
        }
    }
    public void Hoil()
    {
        Debug.Log("TEST");
    }
    public void onContinue()
    {
        switch(enum_StepCurrent)
        {
            case enum_StepAyB.Welcome:
                enum_StepCurrent = enum_StepAyB.RequestPermission;
                fNextStep();
                break;
            case enum_StepAyB.RequestPermission:
                if(!bFinish)
                {
                    fProcessAyB(0, null);
                }
                else
                {
                    fProcessAyB(1, null);
                }
                break;
            case enum_StepAyB.IdentifyEquipment:
                if(!bFinish)
                {
                    menuworkshopcontroller.onClicMenu();
                }
                else
                {
                    enum_StepCurrent = enum_StepAyB.Isolation;
                    fNextStep();
                }
                break;
            case enum_StepAyB.Isolation:
                if (!bFinish)
                {
                    menuworkshopcontroller.onClicMenu();
                    fProcessAyB(1, null);
                }
                else
                {
                 
                }
                break;
            case enum_StepAyB.Lockout:
                menuworkshopcontroller.onClicMenu();
                goSlotsLockoutTagout[0].SetActive(true);
                tablet_[0].goCanvasBackpack.SetActive(true);
                break;
            case enum_StepAyB.Tagout:
                menuworkshopcontroller.onClicMenu();
                goSlotsLockoutTagout[1].SetActive(true);
                break;
            case enum_StepAyB.StoredEnergyCheck:
                if(!bFinish)
                {
                    Debug.Log(" enum_StepAyB.StoredEnergyCheck: bFinish 1");
                    menuworkshopcontroller.onClicMenu();
                    tablet_[0].goCanvasRadio.SetActive(true);
                    bFinish = true; 
                }
                else
                {
                    Debug.Log(" enum_StepAyB.StoredEnergyCheck: bFinish 2");
                    enum_StepCurrent = enum_StepAyB.GroupBoxLock;
                    fNextStep();
                }
                break;
            case enum_StepAyB.GroupBoxLock:
                menuworkshopcontroller.onClicMenu();
                break;
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
        
        switch (enum_StepCurrent)
        {
            case enum_StepAyB.Welcome:
                tablet_[0].goButton.SetActive(true);
                goGuia.transform.GetComponent<sc_Highlighting>().OnTurnOn();
                break;
            case enum_StepAyB.RequestPermission:
                tablet_[0].goButton.SetActive(true);
                goGuia.transform.GetComponent<sc_Highlighting>().OnTurnOff();
                break;
            case enum_StepAyB.IdentifyEquipment:
                tablet_[0].goButton.SetActive(true);
                GameObject go_tool = GetChildWithName(goWorkshop, "Box030");
                go_tool.transform.GetComponent<sc_Highlighting>().OnTurnOn();
                break;
            case enum_StepAyB.Isolation:
                go_tool = GetChildWithName(goWorkshop, "Box030");
                go_tool.transform.GetComponent<sc_Highlighting>().OnTurnOff();
                tablet_[0].goButton.SetActive(true);
                break;
            case enum_StepAyB.Lockout:
                tablet_[0].goButton.SetActive(true);
                break;
            case enum_StepAyB.Tagout:
                tablet_[0].goButton.SetActive(true);
                break;
            case enum_StepAyB.StoredEnergyCheck:
                tablet_[0].goButton.SetActive(true);
                break;
            case enum_StepAyB.GroupBoxLock:
                tablet_[0].goButton.SetActive(true);
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
