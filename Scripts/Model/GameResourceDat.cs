using UnityEngine;
using System.Collections;

public abstract class GameResourceDat : ScriptableObject {
	public int id;
	public new string name;
	public float[] valuePerTick;
	public int duration;

	public abstract void toCell (Cell target);
	public virtual void consumeSelf (Civilization owner, Cell cell) {
		for (int i = 0; i < (int) Stat.stNb; i++) {
			owner.modifyStat(i, valuePerTick[i]);
		}
	}
}
