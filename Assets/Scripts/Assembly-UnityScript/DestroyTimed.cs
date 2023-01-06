using System;
using UnityEngine;

[Serializable]
public class DestroyTimed : MonoBehaviour
{
	public float lifeTime;

	public float variance;

	public bool destroyParent;

	public DestroyTimed()
	{
		lifeTime = 1f;
	}

	public virtual void Start()
	{
		float t = UnityEngine.Random.value * variance - variance / 2f + lifeTime;
		if (destroyParent)
		{
			UnityEngine.Object.Destroy(transform.parent.gameObject, t);
		}
		UnityEngine.Object.Destroy(gameObject, t);
	}

	public virtual void Main()
	{
	}
}
