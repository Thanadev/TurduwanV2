using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Model : MonoBehaviour {

	public string modelPath;

	public static List<GodDat> gods;
	public static List<SpellDat> spells;
	public static List<GameResourceDat> resources;

	// Use this for initialization
	void Start () {
		gods = new List<GodDat>();
		spells = new List<SpellDat>();
		resources = new List<GameResourceDat>();

		loadModel();
	}

	private void loadModel () {
		Object[] assets = Resources.LoadAll(modelPath);

		foreach (Object loaded in assets) {
			if (loaded is GameResourceDat) {
				resources.Add(loaded as GameResourceDat);
			} else if (loaded is GodDat) {
				gods.Add(loaded as GodDat);
			} else if (loaded is SpellDat) {
				spells.Add(loaded as SpellDat);
			}
		}
	}
}
