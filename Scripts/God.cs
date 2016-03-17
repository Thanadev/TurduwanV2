using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

	protected GodData goddata;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GodData Goddata {
		get {
			return this.goddata;
		}
		set {
			goddata = value;
		}
	}
}
