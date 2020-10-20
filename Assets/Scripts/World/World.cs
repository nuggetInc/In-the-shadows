using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
	public GameObject campfire;
	public GameObject tree;

	public string worldName;

	public Player player;

	public int width = 100;
	public int height = 100;

	public float chunkWidth = 10;
	public float chunkHeight = 10;

	//List<EntityObject> entityObjects;
	Chunk[,] chunks;

	// Start is called before the first frame update
	void Start()
	{
		//entityObjects = new List<EntityObject>();
		chunks = new Chunk[width, height];
		ResetChunks();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Save()
	{
		//WorldData worldData = new WorldData(worldName, chunks);
		//SaveManager.SaveWorldData(worldData);
	}

	public void Load()
	{
		WorldData data = SaveManager.LoadWorldData(worldName);

		ResetChunks();
		for(int i = 0; i < data.entityObjectDatas.Length; i++)
		{
			switch(data.entityObjectDatas[i].objectType)
			{
				case ObjectType.Tree:
					GameObject treeObject = Instantiate(tree, new Vector3(data.entityObjectDatas[i].x, data.entityObjectDatas[i].y, 0), transform.rotation);

					Tree treeHandler = treeObject.GetComponent<Tree>();
					treeHandler.Load(data.entityObjectDatas[i]);

					AddEntityObject(treeHandler);
					break;
				case ObjectType.Campfire:
					GameObject campfireObject = Instantiate(campfire, new Vector3(data.entityObjectDatas[i].x, data.entityObjectDatas[i].y, 0), transform.rotation);

					Campfire campfireHandler = campfireObject.GetComponent<Campfire>();
					campfireHandler.Load(data.entityObjectDatas[i]);

					AddEntityObject(campfireHandler);
					break;
			}
		}
	}

	public void Generate()
	{
		GameObject campfireObject = Instantiate(campfire, Vector3.zero, transform.rotation);
		AddEntityObject(campfireObject.GetComponent<Campfire>());

		int treeCount = 1000;
		for(int i = 1; i < treeCount; i++)
		{
			GameObject treeObject = Instantiate(tree, RandomLocation(), transform.rotation);
			AddEntityObject(treeObject.GetComponent<Tree>());
		}
	}

	public void AddEntityObject(EntityObject entityObject)
	{
		GetChunkFromWorldLocation(entityObject.transform.position).AddEntityObject(entityObject);
	}

	public Vector3 RandomLocation()
	{
		return new Vector3((Random.value - .5f) * width, (Random.value - .5f) * height, 0);
	}

	public Chunk GetChunkFromWorldLocation(Vector3 position)
	{
		return chunks[Mathf.RoundToInt(position.x / chunkWidth) + width / 2, Mathf.RoundToInt(position.y / chunkHeight) + height / 2];
	}

	public Chunk[] GetChunksFromWorldLocation(Vector3 position, int radius)
	{
		int positionX = Mathf.RoundToInt(position.x / chunkWidth) + width / 2;
		int positionY = Mathf.RoundToInt(position.y / chunkHeight) + height / 2;
		Chunk[] chunksInArea = new Chunk[(radius * 2 + 2) * 2 + 1];
		for(int x = 0; x <= radius * 2; x++)
			for(int y = 0; y <= radius * 2; y++)
			{
				chunksInArea[y + x * (radius + radius + 1)] = chunks[positionX + x - radius, positionY + y - radius];
			}
		return chunksInArea;
	}

	public void ResetChunks()
	{
		for(int x = 0; x < width; x++)
			for(int y = 0; y < width; y++)
				chunks[x, y] = new Chunk();
	}

	public EntityObject GetClickedEntityObject()
	{
		Vector3 clickedWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);

		float lowest = float.PositiveInfinity;
		EntityObject clicked = null;

		foreach(Chunk chunk in GetChunksFromWorldLocation(clickedWorldPosition, 1))
		{
			foreach(EntityObject entityObject in chunk.entityObjects)
			{
				if(entityObject.transform.position.y < lowest)
					foreach(Collider2D collider in entityObject.GetComponents<Collider2D>())
					{
						if(collider.isTrigger)
						{

							if(collider.OverlapPoint(clickedWorldPosition))
							{
								lowest = entityObject.transform.position.y;
								clicked = entityObject;
							}

							//Debug.Log(closestPoint); Debug.Log(clickedWorldPosition);
						}
					}
			}
		}

		return clicked;
	}
}