using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : EntityObject
{
	public float health = 100;

	void Awake()
	{
		objectType = ObjectType.Tree;
	}

	public override EntityObjectData Save()
	{
		return new TreeData(transform.position.x, transform.position.y);
	}

	public override void Load(EntityObjectData entityObjectData)
	{
		transform.position = new Vector3(entityObjectData.x, entityObjectData.y, 0);
	}
}
