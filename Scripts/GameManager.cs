using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public float demons;
	public Civilization civi;

	private static GameManager instance;
	public GuiManager guiM;

	private float timer;
	public float tickTime;

	public static List<GodData> gods;

	void Awake () {
		instance = this;
		civi = new Civilization();
		gods = new List<GodData>();

		GameObject[] g = GameObject.FindGameObjectsWithTag("God");
		foreach (GameObject god in g) {
			GodData toAdd = MainController.loadGod(god.GetComponent<God>().id);
			gods.Add(toAdd);
		}
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
		civi.resolveTick();

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
