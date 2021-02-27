using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;

public class sc_Highlighting : MonoBehaviour
{
    protected Highlighter h;
    public bool seeThrough = true;
    public bool _seeThrough = true;

    protected void Awake()
    {
        h = GetComponent<Highlighter>();
        if (h == null)
        {
            h = gameObject.AddComponent<Highlighter>();
        }
    }
    void Start()
    {
        h.SeeThroughOn();
        h.ConstantSwitch();
    }

    public void OnEnable()
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
