using UnityEngine;
using System.Collections;

public class PlayerPhysicsMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Update is where rendering and input update
	// FixedUpdate is called once per PHYSICS FRAME
	void FixedUpdate(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

		if (Input.GetKey(KeyCode.W)){
			GetComponent<Rigidbody2D>().velocity += new Vector2(0f, 50f) * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S)){
			GetComponent<Rigidbody2D>().velocity += new Vector2(0f, -50f) * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A)){
			GetComponent<Rigidbody2D>().velocity += new Vector2(-50f, 0f) * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D)){
			GetComponent<Rigidbody2D>().velocity += new Vector2(50f, 0f) * Time.deltaTime;
		}
	}
}
