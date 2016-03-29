using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Unique/Game Settings")]
public class GameSettings : ScriptableObject
{
	public float demonProgressionRate;
	public float gaugeMaxValue = 2.0f;
	public float gaugeMinValue = 0.0f;
	public float statHighLimit;
	public float statLowLimit;
	public float[] statDecreaseRate;
}
