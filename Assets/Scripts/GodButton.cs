using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GodButton : MonoBehaviour {

	public int id;
	public Image godIllu;
	public Text godName;
	public Slider godFaith;

	private float faith;
	private Button buttonScript;

	public void initButton () {
		GodDat god = Model.getGod(id);
		godIllu.sprite =  god.listIllu;
		godName.text = god.godName;
		buttonScript = GetComponent<Button>();
		buttonScript.onClick.AddListener(() => GameManager.getInstance().guiM.onGodButtonPressed(id));
	}

	public void resolveTick () {
		faith += Model.gameSettings.faithDecreaseRate;
		if (faith <= Model.gameSettings.faithLowLimit) {
			Debug.Log("Trigger random action");
		}
		if (faith <= Model.gameSettings.gaugeMinValue) {
			faith = Model.gameSettings.gaugeMinValue;
		}

		godFaith.value = faith;
	}

	// Use this for initialization
	void Start () {
		faith = Model.gameSettings.faithStartValue;
		initButton();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public float Faith {
		get {
			return this.faith;
		}
	}
}
