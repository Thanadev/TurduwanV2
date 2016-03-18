using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiManager : MonoBehaviour {

	Color activatedColor;

	public InputManager inputManager;
	public Text[] properties;
	public Text demons;

	// Use this for initialization
	void Start () {
		activatedColor = new Color(246, 255, 86);
		demons.text = "0%";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onSpellTriggerPressed (int index) {
		inputManager.onSpellTrigger(index);
	}
}
