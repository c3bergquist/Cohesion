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

	private Vector2 position;
	private static DropletManager instance;

	// Use this for initialization
	void Start() 
	{
		int spawned = 0;
		
		while (spawned < numToSpawn)
		{
			position = new Vector2 (Random.Range(minX, maxX), Random.Range(minY, maxY));
			Instantiate(droplet, position, Quaternion.identity);
			spawned++;
		}
	}
}
