using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// player holds down W, move up
		if( Input.GetKey( KeyCode.W ) ){
			// GetComponent<Transform> ();
			// Time.deltaTime is the duration of the frame in seconds
			// "framerate "
			transform.position += new Vector3(0f, 5f, 0f) * Time.deltaTime;
			//Debug.Log(transform.position.y); // reading the Y is OK

		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position += new Vector3(0f, -5f, 0f) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position += new Vector3(-5f, 0f, 0f) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += new Vector3(5f, 0f, 0f) * Time.deltaTime;
		}
	}
}
