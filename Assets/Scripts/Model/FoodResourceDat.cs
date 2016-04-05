using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Resource/Food", fileName = "New Food")]
public class FoodResourceDat : GameResourceDat {
	public override void toCell (Cell target)
	{
		target.Food = this;
	}

	public override void consumeSelf (Civilization owner, Cell cell)
	{
		base.consumeSelf (owner, cell);
		cell.FoodDuration--;
		if (cell.FoodDuration < 1) {
			cell.Food = null;
		}
	}
}
