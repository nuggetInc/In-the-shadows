using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public World world;
	PlayerAutoChop autoMovement;

	public float reach = 1;
	public float speed = 3;

	// Start is called before the first frame update
	void Start()
	{
		autoMovement = GetComponent<PlayerAutoChop>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			EntityObject clicked = world.GetClickedEntityObject();
			if(clicked != null && clicked.GetType() == typeof(Tree))
			{
				//autoMovement.autoMoving = true;
				//autoMovement.destination = clicked;
				Debug.Log(clicked.GetType() == typeof(Tree));
			}
		}

		//if(Input.GetMouseButtonDown(1))
		//world.Load();
		if(Input.GetMouseButtonDown(2))
			world.Generate();

		if(Input.GetKeyDown(KeyCode.Space))
		{
			Chunk[] localChunks = world.GetChunksFromWorldLocation(transform.position, 1);

			float shortestDistance = float.PositiveInfinity;
			EntityObject closest = null;
			foreach(Chunk chunk in localChunks)
				foreach(EntityObject entityObject in chunk.entityObjects)
				{
					float sqrMagnitude = (entityObject.transform.position - transform.position).sqrMagnitude;
					if(sqrMagnitude < shortestDistance)
					{
						shortestDistance = sqrMagnitude;
						closest = entityObject;
					}
				}

			if(closest != null)
			{
				autoMovement.autoMoving = true;
				//autoMovement.destination = closest;
			}
		}
	}
}
