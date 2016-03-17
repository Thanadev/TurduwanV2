using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiManager : MonoBehaviour {

	public Text needs, culture, science, socials, demons;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onSpellTriggerPressed () {
		MainController.loadSpell(0).onSpellActivated();
	}
}
