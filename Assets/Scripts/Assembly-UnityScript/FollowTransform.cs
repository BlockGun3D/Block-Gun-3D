using System;
using UnityEngine;

[Serializable]
public class FollowTransform : MonoBehaviour
{
	public Transform targetTransform;

	public bool faceForward;

	private Transform thisTransform;

	public virtual void Start()
	{
		thisTransform = transform;
	}

	public virtual void Update()
	{
		thisTransform.position = targetTransform.position;
		if (faceForward)
		{
			thisTransform.forward = targetTransform.forward;
		}
	}

	public virtual void Main()
	{
	}
}
