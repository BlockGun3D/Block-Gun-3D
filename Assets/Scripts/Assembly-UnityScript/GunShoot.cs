using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(AudioSource))]
public class GunShoot : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Shoot_0024195 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024i_0024196;

			internal Vector3 _0024pos_0024197;

			internal float _0024varianceX_0024198;

			internal float _0024varianceY_0024199;

			internal GameObject _0024clone_0024200;

			internal Vector3 _0024vec_0024201;

			internal GunShoot _0024self__0024202;

			public _0024(GunShoot self_)
			{
				_0024self__0024202 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024202.clipLeft != 0f)
					{
						_0024self__0024202.clipLeft -= 1f;
						for (_0024i_0024196 = 0; _0024i_0024196 < _0024self__0024202.numProjectiles; _0024i_0024196++)
						{
							_0024pos_0024197 = _0024self__0024202.thisTransform.TransformDirection(_0024self__0024202.bulletSpawnOffset);
							_0024varianceX_0024198 = _0024self__0024202.accuracy * StaticFuncs.RandomVal(0f, _0024self__0024202.aimVariance);
							_0024varianceY_0024199 = _0024self__0024202.accuracy * StaticFuncs.RandomVal(0f, _0024self__0024202.aimVariance);
							_0024clone_0024200 = (GameObject)UnityEngine.Object.Instantiate(_0024self__0024202.projectile, _0024self__0024202.thisTransform.position + _0024pos_0024197, _0024self__0024202.thisTransform.rotation);
							_0024vec_0024201 = new Vector3(_0024varianceX_0024198, _0024varianceY_0024199, 1f);
							Vector3.Normalize(_0024vec_0024201);
							_0024clone_0024200.GetComponent<Rigidbody>().velocity = _0024self__0024202.thisTransform.TransformDirection(_0024vec_0024201 * _0024self__0024202.speed);
							_0024clone_0024200.SendMessage("SetDamage", _0024self__0024202.damage);
						}
						_0024self__0024202.parent.GetComponent<Animation>().Play(_0024self__0024202.recoilAnimationName);
						if ((bool)_0024self__0024202.childAnimation)
						{
							_0024self__0024202.childAnimation.Play();
						}
						_0024self__0024202.shotSound.Play();
						if ((bool)_0024self__0024202.particleSys)
						{
							_0024self__0024202.particleSys.Emit(1);
						}
						_0024self__0024202.thisLight.enabled = true;
						result = (Yield(2, new WaitForSeconds(0.2f)) ? 1 : 0);
						break;
					}
					_0024self__0024202.clickSound.Play();
					if (_0024self__0024202.ammoLeft > 0 || _0024self__0024202.infiniteAmmo)
					{
						_0024self__0024202.reloadButton.GetComponent<Animation>().Play("flashRed");
					}
					else
					{
						_0024self__0024202.changeWeaponButton.GetComponent<Animation>().Play("flashRed");
					}
					goto IL_02c2;
				case 2:
					_0024self__0024202.thisLight.enabled = false;
					goto IL_02c2;
				case 1:
					{
						result = 0;
						break;
					}
					IL_02c2:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GunShoot _0024self__0024203;

		public _0024Shoot_0024195(GunShoot self_)
		{
			_0024self__0024203 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024203);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Reload_0024204 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024clipEmpty_0024205;

			internal GunShoot _0024self__0024206;

			public _0024(GunShoot self_)
			{
				_0024self__0024206 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024206.ammoLeft > 0)
					{
						_0024self__0024206.reloadButton.GetComponent<Animation>().Stop();
						WeaponManager.canFire = false;
						_0024self__0024206.parent.GetComponent<Animation>().PlayQueued("Reload", QueueMode.CompleteOthers);
						result = (Yield(2, new WaitForSeconds(0.2f)) ? 1 : 0);
						break;
					}
					_0024self__0024206.clickSound.Play();
					if (_0024self__0024206.clipLeft == 0f && !_0024self__0024206.infiniteAmmo)
					{
						_0024self__0024206.changeWeaponButton.GetComponent<Animation>().Play("flashRed");
					}
					goto IL_0218;
				case 2:
					_0024self__0024206.reloadSound.Play();
					result = (Yield(3, new WaitForSeconds(0.3f)) ? 1 : 0);
					break;
				case 3:
					WeaponManager.canFire = true;
					if (_0024self__0024206.infiniteAmmo)
					{
						_0024self__0024206.clipLeft = _0024self__0024206.clipSize;
					}
					else
					{
						_0024clipEmpty_0024205 = (float)_0024self__0024206.clipSize - _0024self__0024206.clipLeft;
						if (_0024self__0024206.ammoLeft >= _0024self__0024206.clipSize)
						{
							_0024self__0024206.clipLeft = _0024self__0024206.clipSize;
							_0024self__0024206.ammoLeft = (int)((float)_0024self__0024206.ammoLeft - _0024clipEmpty_0024205);
						}
						else if (!(_0024clipEmpty_0024205 <= (float)_0024self__0024206.ammoLeft))
						{
							_0024self__0024206.clipLeft += (float)_0024self__0024206.ammoLeft;
							_0024self__0024206.ammoLeft = 0;
						}
						else
						{
							_0024self__0024206.clipLeft = _0024self__0024206.clipSize;
							_0024self__0024206.ammoLeft = (int)((float)_0024self__0024206.ammoLeft - _0024clipEmpty_0024205);
						}
					}
					goto IL_0218;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0218:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GunShoot _0024self__0024207;

		public _0024Reload_0024204(GunShoot self_)
		{
			_0024self__0024207 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024207);
		}
	}

	public GunType gunType;

	public GameObject projectile;

	public int numProjectiles;

	public float speed;

	public float damage;

	public GUITexture fireButton;

	public GUITexture reloadButton;

	public GUITexture changeWeaponButton;

	public GUIText ammoGUI;

	public bool continuous;

	public Vector3 bulletSpawnOffset;

	public ParticleSystem particleSys;

	public string recoilAnimationName;

	public bool startingWithOneAmmo;

	public float aimVariance;

	public bool infiniteAmmo;

	public int maxAmmo;

	public int[] clipSizes;

	public float[] fireRates;

	public float[] accuracies;

	public AudioSource shotSound;

	public AudioSource clickSound;

	public AudioSource reloadSound;

	public Animation childAnimation;

	internal float nextFire;

	private Transform thisTransform;

	private int shootingFinger;

	private GameObject parent;

	private Light thisLight;

	private int ammoLeft;

	private int clipSize;

	private float fireRate;

	private float accuracy;

	private float clipLeft;

	private GameManager gm;

	public GunShoot()
	{
		numProjectiles = 1;
		speed = 150f;
		damage = 1f;
		bulletSpawnOffset = new Vector3(0f, 0f, 0f);
		clipSizes = new int[4];
		fireRates = new float[4];
		accuracies = new float[4];
		shootingFinger = -1;
	}

	public virtual void Start()
	{
		gm = GameManager.GetInstance();
		thisTransform = transform;
		parent = thisTransform.parent.gameObject;
		thisLight = (Light)parent.GetComponentInChildren(typeof(Light));
		Reset();
	}

	public virtual void Reset()
	{
		int num = Global.gm.GetGunLevel(gunType);
		if (num > 0)
		{
			num--;
		}
		clipSize = clipSizes[num];
		clipLeft = clipSize;
		ammoLeft = clipSize;
		if (startingWithOneAmmo)
		{
			clipLeft = 1f;
		}
		fireRate = fireRates[num];
		accuracy = accuracies[num];
	}

	public virtual void Update()
	{
		GameState gameState = gm.GetGameState();
		if (gameState == GameState.PLAYING)
		{
			UpdateGameplay();
		}
	}

	public virtual void UpdateGameplay()
	{
		//Discarded unreachable code: IL_017a
		if (infiniteAmmo)
		{
			ammoGUI.text = string.Empty + clipLeft + "/==";
		}
		else
		{
			ammoGUI.text = string.Empty + clipLeft + "/" + ammoLeft;
		}
		if (!WeaponManager.canFire)
		{
			return;
		}
		if ((StaticFuncs.TestButtonTouchBegan(reloadButton) || Input.GetKeyDown("r")) && clipLeft != (float)clipSize)
		{
			StartCoroutine(Reload());
		}
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WP8Player)
		{
			int touchCount = Input2.touchCount;
			for (int i = 0; i < touchCount; i++)
			{
				Touch touch = Input2.GetTouch(i);
				if ((fireButton.HitTest(touch.position) || touch.fingerId == shootingFinger) && !(Time.time <= nextFire) && (continuous || touch.phase == TouchPhase.Began))
				{
					shootingFinger = touch.fingerId;
					nextFire = Time.time + fireRate;
					StartCoroutine(Shoot());
					break;
				}
				if (touch.phase == TouchPhase.Ended)
				{
					shootingFinger = -1;
				}
			}
		}
		else if (!(Time.time <= nextFire) && (Input.GetButtonDown("Fire1") || (Input.GetButton("Fire1") && continuous)))
		{
			nextFire = Time.time + fireRate;
			StartCoroutine(Shoot());
		}
	}

	public virtual IEnumerator Shoot()
	{
		return new _0024Shoot_0024195(this).GetEnumerator();
	}

	public virtual IEnumerator Reload()
	{
		return new _0024Reload_0024204(this).GetEnumerator();
	}

	public virtual void AddAmmo(int numClips)
	{
		if (!infiniteAmmo)
		{
			ammoLeft += clipSize * numClips;
			if (ammoLeft > maxAmmo)
			{
				ammoLeft = maxAmmo;
			}
		}
	}

	public virtual void Main()
	{
	}
}
