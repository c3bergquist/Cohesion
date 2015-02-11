using UnityEngine;
using System.Collections;

public class DropletManager : MonoBehaviour {

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
			position = new Vector2 (Random.Range(-4.5f, 4.5f), Random.Range(-10.0f, 4.0f));
			Instantiate(droplet, position, Quaternion.identity);
			spawned++;
		}
	}
}
