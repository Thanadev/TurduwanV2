using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public GuiManager guiM;
	public bool debugMode;
	public float tickTime;

	private float demons;
	private float timer;
	public static float gTimer;

	private static GameManager instance;

	public List<Civilization> spawnedCivis;

	void Awake () {
		instance = this;
		spawnedCivis = new List<Civilization>();
	}

	// Use this for initialization
	void Start () {
		timer = 0;
		gTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (spawnedCivis.Count > 0) {
			gTimer += Time.deltaTime;
		}
		if(timer >= tickTime){
			timer = 0;
			resolveTick();
		}
	}

	public static GameManager getInstance(){
		return instance;
	}

	private void resolveTick () {
		foreach (Civilization civi in spawnedCivis) {
			civi.resolveTick();
		}

		foreach (GameObject god in GameObject.FindGameObjectsWithTag("God")) {
			god.GetComponent<GodButton>().resolveTick();
		}

		guiM.resolveTick();

		if (demons >= 1.0) {
			Application.LoadLevelAsync("Levels/GameOver");
		}
	}

	public float Demons {
		get {
			return this.demons;
		}
		set {
			demons = value;
			guiM.demons.text = ((int)(demons * 100)).ToString() + "%";
		}
	}
}
