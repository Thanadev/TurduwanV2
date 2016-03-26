using UnityEngine;
using System.Collections;

public abstract class CiviConditionDat : ScriptableObject {
	public abstract bool isVerified (Cell host);
}
