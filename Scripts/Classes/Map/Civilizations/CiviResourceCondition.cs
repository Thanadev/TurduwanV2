using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CiviResourceCondition : CiviCondition {
	GameResource resource;

	public CiviResourceCondition (GameResource resource)
	{
		this.resource = resource;
	}

	public override bool isVerified (Cell host)
	{
		List<Cell> area = Map.getCellsInArea(host.Position, 1);
		foreach (Cell cell in area) {
			if (cell != null) {
				if (cell.Food != null && cell.Food.Id == resource.Id) {
					return true;
				}
				if (cell.Wealth != null && cell.Wealth.Id == resource.Id) {
					return true;
				}
			}
		}

		return false;
	}
}
