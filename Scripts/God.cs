using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

	public int id;
	SpriteRenderer sR;

	// Use this for initialization
	void Start () {
		sR = GetComponent<SpriteRenderer>();
		sR.sprite = Model.getGod(id).illu;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
