using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

	public float growMultiplier = 1.01f;
	public float maxSpeed = 10f;

	public Material[] materials;

	private bool reachedBottom = false;
	
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Bottom") {
			reachedBottom = true;
		}
	}

	void OnGUI () {
		GUI.skin.label.fontSize = 30;
		if (reachedBottom) {
			GUI.Label (new Rect((Screen.width/2) - 135, Screen.height/2, 275, 50), "Drops collected: " + DropletManager.Instance.dropsCollected	);

			if (GUI.Button(new Rect(Screen.width/2 - 75, (Screen.height/2) + 50, 150, 50), "Replay")) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		float move = Input.GetAxis ("Horizontal");
		rigidbody.velocity = new Vector2 (move * maxSpeed, rigidbody.velocity.y);

		rigidbody.drag = 2 * Mathf.Sin(Time.time) + 7;

		if (DropletManager.Instance.dropsCollected < 5) {
			GameObject.FindGameObjectWithTag ("Body").renderer.material = materials[0];
		}
		else if (DropletManager.Instance.dropsCollected <=10 && DropletManager.Instance.dropsCollected > 5) {
			GameObject.FindGameObjectWithTag ("Body").renderer.material = materials[1];
		}
		else if (DropletManager.Instance.dropsCollected <=15 && DropletManager.Instance.dropsCollected > 10) {
			GameObject.FindGameObjectWithTag ("Body").renderer.material = materials[2];
		}
		else if (DropletManager.Instance.dropsCollected <=20 && DropletManager.Instance.dropsCollected > 15) {
			GameObject.FindGameObjectWithTag ("Body").renderer.material = materials[3];
		}
		else if (DropletManager.Instance.dropsCollected <=25 && DropletManager.Instance.dropsCollected > 20) {
			GameObject.FindGameObjectWithTag ("Body").renderer.material = materials[4];
		}
	}

	public void Grow () {
		transform.localScale *= growMultiplier;
	}
}
