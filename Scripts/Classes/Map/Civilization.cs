using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Civilization {

	protected int idCivi;
	protected float[] prop;
	protected List<GameObject> linkedObjects;

	public Civilization (CiviDat model, Cell host)
	{
		linkedObjects = new List<GameObject>();
		prop = new float[(int)Stat.stNb];
		for (int i = 0; i < prop.Length; i++) {
			prop[i] = model.prop[i];
		}

		host.Owner = this;
		GameManager.getInstance().spawnedCivis.Add(this);

		GameObject tmp = Resources.Load<GameObject>("Prefabs/Civis/" + model.prefabPath + "/Village");
		tmp = GameObject.Instantiate(tmp, host.transform.position, Quaternion.identity) as GameObject;
		linkedObjects.Add(tmp);
	}

	public void resolveTick () {
		for (int i = 0; i < (int) Stat.stNb; i++) {
			modifyStat(i, -0.01f);
			if (prop[i] > 1.25f || prop[i] < 0.75f) {
				GameManager.getInstance().demons += 0.02f;
				GameManager.getInstance().guiM.demons.text = ((int)(GameManager.getInstance().demons * 100)).ToString() + "%";
			}
		}
	}

	public void modifyStat (int stat, float modifier) {
		prop[stat] = limitStat(prop[stat] + modifier);
		GameManager.getInstance().guiM.properties[stat].text = ((int)(prop[stat] * 100)).ToString() + "%";
	}

	private float limitStat (float stat) {
		if(stat>2) return 2;
		if(stat<0) return 0;
		return stat;
	}

	public void destroyCivilization () {
		foreach (GameObject obj in linkedObjects) {
			GameObject.Destroy(obj);
		}
	}

	public int IdCivi {
		get {
			return this.idCivi;
		}
		set {
			idCivi = value;
		}
	}

	public float[] Prop {
		get {
			return this.prop;
		}
		set {
			prop = value;
		}
	}

	public List<GameObject> LinkedObjects {
		get {
			return this.linkedObjects;
		}
		set {
			linkedObjects = value;
		}
	}
}
