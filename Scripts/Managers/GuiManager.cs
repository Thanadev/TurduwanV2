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
	public Text gTimer;
	public GameObject godPanel;
	public Text faithGauge;
	public Button[] spellButtons;

	// Use this for initialization
	void Start () {
		demons.text = "0%";
		propPanel.SetActive(false);
		actualizeGodPanel();
	}

	void Update () {
		if (gTimer != null) {
			gTimer.text = ((int) (GameManager.gTimer/60)).ToString() + "min " + ((int) (GameManager.gTimer%60)).ToString() + "sec";
		}
	}

	public void onSpellTriggerPressed (int index) {
		for (int i = 0; i < spellButtons.Length; i++) {
			spellButtons[i].image.color = Color.white;
		}
		if (index > -1 && index < spellButtons.Length 
			&& inputManager.SelectedGod != null && index < Model.getGod(inputManager.SelectedGod.id).spells.Length)
		{
			spellButtons[index].image.color = activatedColor;
		}
		inputManager.onSpellTrigger(index);
	}

	public void resolveTick () {
		actualizeGodPanel();
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
		} else {
			propPanel.SetActive(false);
		}
	}

	public void actualizeGodPanel () {
		if (inputManager.SelectedGod != null) {
			for (int i = 0; i < spellButtons.Length; i++) {
				if (i < Model.getGod(inputManager.SelectedGod.id).spells.Length) {
					spellButtons[i].gameObject.SetActive(true);
				} else {
					spellButtons[i].gameObject.SetActive(false);
				}
			}
			if (godPanel != null) {
				godPanel.SetActive(true);
			}
			if (faithGauge != null) {
				faithGauge.text = ((int)(inputManager.SelectedGod.Faith * 100)).ToString() + "%";
			}
		} else {
			for (int i = 0; i < spellButtons.Length; i++) {
				spellButtons[i].gameObject.SetActive(false);
			}
			if (godPanel != null) {
				godPanel.SetActive(false);
			}
		}
	}
}
