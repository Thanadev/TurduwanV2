using UnityEngine;
using System.Collections;

public class OrderSpawn : Order {

	protected GameResource toSpawn;

	public OrderSpawn (GameResource toSpawn)
	{
		this.toSpawn = toSpawn;
	}
	

	public override void execute (RaycastHit target)
	{
		Cell cell = target.collider.GetComponent<Cell>();
		if (cell == null) {
			Debug.LogError("target is null !");
			return;
		}
		toSpawn.toCell(cell);
	}
}
