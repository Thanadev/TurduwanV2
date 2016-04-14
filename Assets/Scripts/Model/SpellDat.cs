using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Spell", fileName="New Spell")]
public class SpellDat : ScriptableObject {
	public int id;
	public new string name;
	public Sprite icon;
	public Order[] orders;
	public GameObject mouseEffect;
	public GameObject clickEffect;
	public string notificationSentence;

	public void onSpellActivated (RaycastHit target) {
		Debug.Log(name + " has been triggered !");
		if (clickEffect != null) {
			GameObject tmp = GameObject.Instantiate(clickEffect, target.transform.position, clickEffect.transform.rotation) as GameObject;
			Destroy(tmp, Model.gameSettings.spellClickEffectLifetime);
		}

		if (notificationSentence.Length > 0) {
			GameManager.getInstance().guiM.onSpellActivated(notificationSentence);
		}

		foreach (Order order in orders) {
			order.execute(target);
		}
	}
}
