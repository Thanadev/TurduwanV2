using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

	public int id;
	protected GodData godData;

	// Use this for initialization
	void Start () {
		godData = MainController.loadGod(id);
		GetComponent<SpriteRenderer>().sprite = godData.Illu;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GodData GodData {
		get {
			return this.godData;
		}
		set {
			godData = value;
		}
	}

	public void triggerSpell(int index){
		godData.triggerSpell(index);
	}
}
