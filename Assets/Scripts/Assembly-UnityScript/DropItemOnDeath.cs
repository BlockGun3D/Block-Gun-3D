using System;
using UnityEngine;

[Serializable]
public class DropItemOnDeath : MonoBehaviour
{
	public GameObject[] dropItems;

	public float[] chanceOfDropping;

	public virtual void Die()
	{
		for (int i = 0; i < dropItems.Length; i++)
		{
			float num = (float)Global.gm.GetLuckLevel() * (chanceOfDropping[i] / 2f);
			if (!(chanceOfDropping[i] + num <= UnityEngine.Random.value))
			{
				Transform transform = this.transform;
				int num2 = 0;
				Vector3 position = transform.position;
				float num3 = (position.y = num2);
				Vector3 vector2 = (transform.position = position);
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(dropItems[i], transform.position, transform.rotation);
				break;
			}
		}
	}

	public virtual void Main()
	{
	}
}
