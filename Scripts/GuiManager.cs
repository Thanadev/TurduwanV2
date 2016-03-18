using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiManager : MonoBehaviour {

	public InputManager inputManager;
	public Text[] properties;
	public Text demons;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onSpellTriggerPressed (int index) {
		inputManager.onSpellTrigger(index);
	}
}
