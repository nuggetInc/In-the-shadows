using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
	public List<EntityObject> entityObjects { get; private set; }

	public Chunk()
	{
		entityObjects = new List<EntityObject>();
	}

	public void AddEntityObject(EntityObject entityObject)
	{
		entityObjects.Add(entityObject);
	}

	public void RemoveEntityObject(EntityObject entityObject)
	{
		entityObjects.Remove(entityObject);
	}
}
