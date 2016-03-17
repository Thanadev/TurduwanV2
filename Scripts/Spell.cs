using UnityEngine;
using System.Collections;

public class Spell {
	protected int id;
	protected string spellName;
	protected Order [] orders;

	public Spell (int id) : this (MainController.loadSpell(id)) {
	}

	public Spell (Spell other) {
		this.id = other.id;
		this.spellName = other.spellName;
		this.orders = other.orders;
	}

	public Spell (int id, string spellName, Order[] orders)
	{
		this.id = id;
		this.spellName = spellName;
		this.orders = orders;
	}

	public void onSpellActivated () {
		foreach (Order order in orders) {
			order.execute();
		}
	}
}
