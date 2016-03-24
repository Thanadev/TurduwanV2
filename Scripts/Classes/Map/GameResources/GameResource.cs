using UnityEngine;
using System.Collections;

public abstract class GameResource {

	protected int id;
	protected string resourceName;
	protected string resourceImage;
	protected int duration;
	protected float[] ValuePerTick;

	public GameResource(int id, string resourceName, string resourceImage, int duration, float VptNeeds, float VptCulture, float VptScience, float VptSocials)
	{
		this.ValuePerTick = new float[(int) Stat.stNb];
		this.id = id;
		this.resourceName = resourceName;
		this.duration = duration;
		this.ValuePerTick [(int) Stat.stNeeds] = VptNeeds;
		this.ValuePerTick [(int) Stat.stCulture] = VptCulture;
		this.ValuePerTick [(int) Stat.stScience] = VptScience;
		this.ValuePerTick [(int) Stat.stSocials] = VptSocials;
	}

	public abstract void toCell (Cell target);

	public int Id {
		get {
			return this.id;
		}
		set {
			id = value;
		}
	}

	public string ResourceName {
		get {
			return this.resourceName;
		}
		set {
			resourceName = value;
		}
	}

	public string ResourceImage {
		get {
			return this.resourceImage;
		}
		set {
			resourceImage = value;
		}
	}

	public int Duration {
		get {
			return this.duration;
		}
		set {
			duration = value;
		}
	}
}
