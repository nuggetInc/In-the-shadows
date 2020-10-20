using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CampfireData : EntityObjectData
{
	public CampfireData(float _x, float _y) : base(_x, _y)
	{
		objectType = ObjectType.Campfire;
	}
}
