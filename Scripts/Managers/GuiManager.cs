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
		propPanel.SetActive(false);
	}

	public void onSpellTriggerPressed (int index) {
		foreach (Button button in spellButtons) {
			button.image.color = Color.white;
		}
		if (index > -1 && index < spellButtons.Length 
			&& inputManager.SelectedGod != null && index < Model.getGod(inputManager.SelectedGod.id).spells.Length)
		{
			spellButtons[index].image.color = activatedColor;
		}
		inputManager.onSpellTrigger(index);
	}

	public void resolveTick () {
		actualizeLocalInfo();
	}

	public void actualizeLocalInfo () {
		if (inputManager.SelectedCell != null) {
			if (inputManager.SelectedCell.Owner != null) {
				propPanel.SetActive(true);
				for (int i = 0; i < (int) Stat.stNb; i++) {
					properties[i].text = ((int)(inputManager.SelectedCell.Owner.Prop[i] * 100)).ToString() + "%";
				}
			} else {
				propPanel.SetActive(false);
			}
		}
	}
}
