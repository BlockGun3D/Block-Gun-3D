using System;
using UnityEngine;

[Serializable]
public class WeaponPickup : MonoBehaviour
{
	public GunType type;

	public bool destroyParent;

	public virtual void Start()
	{
		if (Global.gm.GetGunLevel(type) == 0)
		{
			DestroyPickup();
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PlayerPickupBox")
		{
			Global.wm.GotWeapon(type);
			DestroyPickup();
		}
	}

	public virtual void DestroyPickup()
	{
		if (destroyParent)
		{
			UnityEngine.Object.Destroy(transform.parent.gameObject);
		}
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void Main()
	{
	}
}
