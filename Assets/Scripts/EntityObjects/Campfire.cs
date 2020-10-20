using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : EntityObject
{
	void Awake()
	{
		objectType = ObjectType.Campfire;
	}

	public override EntityObjectData Save()
	{
		return new CampfireData(transform.position.x, transform.position.y);
	}

	public override void Load(EntityObjectData entityObjectData)
	{
		transform.position = new Vector3(entityObjectData.x, entityObjectData.y, 0);
	}
}
