using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public float demons;

	private static GameManager instance;
	public GuiManager guiM;

	private float timer;
	public float tickTime;


	void Awake () {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= tickTime){
			timer = 0;
			resolveTick();
		}
	}

	public static GameManager getInstance(){
		return instance;
	}

	private void resolveTick () {
		if (demons >= 1.0) {
			Application.LoadLevelAsync("GameOver");
		}
	}
}
