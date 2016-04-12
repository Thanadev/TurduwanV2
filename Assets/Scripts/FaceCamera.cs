using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {

	Transform cameraPos;

	// Use this for initialization
	void Start () {
		cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(cameraPos.position - transform.position);
	}
}
