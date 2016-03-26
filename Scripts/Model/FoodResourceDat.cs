using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Resource/Food", fileName = "New Food")]
public class FoodResourceDat : GameResourceDat {
	public override void toCell (Cell target)
	{
		target.Food = this;
	}
}
