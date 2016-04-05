using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Spell", fileName="New Spell")]
public class SpellDat : ScriptableObject {
	public int id;
	public new string name;
	public Order[] orders;

	public void onSpellActivated (RaycastHit target) {
		Debug.Log(name + " has been triggered !");
		foreach (Order order in orders) {
			order.execute(target);
		}
	}
}
