using UnityEngine;
using System.Collections;

public class AgregarQuitarContorno : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AgregarContorno(GameObject goObj)
	{
		if (!goObj.GetComponent<CompoundObjectController>())
		{
			goObj.AddComponent<CompoundObjectController>();
			goObj.GetComponent<CompoundObjectController>().flashingStartColor = new Color32(255, 255, 255, 255);
			goObj.GetComponent<CompoundObjectController>().flashingEndColor = new Color32(198, 124, 2, 255);
			goObj.GetComponent<CompoundObjectController>().flashingDelay = 0;
			goObj.GetComponent<CompoundObjectController>().flashingFrequency = 0.5f;
			goObj.GetComponent<CompoundObjectController>().seeThrough = false;

		}
	}
	public void AgregarContorno(GameObject goObj,Color32 color1,Color32 color2)
	{
		if (!goObj.GetComponent<CompoundObjectController>())
		{
			goObj.AddComponent<CompoundObjectController>();
			goObj.GetComponent<CompoundObjectController>().flashingStartColor = color1;
			goObj.GetComponent<CompoundObjectController>().flashingEndColor = color2;
			goObj.GetComponent<CompoundObjectController>().flashingDelay = 0f;
			goObj.GetComponent<CompoundObjectController>().flashingFrequency = 0.1f;
        }
	}
	public void AgregarQuitar(GameObject goObj, Color32 color1, Color32 color2)
	{
		if (goObj.GetComponent<CompoundObjectController>())
		{
			Destroy(goObj.GetComponent<CompoundObjectController>());
			Destroy(goObj.GetComponent("Highlighter"));
		}
		if (!goObj.GetComponent<CompoundObjectController>())
		{
			goObj.AddComponent<CompoundObjectController>();
			goObj.GetComponent<CompoundObjectController>().flashingStartColor = color1;
			goObj.GetComponent<CompoundObjectController>().flashingEndColor = color2;
			goObj.GetComponent<CompoundObjectController>().flashingDelay = 0;
			goObj.GetComponent<CompoundObjectController>().flashingFrequency = 0.5f;
		}
	}
	
	public void QuitarContorno(GameObject goObj)
	{
		if (goObj.GetComponent<CompoundObjectController>())
		{
			Destroy(goObj.GetComponent<CompoundObjectController>());
			Destroy(goObj.GetComponent("Highlighter"));
		}
	}
}

