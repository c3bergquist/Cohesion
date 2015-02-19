using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

	public float growMultiplier = 1.01f;
	public float growSpeed = 1.0f;
	public float maxSpeed = 10f;

	public GameObject rotateDrop;

	public Material[] materials;

	private bool reachedBottom = false;
	
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Bottom") {
			reachedBottom = true;
		}
	}

	void OnGUI () {
		if (reachedBottom) {
			GUI.skin.label.fontSize = 30;
			GUI.Label (new Rect((Screen.width/2) - 135, Screen.height/2, 275, 50), "Drops collected: " + DropletManager.Instance.dropsCollected);

			GUI.skin.label.fontSize = 20;
			GUI.Label (new Rect((Screen.width/2) - 110, (Screen.height/2) + 50, 275, 50), "Press Space To Restart");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		float move = Input.GetAxis ("Horizontal");
		rigidbody.velocity = new Vector2 (move * maxSpeed, rigidbody.velocity.y);

		transform.localEulerAngles = new Vector3 (0, 180, -move * 30);
		rotateDrop.transform.localEulerAngles = new Vector3 (0, 0, -move * 30);

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
		Vector3 newScale = transform.localScale * growMultiplier;
		transform.localScale = Vector3.Lerp(transform.localScale, newScale, growSpeed);
	}
}
