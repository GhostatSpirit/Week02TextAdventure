using UnityEngine;
using System.Collections;

public class TextAdvSystem : MonoBehaviour {
	string currentRoom = "";
	string lastRoom = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currentRoom = GetComponent<TextAdvController>().currentRoom;

		// use lastRoom so this part will only execute once
		if(currentRoom == "Duel Game" && lastRoom != "Duel Game"){
			GetComponent<TextAdvController>().active = false;
			GetComponent<DuelGame>().active = true;
		}

		if(currentRoom!= "Duel Game" && lastRoom == "Duel Game"){
			GetComponent<TextAdvController>().active = true;
			GetComponent<DuelGame>().active = false;
		}

		lastRoom = currentRoom;
	}
}
