using UnityEngine;
using System.Collections;

public class FollowMouseRay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray,out hit)){
			transform.position = hit.point;
		}
	}
}
