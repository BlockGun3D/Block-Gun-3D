using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ResetGame : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Activate_0024217 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject[] _0024pickups_0024218;

			internal GameObject _0024pickup_0024219;

			internal int _0024_002472_0024220;

			internal GameObject[] _0024_002473_0024221;

			internal int _0024_002474_0024222;

			internal ResetGame _0024self__0024223;

			public _0024(ResetGame self_)
			{
				_0024self__0024223 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Global.pm.Reset();
					_0024pickups_0024218 = GameObject.FindGameObjectsWithTag("Pickup");
					_0024_002472_0024220 = 0;
					_0024_002473_0024221 = _0024pickups_0024218;
					for (_0024_002474_0024222 = _0024_002473_0024221.Length; _0024_002472_0024220 < _0024_002474_0024222; _0024_002472_0024220++)
					{
						UnityEngine.Object.Destroy(_0024_002473_0024221[_0024_002472_0024220]);
					}
					Global.gm.SetReviveCost(1);
					Global.gm.ResetLevelBlockCount();
					Global.gm.ResetScore();
					result = (Yield(2, new WaitForSeconds(0.6f)) ? 1 : 0);
					break;
				case 2:
					Global.gm.SetGameState(_0024self__0024223.stateToResetTo);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ResetGame _0024self__0024224;

		public _0024Activate_0024217(ResetGame self_)
		{
			_0024self__0024224 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024224);
		}
	}

	public GameState stateToResetTo;

	private GameManager gameManager;

	public virtual IEnumerator Activate()
	{
		return new _0024Activate_0024217(this).GetEnumerator();
	}

	public virtual void Deactivate()
	{
		gameObject.SetActive(false);
	}

	public virtual void Main()
	{
	}
}
