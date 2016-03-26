using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Order/Spawn", fileName = "New Spawn Order")]
public class OrderSpawn : Order {

	public GameResourceDat toSpawn;

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
