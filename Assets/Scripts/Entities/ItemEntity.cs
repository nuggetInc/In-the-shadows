using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntity : StaticEntity
{
	public void SetItem(Item item)
	{
		GetComponent<SpriteRenderer>().sprite = item.settings.sprite;
	}
}