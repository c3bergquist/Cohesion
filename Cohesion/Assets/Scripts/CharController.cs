using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

	public float maxSpeed = 10f;

	private float currentSize;
	
	// Update is called once per frame
	void Update () 
	{
		currentSize = transform.localScale.x;
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		rigidbody2D.drag = 2 * Mathf.Sin(Time.time) + 3;
	}

	public void Grow () {
		transform.localScale *= 1.1f;
	}
}
