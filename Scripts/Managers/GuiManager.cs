using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiManager : MonoBehaviour {

	public Color activatedColor;

	public InputManager inputManager;
	public GameObject propPanel;
	public Text[] properties;
	public Text demons;
	public Button[] spellButtons;

	// Use this for initialization
	void Start () {
		demons.text = "0%";
	}

	public void onSpellTriggerPressed (int index) {
		foreach (Button button in spellButtons) {
			button.image.color = Color.white;
		}
		if (index < spellButtons.Length) {
			spellButtons[index].image.color = activatedColor;
		}
		inputManager.onSpellTrigger(index);
	}
}
