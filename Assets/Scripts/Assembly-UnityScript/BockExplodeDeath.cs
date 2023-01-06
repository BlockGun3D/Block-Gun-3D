using System;
using UnityEngine;

[Serializable]
public class BockExplodeDeath : MonoBehaviour
{
	public GameObject explodeObject;

	public int numExplodeObjects;

	public int numExplodeVariance;

	public float speed;

	public float distanceOfObjectsFromCenter;

	public Color color1;

	public BlockType type1;

	public Color color2;

	public BlockType type2;

	public bool destroyParent;

	public AudioClip deathSound;

	private Transform thisTransform;

	public BockExplodeDeath()
	{
		numExplodeObjects = 5;
		speed = 1f;
		distanceOfObjectsFromCenter = 1f;
	}

	public virtual void Start()
	{
		thisTransform = transform;
	}

	public virtual void Die()
	{
		if ((bool)deathSound)
		{
			AudioSource.PlayClipAtPoint(deathSound, thisTransform.position, 5f);
		}
		BoxCollider boxCollider = (BoxCollider)this.gameObject.GetComponent(typeof(BoxCollider));
		Vector3 vector = new Vector3(0f, boxCollider.center.y, 0f);
		float num = StaticFuncs.RandomVal(numExplodeObjects, numExplodeVariance);
		for (int i = 0; (float)i < num; i++)
		{
			Vector3 onUnitSphere = UnityEngine.Random.onUnitSphere;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(explodeObject, thisTransform.position + onUnitSphere * distanceOfObjectsFromCenter + vector, thisTransform.rotation);
			gameObject.GetComponent<Rigidbody>().velocity = onUnitSphere * speed;
			PlayerPickUp playerPickUp = (PlayerPickUp)gameObject.GetComponent(typeof(PlayerPickUp));
			if (!(UnityEngine.Random.value <= 0.5f))
			{
				gameObject.GetComponent<Renderer>().material.color = color1;
				if ((bool)playerPickUp)
				{
					playerPickUp.type = type1;
				}
			}
			else
			{
				gameObject.GetComponent<Renderer>().material.color = color2;
				if ((bool)playerPickUp)
				{
					playerPickUp.type = type2;
				}
			}
		}
		UnityEngine.Object.Destroy(this.gameObject, 0f);
		this.gameObject.SetActive(false);
		if (destroyParent)
		{
			UnityEngine.Object.Destroy(thisTransform.parent.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
