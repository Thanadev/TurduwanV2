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
	public float[] statDecreaseRate = {-0.01f, -0.01f, -0.01f, -0.01f};
	public float faithStartValue = 1.0f;
	public float faithDecreaseRate = -0.01f;
	public float faithLowLimit = 0.1f;
	public float spellClickEffectLifetime = 15f;
}
