using UnityEngine;
using System.Collections;

public abstract class GameResourceDat : ScriptableObject {
	public int id;
	public string name;
	public float[] valuePerTick;

	public abstract void toCell (Cell target);
}
