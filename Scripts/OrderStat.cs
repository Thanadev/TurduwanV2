using UnityEngine;
using System.Collections;

public class OrderStat : Order {
	protected float modifier;
	protected string stat;

	public OrderStat (string stat, float modifier)
	{
		this.modifier = modifier;
		this.stat = stat;
	}

	public override void execute ()
	{
		Debug.Log("Cool");
	}
	
	public float Modifier {
		get {
			return this.modifier;
		}
		set {
			modifier = value;
		}
	}

	public string Stat {
		get {
			return this.stat;
		}
		set {
			stat = value;
		}
	}
}
