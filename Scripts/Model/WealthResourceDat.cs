using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Resource/Wealth", fileName = "New Wealth")]
public class WealthResourceDat : GameResourceDat {
	public override void toCell (Cell target)
	{
		target.Wealth = this;
	}
}
