using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityObject : MonoBehaviour
{
	public ObjectType objectType;

	public abstract EntityObjectData Save();
	public abstract void Load(EntityObjectData entityObjectData);
}

public enum ObjectType
{
	Tree,
	Campfire
}