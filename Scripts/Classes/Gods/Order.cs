using UnityEngine;
using System.Collections;

public abstract class Order {
	public abstract void execute (RaycastHit target);
}
