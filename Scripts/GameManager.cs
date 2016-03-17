using UnityEngine;
using System.Collections;

public enum Stat {NEEDS, CULTURE, SOCIALS, SCIENCE};

public class GameManager : MonoBehaviour {
	//Jauges
	public float needs;
	public float culture;
	public float socials;
	public float science;
	public float demons;

	// Use this for initialization
	void Start () {
		MainController.loadSpell(0).onSpellActivated();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static GameManager getInstance(){
		return GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}

	public static void modifyStat(string stat, float modifier){
		switch (stat) {
		case "Needs" :
			GameManager.getInstance().needs += modifier;
			break;
		case "Culture" :
			GameManager.getInstance().culture += modifier;
			break;
		case "Science" :
			GameManager.getInstance().science += modifier;
			break;
		case "Socials" :
			GameManager.getInstance().socials += modifier;
			break;
		}
	}
}
