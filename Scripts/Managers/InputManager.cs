﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public GuiManager guiM;
	public GameObject cameraPivot;

	God selectedGod;
	Cell selectedCell;
	SpellDat selectedSpell;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit)){
				if(hit.collider.CompareTag("God")){
					onGodSelected(hit.collider.GetComponent<God>());
				} else if (hit.collider.CompareTag("MapCell")) {
					if (selectedSpell == null) {
						onCellSelected(hit.collider.GetComponent<Cell>());
					} else {
						selectedSpell.onSpellActivated(hit);
						selectedSpell = null;
						guiM.onSpellTriggerPressed(-1);
					}
				}
			}
		} else if (Input.GetMouseButtonUp(1)) {
			selectedSpell = null;
		} else if (Input.GetMouseButton(2) && Input.GetKey(KeyCode.LeftShift)) {
			Vector3 tmp = new Vector3();
			tmp.x = -Input.GetAxisRaw("Mouse X");
			tmp.z = -Input.GetAxisRaw("Mouse Y");
			tmp = cameraPivot.transform.TransformDirection(tmp);
			cameraPivot.GetComponent<Rigidbody>().velocity = tmp * 50;

		} else if (Input.GetMouseButton(2)) {

			Vector3 tmp = cameraPivot.transform.rotation.eulerAngles;
			tmp.y += Input.GetAxisRaw("Mouse X");
			cameraPivot.transform.rotation = Quaternion.Euler(tmp);

		} else if ((Input.GetAxis("Mouse ScrollWheel") > 0 && GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize > 2) || (Input.GetAxis("Mouse ScrollWheel") < 0 && GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize < 100)) {
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 5;
		}
	}

	public void onSpellTrigger(int index){
		if (index > -1 && selectedGod != null) {
			GodDat god = Model.getGod(selectedGod.id);
			if (god.spells.Length > index) {
				selectedSpell = god.spells[index];
			} else {
				selectedSpell = null;
			}
		} else {
			selectedSpell = null;
		}
	}


	public void onGodSelected (God god) {
		selectedGod = god;
	}

	public void onCellSelected (Cell cell) {
		selectedCell = cell;
		guiM.actualizeLocalInfo();
	}


	public God SelectedGod {
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
