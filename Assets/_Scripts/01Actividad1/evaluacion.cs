
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class evaluacion : MonoBehaviour
{

    [Serializable]
    public class Bienvenida
    {
        public AudioClip audio;
        public GameObject goPanel;
        public GameObject goButton;
    }

    [Serializable]
    public class Evaluacion
    {
        public AudioClip audio;
        public GameObject goPanel;
        public GameObject goButton;
    }

    public Bienvenida Bienvenida_;
    //public Evaluacion[] Evaluacion_;

    public AudioSource audioSource;
    public GameObject goGuia;

    public GameObject panelPreguntaEstrobo;
    public GameObject panelPreguntaVernier;
    public GameObject panelPreguntaCinta;
    public GameObject panelSalida;

    public GameObject panelIndicacionEstrobo;
    public GameObject panelIndicacionVernier;
    public GameObject panelIndicacionCinta;

    public Text textoFinal;

    public bool bpreguntaEstrobo = false;
    public bool bpreguntaVernier = false;
    public bool bpreguntaCinta = false;

    public DateTime timeprguntaEstrobo;
    public DateTime timeprguntaVernier;
    public DateTime timeprguntacinta;

    /// Respuestas
    private bool brespuestaEstrobo = false;
    private bool brespuestaVernier = false;
    private bool brespuestaCinta = false;

    private double recordtimeEstrobo = 0;
    private double recordtimeVernier = 0;
    private double recordtimeCinta = 0;

    public AudioClip clipIndicacionEstrobo;
    public AudioClip clipIndicacionVernier;
    public AudioClip clipIndicacionCinta;
    public AudioClip clipPreguntaEstrobo;
    public AudioClip clipPreguntaVernier;
    public AudioClip clipPreguntaCinta;
    public AudioClip clipFin;

    public GameObject goEstrobo1;
    public GameObject goEstrobo2;
    public GameObject goEstrobo3;
    public GameObject goVernier;
    public GameObject goCinta;

    public GameObject goUsuario;
    public GameObject goDerecha;
    public GameObject goElementoRotarEstrobo;
    public GameObject goElementoRotar;

    // Start is called before the first frame update
    void Start()
    {
        timeprguntaEstrobo = new DateTime();
        timeprguntaVernier = new DateTime();
        timeprguntacinta = new DateTime();
        StartCoroutine(enumeratorMostrarBienvenida());
    }

    public void EmpezarPregunta(int ipregunta)
    {
        //print("Empezando pregunta " + ipregunta.ToString());
        if(!panelPreguntaCinta.activeSelf && !panelPreguntaEstrobo.activeSelf && !panelPreguntaVernier.activeSelf)
        {
            switch (ipregunta)
            {
                case 1:
                    if (!bpreguntaEstrobo)
                    {
                        panelIndicacionEstrobo.SetActive(false);
                        panelPreguntaEstrobo.SetActive(true);
                        timeprguntaEstrobo = DateTime.Now;
                        audioSource.Stop();
                        audioSource.clip = clipPreguntaEstrobo;
                        audioSource.Play();
                    }
                    break;
                case 2:
                    if (!bpreguntaVernier)
                    {
                        panelIndicacionVernier.SetActive(false);
                        panelPreguntaVernier.SetActive(true);
                        timeprguntaVernier = DateTime.Now;
                        audioSource.Stop();
                        audioSource.clip = clipPreguntaVernier;
                        audioSource.Play();
                    }
                    break;
                case 3:
                    if (!bpreguntaCinta)
                    {
                        panelIndicacionCinta.SetActive(false);
                        panelPreguntaCinta.SetActive(true);
                        timeprguntacinta = DateTime.Now;
                        audioSource.Stop();
                        audioSource.clip = clipPreguntaCinta;
                        audioSource.Play();
                    }
                    break;
            }
        }

    }

    public void onTermiarPregutna()
    {
        if (panelPreguntaCinta.activeSelf)
        {
            bool bFlag = false;
            foreach (Transform child in panelPreguntaCinta.transform.GetChild(2).transform)
            {
                if (child.GetComponent<Toggle>().isOn)
                {
                    bFlag = true;
                    break;
                }
            }
            if (bFlag)
            {
                TimeSpan temp = DateTime.Now - timeprguntacinta;
                recordtimeCinta = temp.TotalSeconds;
                if (panelPreguntaCinta.transform.GetChild(2).GetChild(0).GetComponent<Toggle>().isOn &&
                    !panelPreguntaCinta.transform.GetChild(2).GetChild(1).GetComponent<Toggle>().isOn &&
                    !panelPreguntaCinta.transform.GetChild(2).GetChild(2).GetComponent<Toggle>().isOn)
                {
                    brespuestaCinta = true;
                    print("ACIERTO TOTAL");
                }
                panelPreguntaCinta.SetActive(false);
                panelIndicacionCinta.SetActive(false);
                bpreguntaCinta = true;
                goElementoRotar.SetActive(false);
                fActivarMovimientoJugador(true);
            }
            else
            {
                panelPreguntaCinta.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (panelPreguntaEstrobo.activeSelf)
        {
            bool bFlag = false;
            foreach (Transform child in panelPreguntaEstrobo.transform.GetChild(2).transform)
            {
                if (child.GetComponent<Toggle>().isOn)
                {
                    bFlag = true;
                    break;
                }
            }
            if (bFlag)
            {
                TimeSpan temp = DateTime.Now - timeprguntaEstrobo;
                recordtimeEstrobo = temp.TotalSeconds;
                if ((panelPreguntaEstrobo.transform.GetChild(2).GetChild(0).GetComponent<Toggle>().isOn) 
                    && (!panelPreguntaEstrobo.transform.GetChild(2).GetChild(1).GetComponent<Toggle>().isOn) 
                    && (!panelPreguntaEstrobo.transform.GetChild(2).GetChild(2).GetComponent<Toggle>().isOn))
                {
                    brespuestaEstrobo = true;
                    print("ACIERTO TOTAL");
                }
                panelPreguntaEstrobo.SetActive(false);
                bpreguntaEstrobo = true;
                panelIndicacionVernier.SetActive(true);
                //goVernier.GetComponent<MeshCollider>().enabled = true;
                goEstrobo1.GetComponent<detectarColicionEval>().bDeteccion = false;
                goEstrobo2.GetComponent<detectarColicionEval>().bDeteccion = false;
                goEstrobo3.GetComponent<detectarColicionEval>().bDeteccion = false;
                goVernier.GetComponent<detectarColicionEval>().bDeteccion = true;
                audioSource.Stop();
                audioSource.clip = clipIndicacionVernier;
                audioSource.Play();
                goElementoRotarEstrobo.SetActive(false);
                fActivarMovimientoJugador(true);
            }
            else
            {
                panelPreguntaEstrobo.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (panelPreguntaVernier.activeSelf)
        {
            bool bFlag = false;
            foreach (Transform child in panelPreguntaVernier.transform.GetChild(2).transform)
            {
                if (child.GetComponent<Toggle>().isOn)
                {
                    bFlag = true;
                    break;
                }
            }
            if (bFlag)
            {
                TimeSpan temp = DateTime.Now - timeprguntaVernier;
                recordtimeVernier = temp.TotalSeconds;
                if (panelPreguntaVernier.transform.GetChild(2).GetChild(0).GetComponent<Toggle>().isOn &&
                    !panelPreguntaVernier.transform.GetChild(2).GetChild(1).GetComponent<Toggle>().isOn &&
                    !panelPreguntaVernier.transform.GetChild(2).GetChild(2).GetComponent<Toggle>().isOn)
                {
                    brespuestaVernier = true;
                    print("ACIERTO TOTAL");
                }
                panelPreguntaVernier.SetActive(false);
                panelIndicacionVernier.SetActive(false);
                bpreguntaVernier = true;
                panelIndicacionCinta.SetActive(true);
                goVernier.GetComponent<detectarColicionEval>().bDeteccion = false;
                goCinta.GetComponent<detectarColicionEval>().bDeteccion = true;
                audioSource.Stop();
                audioSource.clip = clipIndicacionCinta;
                audioSource.Play();
                goElementoRotar.SetActive(false);
                fActivarMovimientoJugador(true);
            }
            else
            {
                panelPreguntaVernier.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if(bpreguntaCinta && bpreguntaEstrobo && bpreguntaVernier)
        {
            StartCoroutine( db_InsertEvaluation(VarGlobals.sesion.id, 1));
            panelSalida.SetActive(true);
            audioSource.Stop();
            audioSource.clip = clipFin;
            audioSource.Play();
        }
    }
    public void OnElementoMesa(int iElemento, bool bValor)
    {
        goElementoRotar.SetActive(true);
        goElementoRotar.transform.GetChild(1).transform.GetComponent<scElementoRotar>().fActivarElemento(iElemento);
        //fActivarMovimientoJugador(false);
        //if (bValor)
        //{
        //    if (iElemento == 0)
        //    {
        //        FindObjectOfType<detectarFin>().Vernierfin = true;
        //        fReproducirAudioVernier();
        //    }
        //    else if (iElemento == 1)
        //    {
        //        FindObjectOfType<detectarFin>().cintafin = true;
        //        fReproducirAudioCinta();
        //    }
        //}
    }
    public void OnElementoEstrobo(int iElemento)
    {
        goElementoRotarEstrobo.SetActive(true);
        goElementoRotarEstrobo.transform.GetChild(1).transform.GetComponent<scElementoRotar>().fActivarElemento(iElemento);
        fActivarMovimientoJugador(false);
    }
    public void onFin()
    {
        SceneManager.LoadScene("00Intro_web");
    }

    public void onAudioFinished()
    {
        Bienvenida_.goButton.SetActive(true);
        goGuia.transform.GetComponent<Animator>().SetTrigger("bEspera");
    }

    public void onClickButtonStar()
    {
        goEstrobo1.GetComponent<detectarColicionEval>().bDeteccion = true;
        goEstrobo2.GetComponent<detectarColicionEval>().bDeteccion = true;
        goEstrobo3.GetComponent<detectarColicionEval>().bDeteccion = true;
        fActivarMovimientoJugador(true);
        Bienvenida_.goPanel.SetActive(false);
        panelIndicacionEstrobo.SetActive(true);
        audioSource.Stop();
        audioSource.clip = clipIndicacionEstrobo;
        audioSource.Play();
    }

    private void fReproducirAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
        goGuia.transform.GetComponent<Animator>().SetTrigger("bExplicacion");
        Invoke("onAudioFinished", audioSource.clip.length - audioSource.time);
    }
    public void fActivarMovimientoJugador(bool bEstado)
    {
        //goUsuario.transform.GetComponent<CharacterController>().enabled = bEstado;
        //goUsuario.transform.GetComponent<OVRPlayerController>().enabled = bEstado;
        goUsuario.transform.GetComponent<PlayerMoveControllerLeft>().enabled = bEstado;
        goDerecha.SetActive(bEstado);
    }

    IEnumerator enumeratorMostrarBienvenida()
    {
        yield return new WaitForSeconds(2);
        Bienvenida_.goPanel.SetActive(true);
        Bienvenida_.goButton.SetActive(false);
        fReproducirAudio(Bienvenida_.audio);
    }

    //php

    IEnumerator db_InsertEvaluation(int id_sesion, int id_activity)
    {
        WWWForm form = new WWWForm();
        form.AddField("id_sesion", id_sesion);
        form.AddField("id_activity", id_activity);
        form.AddField("date", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        form.AddField("id_usuario", VarGlobals.sesion.id_user);
        using (UnityWebRequest www = UnityWebRequest.Post("https://enel.cursso.digital/php/" + "setEvaluation.php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                textoFinal.text = "Error en la conexión";
            }
            else
            {
                string responseText = www.downloadHandler.text;
                JSONNode data = JSON.Parse(responseText);
                print(responseText);
                if (data["success"].Value.ToString() == "1")
                {
                    StartCoroutine(db_InsertEvaluationDetail(Convert.ToInt32((data["id"].Value.ToString())), "Selección Estrobo" , brespuestaEstrobo , recordtimeEstrobo));
                    StartCoroutine(db_InsertEvaluationDetail(Convert.ToInt32((data["id"].Value.ToString())), "Medida de Vernier", brespuestaVernier, recordtimeVernier));
                    StartCoroutine(db_InsertEvaluationDetail(Convert.ToInt32((data["id"].Value.ToString())), "Medida de longitud", brespuestaCinta, recordtimeCinta));
                }
                else
                {
                    textoFinal.text = "Error en la conexión";
                }
            }
        }
    }


    IEnumerator db_InsertEvaluationDetail(int id_sesion, string enunciante, bool answer , Double time)
    {
        WWWForm form = new WWWForm();

        form.AddField("id_evaluation", id_sesion);
        form.AddField("n_order", 0);
        form.AddField("step", 0);
        form.AddField("enunciate", enunciante);
        form.AddField("answer", answer ? 1 : 0);
        form.AddField("time", (int)time);

        using (UnityWebRequest www = UnityWebRequest.Post("https://enel.cursso.digital/php/" + "setEvaluationDetail.php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                textoFinal.text = "Error en la conexión";
            }
            else
            {
                string responseText = www.downloadHandler.text;
                JSONNode data = JSON.Parse(responseText);
                print(responseText);
                if (data["success"].Value.ToString() == "1")
                {
                    textoFinal.text = "Evaluación guardada con éxito";
                }
                else
                {
                    textoFinal.text = "Error en la conexión";
                }
            }
        }
    }
}
