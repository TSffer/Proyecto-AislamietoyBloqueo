using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class sc_InspectorController : MonoBehaviour
{
    public scriptGeneralAct1 scriptgneral;
    public GameObject go_pnlOptions;
    public GameObject go_tgToogles;
    public GameObject go_pnlSuccess;
    public Text txt_message;
    public GameObject txt_log;
    public GameObject go_btnRestart;
    public GameObject go_btnContinue;

    public GameObject go_User;
    public GameObject posUser;

    public NavMeshAgent nm;
    public bool bClick = false;

    public void onContinueOptions()
    {
        if(!go_pnlOptions.transform.GetChild(2).GetChild(1).GetComponent<Toggle>().isOn &&
            !go_pnlOptions.transform.GetChild(2).GetChild(0).GetComponent<Toggle>().isOn &&
            !go_pnlOptions.transform.GetChild(2).GetChild(2).GetComponent<Toggle>().isOn &&
            !go_pnlOptions.transform.GetChild(2).GetChild(3).GetComponent<Toggle>().isOn)
        {
            txt_log.SetActive(true);
        }
        else if(go_pnlOptions.transform.GetChild(2).GetChild(1).GetComponent<Toggle>().isOn &&
            !go_pnlOptions.transform.GetChild(2).GetChild(0).GetComponent<Toggle>().isOn &&
            !go_pnlOptions.transform.GetChild(2).GetChild(2).GetComponent<Toggle>().isOn &&
            !go_pnlOptions.transform.GetChild(2).GetChild(3).GetComponent<Toggle>().isOn)
        {
            go_tgToogles.SetActive(false);
            txt_message.text = "Permiso otorgado!";
            go_pnlSuccess.SetActive(true);
            go_btnRestart.SetActive(false);
            go_btnContinue.SetActive(true);
            StartCoroutine(fGoStage());
        }
        else
        {
            go_tgToogles.SetActive(false);
            txt_message.text = "Acción erronea!";
            go_pnlSuccess.SetActive(true);
            go_btnRestart.SetActive(true);
            go_btnContinue.SetActive(false);
            Debug.Log("Error");
        }
    }

    public void onRestart()
    {
        go_pnlOptions.transform.GetChild(2).GetChild(1).GetComponent<Toggle>().isOn = false;
        go_pnlOptions.transform.GetChild(2).GetChild(0).GetComponent<Toggle>().isOn = false;
        go_pnlOptions.transform.GetChild(2).GetChild(2).GetComponent<Toggle>().isOn = false;
        go_pnlOptions.transform.GetChild(2).GetChild(3).GetComponent<Toggle>().isOn = false;
        go_btnContinue.SetActive(true);
        go_pnlSuccess.SetActive(false);
        go_tgToogles.SetActive(true);
    }

    void OnMouseDown()
    {
        if(!bClick)
        {
            scriptgneral.fProcessAyB(1, null); 
            nm.SetDestination(transform.position);
            StartCoroutine(foptions());
            bClick = true;
        }
    }

    IEnumerator foptions()
    {
        yield return new WaitForSeconds(7);
        if (!go_pnlOptions.activeSelf)
            go_pnlOptions.SetActive(true);
        else
            go_pnlOptions.SetActive(false);
    }

    IEnumerator fGoStage()
    {
        nm.enabled = false;
        yield return new WaitForSeconds(2);
        fPositionUser(posUser.transform.position, posUser.transform.eulerAngles);
        scriptgneral.fProcessAyB(2, null);
    }

    private void fPositionUser(Vector3 vPosition, Vector3 vAngles)
    {
        go_User.transform.localPosition = vPosition;
        go_User.transform.localEulerAngles = vAngles;
    }
}
