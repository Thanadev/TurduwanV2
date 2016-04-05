using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Resource/Wealth", fileName = "New Wealth")]
public class WealthResourceDat : GameResourceDat {
	public override void toCell (Cell target)
	{
		target.Wealth = this;
	}

	public override void consumeSelf (Civilization owner, Cell cell)
	{
		base.consumeSelf (owner, cell);
		cell.WealthDuration--;
		if (cell.WealthDuration < 1) {
			cell.Wealth = null;
		}
	}
}
