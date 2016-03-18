using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

	public int id;
	SpriteRenderer sR;

	// Use this for initialization
	void Start () {
		sR = GetComponent<SpriteRenderer>();
		sR.sprite = GameManager.getGod(id).Illu;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
