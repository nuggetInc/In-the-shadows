using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TreeData : EntityObjectData
{
	public TreeData(float _x, float _y) : base(_x, _y)
	{
		objectType = ObjectType.Tree;
	}
}
