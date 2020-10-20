using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChunkData
{
	public int x;
	public int y;

	public EntityObjectData[] entityObjectDatas;

	public ChunkData(Vector2Int _position, List<EntityObject> _entityObjects)
	{
		x = _position.x;
		y = _position.y;

		entityObjectDatas = new EntityObjectData[_entityObjects.Count];
		for(int i = 0; i < _entityObjects.Count; i++)
		{
			entityObjectDatas[i] = _entityObjects[i].Save();
		}
	}
}
