using System;
using UnityEngine;

[Serializable]
public class FullScreenAd : MonoBehaviour
{
	[NonSerialized]
	private static float lastTimeAd;

	public virtual void FullScreenAdVoid(bool activated)
	{
		if (activated && Global.gm.ShouldShowAds() && (Time.time - lastTimeAd > 80f || !(lastTimeAd >= 1f)))
		{
			lastTimeAd = Time.time;
		}
	}

	public virtual void Main()
	{
	}
}
