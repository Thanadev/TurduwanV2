using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	Vector2 position;
	Civilization owner;

	FoodResourceDat food;
	WealthResourceDat wealth;

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
		if (this.owner == null) {
			foreach (CiviDat civi in Model.civis) {
				if (civi.isSpawnable(this)) {
					this.owner = new Civilization(civi);
					return;
				} else {
					Debug.Log("Nothing to spawn");
				}
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

	public FoodResourceDat Food {
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

	public WealthResourceDat Wealth {
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
