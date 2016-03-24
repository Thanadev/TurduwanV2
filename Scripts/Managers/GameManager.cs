using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public float demons;

	private static GameManager instance;
	public GuiManager guiM;

	private float timer;
	public float tickTime;

	public static List<GodData> gods;
	public static List<Civilization> civis;
	public static List<GameResource> gameResources;

	void Awake () {
		instance = this;
		gods = new List<GodData>();
		civis = new List<Civilization>();

		GameObject[] g = GameObject.FindGameObjectsWithTag("God");
		foreach (GameObject god in g) {
			GodData toAdd = MainController.loadGod(god.GetComponent<God>().id);
			gods.Add(toAdd);
		}

		civis = MainController.loadAllCivis();
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

	public static GodData getGod (int id) {
		foreach (GodData god in gods) {
			if (god.Id == id) {
				return god;
			}
		}

		return null;
	}
}
