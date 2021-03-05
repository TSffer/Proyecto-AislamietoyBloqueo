using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;

public class sc_Highlighting : MonoBehaviour
{
    public bool seeThrough = false;
    protected bool _seeThrough = true;
    protected Highlighter h;
    Color col;
    protected void Awake()
    {
		h = GetComponent<Highlighter>();
        if (h == null)
        {
            h = gameObject.AddComponent<Highlighter>();
        }
    }
    private void Start()
    {
        col = Color.red;
    }
    void OnEnable()
    {
        if (seeThrough)
        {
            h.SeeThroughOn();
        }
        else
        {
            h.SeeThroughOff();
        }
    }
    public void OnTurnOn()
    {
        h.ConstantOnImmediate(col);
    }
    public void OnTurnOff()
    {
        h.Off();
    }
}
