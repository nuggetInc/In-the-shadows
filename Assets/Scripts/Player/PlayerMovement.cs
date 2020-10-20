using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;

	Player player;
	PlayerAutoChop autoHarvest;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		player = GetComponent<Player>();
		autoHarvest = GetComponent<PlayerAutoChop>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
			autoHarvest.autoMoving = false;

		if(!autoHarvest.autoMoving)
		{
			Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			rb.velocity = direction.normalized * player.speed;
		}
	}
}
