using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityObjectData
{
	public float x;
	public float y;

	public ObjectType objectType;

	public EntityObjectData(float _x, float _y)
	{
		x = _x;
		y = _y;
	}
}
