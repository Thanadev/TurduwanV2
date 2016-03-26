using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Order/Stat", fileName = "New Stat Order")]
public class OrderStat : Order {
	public float modifier;
	public Stat stat;

	public override void execute (RaycastHit target)
	{
		Cell cell = target.collider.GetComponent<Cell>();
		if (cell != null && cell.Owner != null) {
			cell.Owner.modifyStat((int) stat, modifier);
		}
	}
}
