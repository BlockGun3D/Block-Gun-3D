using System;
using UnityEngine;

[Serializable]
public class PlayerPickUp : MonoBehaviour
{
	public BlockType type;

	public int scoreValue;

	public bool destroyParent;

	public AudioClip pickupSound;

	public PlayerPickUp()
	{
		type = BlockType.GREEN;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PlayerPickupBox")
		{
			AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			UnityEngine.Object.Destroy(gameObject);
			Global.gm.AddBlock(type);
			if (destroyParent)
			{
				UnityEngine.Object.Destroy(transform.parent.gameObject);
			}
			Global.gm.AddToScore(scoreValue);
		}
	}

	public virtual void Main()
	{
	}
}
