using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Boomlagoon.JSON;

public class MainController {
	
	public static Spell loadSpell (int spellID) {
		JSONObject json = JSONObject.Parse(getJsonFromFile("spells.json"));
		json = json.GetObject(spellID.ToString());
		int id = (int)json.GetNumber("Id");
		string spellName = json.GetString("Name");
		JSONArray jOrders = json.GetArray("Orders");
		Order [] orders = new Order[jOrders.Length];
		for (int i = 0; i < orders.Length; i++) {
			orders[i] = loadOrder(jOrders[i].Str);
		}
		return new Spell(id, spellName, orders);
	}

	public static GodData loadGod (int godID) {
		JSONObject json = JSONObject.Parse(getJsonFromFile("gods.json"));
		json = json.GetObject(godID.ToString());
		int id = (int) json.GetNumber("Id");
		string godName = json.GetString("Name");
		string title = json.GetString("Title");
		JSONArray jSpells = json.GetArray("Spells");
		Spell [] spells = new Spell[jSpells.Length];
		for (int i = 0; i < spells.Length; i++) {
			spells[i] = loadSpell((int)jSpells[i].Number);
		}
		Sprite illu = Resources.Load<Sprite>("Images/" + json.GetString("Illu"));
		return new GodData(id, godName, title, spells, illu);
	}

	public static GameResource loadGameResources (int resourceId) {
		JSONObject json = JSONObject.Parse(getJsonFromFile("gameResources.json"));
		json = json.GetObject(resourceId.ToString());

		int id = (int)json.GetNumber("Id");
		string resourceName = json.GetString("Name");
		int duration = (int)json.GetNumber("Duration");
		string resourceType = json.GetString("Type");
		string resourceImage = json.GetString("Image");

		JSONObject valuePerTick = json.GetObject ("ValuePerTick");
		float VptNeeds =(float)valuePerTick.GetNumber("Needs");
		float VptCulture = (float)valuePerTick.GetNumber("Culture");
		float VptScience = (float)valuePerTick.GetNumber("Science");
		float VptSocials = (float)valuePerTick.GetNumber("Socials");

		if (resourceType == ResourceType.FOOD.ToString()) {
			return new FoodResource (id, resourceName, resourceImage, duration, VptNeeds, VptCulture, VptScience, VptSocials);
		} else {
			return new WealthResource (id, resourceName, resourceImage, duration, VptNeeds, VptCulture, VptScience, VptSocials);
		}
	}

	public static Order loadOrder (string order) {
		string[] splitOrder = order.Split(';');
		switch (splitOrder[0]) {
		case "STATS" :
			Stat stat = Stat.stNb;
			switch (splitOrder[1]) {
			case "Needs":
				stat = Stat.stNeeds;
				break;
			case "Culture":
				stat = Stat.stCulture;
				break;
			case "Socials":
				stat = Stat.stSocials;
				break;
			case "Science":
				stat = Stat.stScience;
				break;
			}
			return new OrderStat (stat, float.Parse(splitOrder[2]));
			break;
		case "SPAWN":
			return new OrderSpawn(loadGameResources(int.Parse(splitOrder[2])));
			break;
		default:
			Debug.LogError("Order type not implemented !");
			break;
		}

		return null;
	}

	public static string getJsonFromFile (string path) {
		path = path.Replace(".json", "");
		TextAsset json = Resources.Load<TextAsset>("Model/" + path);
		return json.text;
	}

}
