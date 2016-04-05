using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	Vector2 position;
	Civilization owner;

	FoodResourceDat food;
	int foodDuration;
	WealthResourceDat wealth;
	int wealthDuration;

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
					new Civilization(civi, this);
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
				foodDuration = value.duration;
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
				wealthDuration = value.duration;
				wealthSprite.SetActive(true);
			}
			checkCiviCondition();
		}
	}

	public int FoodDuration {
		get {
			return this.foodDuration;
		}
		set {
			foodDuration = value;
		}
	}

	public int WealthDuration {
		get {
			return this.wealthDuration;
		}
		set {
			wealthDuration = value;
		}
	}
}
