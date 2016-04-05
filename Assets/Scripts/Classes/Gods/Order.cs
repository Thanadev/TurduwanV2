using UnityEngine;
using System.Collections;

public abstract class Order : ScriptableObject {
	public abstract void execute (RaycastHit target);
}
