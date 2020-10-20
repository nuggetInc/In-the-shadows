using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldData
{
	public string name;
	public EntityObjectData[] entityObjectDatas;

	public WorldData(string _name, List<EntityObject> _entityObjects)
	{
		name = _name;

		entityObjectDatas = new EntityObjectData[_entityObjects.Count];
		for(int i = 0; i < _entityObjects.Count; i++)
		{
			entityObjectDatas[i] = _entityObjects[i].Save();
		}
	}
}
