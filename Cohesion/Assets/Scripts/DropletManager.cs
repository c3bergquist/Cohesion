using UnityEngine;
using System.Collections;

public class DropletManager : MonoBehaviour {

	public float minY = 0.0f;
	public float maxY = 0.0f;
	public float minX = 0.0f;
	public float maxX = 0.0f;


	public static DropletManager Instance {
		get	{
			if(instance == null)
				instance = GameObject.FindObjectOfType<DropletManager>();
			return instance;
		}
	}

	public GameObject droplet;
	public GameObject player;

	public int dropsCollected = 0;
	public int numToSpawn = 0;

	private Vector3 position;
	private static DropletManager instance;

	// Use this for initialization
	void Start() 
	{
		int spawned = 0;
		
		while (spawned < numToSpawn)
		{
			position = new Vector3 (Random.Range(minX, maxX), Random.Range(minY, maxY), -3.4f);

			Quaternion rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
			Instantiate(droplet, position, rotation);
			spawned++;
		}
	}
}
