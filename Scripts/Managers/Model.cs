using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Model : MonoBehaviour {

	public string modelPath;

	public static List<GodDat> gods;
	public static List<SpellDat> spells;
	public static List<GameResourceDat> resources;
	public static List<CiviDat> civis;

	// Use this for initialization
	void Awake () {
		gods = new List<GodDat>();
		spells = new List<SpellDat>();
		resources = new List<GameResourceDat>();
		civis = new List<CiviDat>();

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
			} else if (loaded is CiviDat) {
				civis.Add(loaded as CiviDat);
			}
		}
	}

	public static GodDat getGod (int id) {
		foreach (GodDat god in gods) {
			if (god.id == id) {
				return god;
			}
		}

		return null;
	}

	public static GameResourceDat getResource (int id) {
		foreach (GameResourceDat resource in resources) {
			if (resource.id == id) {
				return resource;
			}
		}

		return null;
	}

	public static SpellDat getSpell (int id) {
		foreach (SpellDat spell in spells) {
			if (spell.id == id) {
				return spell;
			}
		}

		return null;
	}
}
