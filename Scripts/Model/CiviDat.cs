using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Civilization", fileName = "New Civilization")]
public class CiviDat : ScriptableObject {
	public int idCivi;
	public CiviConditionDat[] conditions;
	public float[] prop;

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

	public bool isSpawnable (Cell host) {
		foreach (CiviConditionDat condition in conditions) {
			if (!condition.isVerified(host)) {
				return false;
			}
		}

		return true;
	}
}
