using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/Misc/Civi Conditions/Resource", fileName = "New Condition", order = 999)]
public class CiviResourceConditionDat : CiviConditionDat {

	public GameResourceDat resource;

	public override bool isVerified (Cell host)
	{
		List<Cell> area = Map.getCellsInArea(host.Position, 1);
		foreach (Cell cell in area) {
			if (cell != null) {
				if (cell.Food != null && cell.Food.id == resource.id) {
					return true;
				}
				if (cell.Wealth != null && cell.Wealth.id == resource.id) {
					return true;
				}
			}
		}

		return false;
	}
}
