using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Update is called once per frame
	void Awake () {
		DontDestroyOnLoad (this);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Application.LoadLevel ("MainScene");
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
