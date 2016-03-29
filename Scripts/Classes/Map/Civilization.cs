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
			modifyStat(i, Model.gameSettings.statDecreaseRate[i]);
			if (prop[i] > Model.gameSettings.statHighLimit || prop[i] < Model.gameSettings.statLowLimit) {
				GameManager.getInstance().Demons += Model.gameSettings.demonProgressionRate;
			}
		}
	}

	public void modifyStat (int stat, float modifier) {
		prop[stat] = limitStat(prop[stat] + modifier);
	}

	private float limitStat (float stat) {
		if(stat > Model.gameSettings.gaugeMaxValue) return Model.gameSettings.gaugeMaxValue;
		if(stat < Model.gameSettings.gaugeMinValue) return Model.gameSettings.gaugeMinValue;
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
