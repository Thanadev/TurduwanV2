using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//Jauges
	public float needs;
	public float culture;
	public float socials;
	public float science;
	public float demons;

	public GuiManager guiM;

	// Use this for initialization
	void Start () {
		guiM.needs.text = needs.ToString();
		guiM.culture.text = culture.ToString();
		guiM.science.text = science.ToString();
		guiM.socials.text = socials.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static GameManager getInstance(){
		return GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}

	public static void modifyStat(string stat, float modifier){
		GameManager instance = getInstance();
		switch (stat) {
		case "Needs" :
			instance.needs += modifier;
			instance.guiM.needs.text = instance.needs.ToString();
			break;
		case "Culture" :
			instance.culture += modifier;
			instance.guiM.culture.text = instance.culture.ToString();
			break;
		case "Science" :
			instance.science += modifier;
			instance.guiM.science.text = instance.science.ToString();
			break;
		case "Socials" :
			instance.socials += modifier;
			instance.guiM.socials.text = instance.socials.ToString();
			break;
		}
	}
}
