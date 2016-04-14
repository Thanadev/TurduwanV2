using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiManager : MonoBehaviour {

	public Color activatedColor;

	public InputManager inputManager;
	public GameObject propPanel;
	public Slider[] properties;
	public Text demons;
	public Text gTimer;
	public GameObject godPanel;
	public Image godIllu;
	public Text godName;
	public Text godTitle;
	public Slider faithGauge;
	public Button[] spellButtons;
	public GameObject godButtonList;
	public List<GodButton> godButtons;
	public Text notificationZone;

	// Use this for initialization
	void Start () {
		demons.text = "0%";
		//populateGodList();
		propPanel.SetActive(false);
		actualizeGodPanel();

	}

	void Update () {
		if (gTimer != null) {
			gTimer.text = ((int) (GameManager.gTimer/60)).ToString() + "min " + ((int) (GameManager.gTimer %60)).ToString() + "sec";
		}
	}

	public void onSpellActivated (string notification) {
		if (notificationZone != null) {
			notificationZone.text = notification;
		} else {
			Debug.Log(notification);
		}
	}

	public void onSpellTriggerPressed (int index) {
		for (int i = 0; i < spellButtons.Length; i++) {
			spellButtons[i].image.color = Color.white;
		}
		if (index <= -1) {
			return;
		}

		if (index < spellButtons.Length 
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

	public void onGodButtonPressed (int id) {
		inputManager.onGodSelected(Model.getGod(id));
	}

	public void actualizeLocalInfo () {
		if (inputManager.SelectedCell != null) {
			if (inputManager.SelectedCell.Owner != null) {
				propPanel.SetActive(true);
				for (int i = 0; i < (int) Stat.stNb; i++) {
					properties[i].value = inputManager.SelectedCell.Owner.Prop[i];
				}
			} else {
				propPanel.SetActive(false);
			}
		} else {
			propPanel.SetActive(false);
		}
	}

	public void actualizeGodPanel () {
		GodDat god = inputManager.SelectedGod;
		if (god != null) {
			if (godIllu != null && god.illu != null) {
				godIllu.sprite = god.illu;
			}

			if (godName != null) {
				godName.text = god.godName;
			}

			if (godTitle != null) {
				godTitle.text = god.godTitle;
			}

			for (int i = 0; i < spellButtons.Length; i++) {
				if (i < god.spells.Length) {
					spellButtons[i].gameObject.SetActive(true);
				} else {
					spellButtons[i].gameObject.SetActive(false);
				}
			}
			if (godPanel != null) {
				godPanel.SetActive(true);
			}
			if (faithGauge != null) {
				faithGauge.value = getGodButton(god.id).Faith;
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

	protected GodButton getGodButton (int id) {
		foreach (GodButton button in godButtons) {
			if (button.id == id) {
				return button;
			}
		}

		Debug.Log("No button found for id " + id);
		return null;
	}

	public void populateGodList () {
		GameObject button = Resources.Load<GameObject>("Prefabs/Gui/GodButton");
		foreach (GodDat god in Model.gods) {
			button.GetComponent<GodButton>().id = god.id;
			button = Instantiate(button);
			button.transform.SetParent(godButtonList.transform);
			button.SetActive(true);
		}
	}
}
