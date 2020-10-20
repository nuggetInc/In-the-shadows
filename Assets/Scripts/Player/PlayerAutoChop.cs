using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoChop : MonoBehaviour
{
	public bool autoMoving = false;
	public Tree destination;

	Rigidbody2D rb;
	Player player;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		player = GetComponent<Player>();
	}

	void Update()
	{
		if(autoMoving)
		{
			Vector3 difference = destination.transform.position - transform.position;
			if(difference.sqrMagnitude < player.reach * player.reach)
				if(destination.health < 0)
					autoMoving = false;
				else
					rb.velocity = difference.normalized * player.speed;
		}
	}
}
