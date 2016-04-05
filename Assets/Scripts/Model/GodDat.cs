using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/God", fileName = "New God")]
public class GodDat : ScriptableObject {
	public int id;
	public string godName, godTitle;
	public SpellDat [] spells;
	public Sprite illu;
}
