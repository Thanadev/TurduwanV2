﻿using UnityEngine;
using System.Collections;

public class GodData {

	protected int id;
	protected string godName;
	protected string title;
	protected Spell[] spells;

	public GodData (int id, string godName, string title, Spell[] spells)
	{
		this.id = id;
		this.godName = godName;
		this.title = title;
		this.spells = spells;
	}
	
	public int Id {
		get {
			return this.id;
		}
		set {
			id = value;
		}
	}

	public string GodName {
		get {
			return this.godName;
		}
		set {
			godName = value;
		}
	}

	public string Title {
		get {
			return this.title;
		}
		set {
			title = value;
		}
	}

	public Spell[] Spells {
		get {
			return this.spells;
		}
		set {
			spells = value;
		}
	}
}