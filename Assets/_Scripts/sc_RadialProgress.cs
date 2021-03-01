using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_RadialProgress : MonoBehaviour
{
    public GameObject goProgressText;
    public Text txt_ProgressIndicator;
    public Image imgProgressBar;
    float fcurrentValue;

	public void fUpdateProgress()
    {
		if (fcurrentValue < 100)
		{
			fcurrentValue += 12.5f;
			txt_ProgressIndicator.text = ((int)fcurrentValue).ToString() + "%";
			goProgressText.SetActive(true);
		}
		else
		{
			goProgressText.SetActive(false);
			txt_ProgressIndicator.text = "Done";
		}

		imgProgressBar.fillAmount = fcurrentValue / 100;
	}
}
