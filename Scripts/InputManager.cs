using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	God selectedGod;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0)){
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit)){
				if(hit.collider.CompareTag("God")){
					selectedGod=hit.collider.GetComponent<God>();
				}
			}
		}
	}

	public void onSpellTrigger(int index){
		selectedGod.triggerSpell(index);
	}
}
