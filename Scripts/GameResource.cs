using UnityEngine;
using System.Collections;

public class GameResource {

	public int id;
	public string resourceName;
	public string resourceType;
	public string resourceImage;
	public int duration;
	public float[] ValuePerTick;

	public GameResource(int id, string resourceName, string resourceType, string resourceImage, int duration, float VptNeeds, float VptCulture, float VptScience, float VptSocials)
	{
		this.id = id;
		this.resourceName = resourceName;
		this.resourceType = resourceType;
		this.duration = duration;
		this.ValuePerTick [(int)Stat.stNeeds] = VptNeeds;
		this.ValuePerTick [(int)Stat.stCulture] = VptCulture;
		this.ValuePerTick [(int)Stat.stScience] = VptScience;
		this.ValuePerTick [(int)Stat.stSocials] = VptSocials;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
