using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager
{
	/*public static void SaveChunkData(string worldName, ChunkData data)
	{
		string worldFolder = Application.persistentDataPath + "/" + worldName;
		Directory.CreateDirectory(worldFolder);
		string destination = Application.persistentDataPath + "/" + worldName + "/" + data.x + " " + data.y;
		FileStream file;

		if(File.Exists(destination)) file = File.OpenWrite(destination);
		else file = File.Create(destination);

		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(file, data);
		file.Close();
	}

	public static ChunkData LoadChunkData(string worldName, int x, int y)
	{
		string destination = Application.persistentDataPath + "/" + x + " " + y;
		FileStream file;

		if(File.Exists(destination)) file = File.OpenRead(destination);
		else
		{
			Debug.LogError("file not found");
			return null;
		}

		BinaryFormatter bf = new BinaryFormatter();
		ChunkData chunkData = (ChunkData)bf.Deserialize(file);
		file.Close();
		return chunkData;
	}*/

	public static void SaveWorldData(WorldData world)
	{
		string destination = Application.persistentDataPath + "/" + world.name;
		FileStream file;

		if(File.Exists(destination)) file = File.OpenWrite(destination);
		else file = File.Create(destination);

		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(file, world);
		file.Close();
	}

	public static WorldData LoadWorldData(string name)
	{
		string destination = Application.persistentDataPath + "/" + name;
		FileStream file;

		if(File.Exists(destination)) file = File.OpenRead(destination);
		else
		{
			Debug.LogError("file not found");
			return null;
		}

		BinaryFormatter bf = new BinaryFormatter();
		WorldData chunkData = (WorldData)bf.Deserialize(file);
		file.Close();
		return chunkData;
	}
}
