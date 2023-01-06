using System;
using UnityEngine;

[Serializable]
public class SettingsManager : MonoBehaviour
{
	public GameObject soundOnButton;

	public GameObject soundOffButton;

	public GameObject noInvertButton;

	public GameObject invertButton;

	public virtual void Start()
	{
		toggle(Global.gm.IsSoundOn(), soundOnButton, soundOffButton);
		toggle(!Global.gm.IsYAxisInverted(), noInvertButton, invertButton);
	}

	public virtual void SoundPressed()
	{
		Global.gm.ToggleSound();
		toggle(Global.gm.IsSoundOn(), soundOnButton, soundOffButton);
	}

	public virtual void InvertYPressed()
	{
		Global.gm.ToggleYAxis();
		toggle(!Global.gm.IsYAxisInverted(), noInvertButton, invertButton);
	}

	private void toggle(bool isDefault, GameObject defaultButton, GameObject changedButton)
	{
		ButtonScript buttonScript = (ButtonScript)defaultButton.GetComponent(typeof(ButtonScript));
		ButtonScript buttonScript2 = (ButtonScript)changedButton.GetComponent(typeof(ButtonScript));
		if (isDefault)
		{
			defaultButton.GetComponent<GUITexture>().enabled = true;
			buttonScript.enabled = true;
			changedButton.GetComponent<GUITexture>().enabled = false;
			buttonScript2.enabled = false;
		}
		else
		{
			defaultButton.GetComponent<GUITexture>().enabled = false;
			buttonScript.enabled = false;
			changedButton.GetComponent<GUITexture>().enabled = true;
			buttonScript2.enabled = true;
		}
	}

	public virtual void Main()
	{
	}
}
