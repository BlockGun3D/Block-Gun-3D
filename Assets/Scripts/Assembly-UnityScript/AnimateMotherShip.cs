using System;
using UnityEngine;

[Serializable]
public class AnimateMotherShip : MonoBehaviour
{
	public Animation motherShip;

	public string animation1Name;

	public string animation2Name;

	public virtual void AnimateMotherShipVoid(bool activated)
	{
		if (activated)
		{
			if (!string.IsNullOrEmpty(animation1Name) && !string.IsNullOrEmpty(animation2Name))
			{
				motherShip.PlayQueued(animation1Name);
				motherShip.PlayQueued(animation2Name);
			}
			else if (!string.IsNullOrEmpty(animation1Name))
			{
				motherShip.Play(animation1Name);
			}
		}
	}

	public virtual void Main()
	{
	}
}
