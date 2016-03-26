using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

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
					selectedGod = hit.collider.GetComponent<God>();
				} else if (hit.collider.CompareTag("MapCell")) {
					if (selectedSpell == null) {
						selectedCell = hit.collider.GetComponent<Cell>();
					} else {
						selectedSpell.onSpellActivated(hit);
					}
				}
			}
		} else if (Input.GetMouseButtonUp(1)) {
			selectedSpell = null;
		}
	}

	public void onSpellTrigger(int index){
		if (selectedGod != null) {
			GodDat god = Model.getGod(selectedGod.id);
			if (god.spells.Length > index) {
				selectedSpell = god.spells[index];
			}
		}
	}
}
