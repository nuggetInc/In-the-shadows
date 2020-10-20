using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
	public ItemSettings settings;

	public Item(ItemSettings _settings)
	{
		settings = _settings;
	}
}

public enum ItemType
{
	Stick = 0
}