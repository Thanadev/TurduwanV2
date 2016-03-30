using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

	public int id;
	protected float faith;
	SpriteRenderer sR;

	// Use this for initialization
	void Start () {
		sR = GetComponent<SpriteRenderer>();
		sR.sprite = Model.getGod(id).illu;
		faith = Model.gameSettings.faithStartValue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void resolveTick () {
		faith += Model.gameSettings.faithDecreaseRate;
		if (faith <= Model.gameSettings.faithLowLimit) {
			Debug.Log("Trigger random action");
		}
	}

	public float Faith {
		get {
			return this.faith;
		}
		set {
			faith = value;
		}
	}
}
