using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextAdvController : MonoBehaviour {
	// member variables
	string currentRoom;

	// Use this for initialization
	void Start () {
		currentRoom = "Intro";
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "Hi. \n";

		if (currentRoom == "Intro") {
			ShowIntro (ref textBuffer);
		}
		else if (currentRoom == "Elevators"){
			ShowRoomName(ref textBuffer);
			textBuffer += "You see the security guard.\n";

			textBuffer += "press [W] to go to elevators\n";
			textBuffer += "press [S] to go outside\n";

			if (Input.GetKeyDown(KeyCode.W)){
				currentRoom = "Elevators";
			} else if (Input.GetKeyDown(KeyCode.S)){
				currentRoom = "Outside";
			}

		}
		else if (currentRoom == "Outside"){
			// all your OUTSIDE code
		}

		// render out the text buffer
		GetComponent<Text>().text = textBuffer;
			
	}

	// add a line that shows the room name too the buffer
	void ShowRoomName(ref string textBuffer){
		string temp = "You are currently in " + currentRoom + ". \n";
		textBuffer += temp;
	}

	// show the introduction part of the story,
	// which only needs once
	void ShowIntro(ref string textBuffer){
		textBuffer += "You are Spike Spiegel.\n";
		textBuffer += "You are a space cowboy, a bounty hunter.\n";
		textBuffer += "\n";
		textBuffer += "When you don't have a target, your life is usually boring, sometimes frugal.\n";
		textBuffer += "\n";
		textBuffer += "But not this time.";
		//textBuffer += "";
	}
}
