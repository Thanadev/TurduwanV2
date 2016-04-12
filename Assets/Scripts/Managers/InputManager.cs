using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour {

	public GuiManager guiM;
	public bool debugMode;
	public GameObject cameraPivot;

	GodDat selectedGod;
	Cell selectedCell;
	SpellDat selectedSpell;
	GameObject selectedMouseEffect;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit)){
				if (hit.collider.CompareTag("MapCell")) {
					if (selectedSpell == null) {
						onCellSelected(hit.collider.GetComponent<Cell>());
					} else {
						selectedSpell.onSpellActivated(hit);
						deselectSpell();
					}
				}
			}
		} else if (Input.GetMouseButtonUp(1)) {
			
			deselectSpell();
		
		} else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {

			Vector3 tmp = new Vector3();
			tmp.x = Input.GetAxisRaw("Horizontal");
			tmp.z = Input.GetAxisRaw("Vertical");
			tmp = cameraPivot.transform.TransformDirection(tmp);
			cameraPivot.GetComponent<Rigidbody>().velocity = tmp * 20;

		} else if (Input.GetMouseButton(2)) {

			Vector3 tmp = cameraPivot.transform.rotation.eulerAngles;
			tmp.y += Input.GetAxisRaw("Mouse X");
			cameraPivot.transform.rotation = Quaternion.Euler(tmp);

		} else if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && ((Input.GetAxis("Mouse ScrollWheel") > 0 && GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize > 2) || (Input.GetAxis("Mouse ScrollWheel") < 0 && GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize < 100))) {

			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 5;
		}
	}

	public void onSpellTrigger (int index) {
		if (index > -1 && selectedGod != null) {
			if (selectedGod.spells.Length > index) {
				selectedSpell = selectedGod.spells[index];
				onMouseEffectSelected();
			} else {
				deselectSpell();
			}
		} else {
			deselectSpell();
		}
	}


	public void onGodSelected (GodDat god) {
		selectedGod = god;
		deselectSpell();
		guiM.actualizeGodPanel();
		for (int i = 0; i < selectedGod.spells.Length; i++) {
			guiM.spellButtons[i].GetComponentInChildren<Text>().text = selectedGod.spells[i].name;
		}
	}

	public void onCellSelected (Cell cell) {
		selectedCell = cell;
		guiM.actualizeLocalInfo();
	}

	private void deselectSpell () {
		selectedSpell = null;
		guiM.onSpellTriggerPressed(-1);
		onMouseEffectSelected();
	}

	private void onMouseEffectSelected () {
		if (selectedMouseEffect != null) {
			Destroy(selectedMouseEffect);
			if (selectedSpell == null) {
				return;
			}
		}
		if (selectedSpell != null) {
			selectedMouseEffect = selectedSpell.mouseEffect;
		}
		if (selectedMouseEffect != null) {
			selectedMouseEffect = GameObject.Instantiate(selectedMouseEffect, Vector3.zero, selectedMouseEffect.transform.rotation) as GameObject;
		}
	}


	public GodDat SelectedGod {
		get {
			return this.selectedGod;
		}
	}

	public Cell SelectedCell {
		get {
			return this.selectedCell;
		}
	}

	public SpellDat SelectedSpell {
		get {
			return this.selectedSpell;
		}
	}
}
