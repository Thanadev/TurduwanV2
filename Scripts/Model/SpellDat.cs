using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Spell", fileName="New Spell")]
public class SpellDat : ScriptableObject {
	public string name;
	public Order[] orders;
}
