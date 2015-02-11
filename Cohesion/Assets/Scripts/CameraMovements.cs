using UnityEngine;
using System.Collections;

public class CameraMovements : MonoBehaviour {

	public float maxPosX = 18.0f;
	public float minPosX = 0.0f;
	public float maxPosY = 5.0f;
	public float minPosY = -12.0f;

	public GameObject player;

	// Update is called once per frame
	void Update () {
		if(WithinBounds ()) {
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
		}
	}

	private bool WithinBounds () {
		if (player.transform.position.x > minPosX && player.transform.position.x < maxPosX &&
			player.transform.position.y > minPosY && player.transform.position.y < maxPosY) {
				return true;
		}

		return false;
	}
}
