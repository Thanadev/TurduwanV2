using UnityEngine;
using System.Collections;

public class OrderStat : Order {
	protected float modifier;
	protected Stat stat;

	public OrderStat (Stat stat, float modifier)
	{
		this.modifier = modifier;
		this.stat = stat;
	}

	public override void execute (RaycastHit target)
	{
		Cell cell = target.collider.GetComponent<Cell>();
		if (cell != null && cell.Owner != null) {
			cell.Owner.modifyStat((int) stat, modifier);
		}
	}
	
	public float Modifier {
		get {
			return this.modifier;
		}
		set {
			modifier = value;
		}
	}

	public Stat Stat {
		get {
			return this.stat;
		}
		set {
			stat = value;
		}
	}
}
