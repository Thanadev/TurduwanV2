using UnityEngine;
using System.Collections;

public class WealthResource : GameResource {
	public WealthResource (int id, string resourceName, string resourceImage, int duration, float VptNeeds, float VptCulture, float VptScience, float VptSocials) : base (id, resourceName, resourceImage, duration, VptNeeds, VptCulture, VptScience, VptSocials)
	{
	}

	public override void toCell (Cell target)
	{
		target.Wealth = this;
	}
}
