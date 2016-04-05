using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Civilization", fileName = "New Civilization")]
public class CiviDat : ScriptableObject {
	public int idCivi;
	public CiviConditionDat[] conditions;
	public float[] prop;
	public string prefabPath;


	public bool isSpawnable (Cell host) {
		foreach (CiviConditionDat condition in conditions) {
			if (!condition.isVerified(host)) {
				return false;
			}
		}

		return true;
	}
}
