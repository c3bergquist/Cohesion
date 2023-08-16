using UnityEngine;
using System.Collections;

public class Droplet: MonoBehaviour {

	public AudioClip dropSound;

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == "Player") {
			DropletManager.Instance.player.GetComponent<CharController> ().Grow ();
			DropletManager.Instance.dropsCollected++;

			AudioSource.PlayClipAtPoint (dropSound, transform.position);

			Destroy (this.gameObject);
		}
		else if (collider.gameObject.tag == "Droplet") {
			transform.localScale = new Vector3 (transform.localScale.x * 1.1f, transform.localScale.y * 1.1f, transform.localScale.z * 1.1f);
			Destroy (collider.gameObject);
		}
	}
}
