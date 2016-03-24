using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	Vector2 position;
	Civilization owner;

	FoodResource food;
	WealthResource wealth;
	Civilization pop;

	public GameObject foodSprite;
	public GameObject wealthSprite;

	// Use this for initialization
	void Start () {
		foodSprite.SetActive(false);
		wealthSprite.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected void checkCiviCondition () {
		foreach (Civilization civi in GameManager.civis) {
			if (civi.isSpawnable(this)) {
				this.owner = civi;
				return;
			} else {
				Debug.Log("Nothing to spawn");
			}
		}
	}

	public Vector2 Position {
		get {
			return this.position;
		}
		set {
			position = value;
		}
	}

	public Civilization Owner {
		get {
			return this.owner;
		}
		set {
			owner = value;
		}
	}

	public FoodResource Food {
		get {
			return this.food;
		}
		set {
			food = value;
			if (value == null) {
				foodSprite.SetActive(false);
			} else {
				foodSprite.SetActive(true);
			}
			checkCiviCondition();
		}
	}

	public WealthResource Wealth {
		get {
			return this.wealth;
		}
		set {
			wealth = value;
			if (value == null) {
				wealthSprite.SetActive(false);
			} else {
				wealthSprite.SetActive(true);
			}
			checkCiviCondition();
		}
	}
}
