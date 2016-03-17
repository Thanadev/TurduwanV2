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

	public static Order loadOrder (string order) {
		string[] splitOrder = order.Split(';');
		switch (splitOrder[0]) {
		case "STATS" :
			return new OrderStat (splitOrder[1], float.Parse(splitOrder[2]));
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
