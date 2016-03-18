﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public float demons;
	public Civilization civi;

	private static GameManager instance;
	public GuiManager guiM;

	private float timer;
	public float tickTime;

	// Use this for initialization
	void Start () {
		instance = this;
		civi = new Civilization();
		timer=0;
	}
	
	// Update is called once per frame
	void Update () {
		timer+=Time.deltaTime;
		if(timer>=tickTime){
			timer=0;
			resolveTick();
		}
	}

	public static GameManager getInstance(){
		return instance;
	}

	private void resolveTick () {
		civi.resolveTick();

		if (demons >= 1.0) {
			Application.LoadLevelAsync("GameOver");
		}
	}
}
