using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scElementoRotar : MonoBehaviour
{
    private void OnEnable()
    {
        this.transform.eulerAngles = new Vector3(0, 0, 0);
        this.transform.GetChild(0).transform.gameObject.SetActive(false);
        this.transform.GetChild(1).transform.gameObject.SetActive(false);
        this.transform.GetChild(2).transform.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate((new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 500), Space.World);
        }
    }
    public void fActivarElemento(int iElemento) 
    {
        transform.GetChild(iElemento).transform.gameObject.SetActive(true);
    }
}

