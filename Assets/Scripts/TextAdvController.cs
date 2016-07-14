using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// GetComponet<TextAdvController>().currentRoom 

public class TextAdvController : MonoBehaviour {
	// member variables:

	// string that stores the current room name
	public string currentRoom;
	// bool that controls whether this script will be running
	public bool running;


	// bool that decides if the hero can enter the bar
	bool hasBarAccess;
	// wanderPos shows where the player is in the wander process in the Main Street
	int wanderPos = 0;

	// Use this for initialization
	void Start () {
		currentRoom = "Intro";
		hasBarAccess = false;
		running = true;
	}
	
	/* Rooms:
	 * Intro
	 * Space Station
	 * Bar
	 * Market
	 * Main Street
	 * Weapon Universe
	 * 
	 */

	void Update () {
		// declare the text buffer
		string textBuffer = "";

		if (currentRoom == "Intro") {
			ShowIntro (ref textBuffer);

		}
		else if (currentRoom == "Space Station"){
			ShowRoomName(ref textBuffer);
			ShowStationIntro (ref textBuffer);
		}
		else if (currentRoom == "Bar"){
			ShowRoomName (ref textBuffer);
			if(!hasBarAccess){
				ShowBarBlocked (ref textBuffer);
			} else{
				ShowBarEnter (ref textBuffer);
			}
		}
		else if (currentRoom == "Market"){
			ShowRoomName (ref textBuffer);
			ShowMarket (ref textBuffer);
		}
		else if(currentRoom == "Main Street"){
			ShowMainStreet(ref textBuffer);
		}

		// render out the text buffer
		GetComponent<Text>().text = textBuffer;
			
	}

	// add a line that shows the room name too the buffer
	void ShowRoomName(ref string textBuffer){
		string temp = "You are currently in: " + currentRoom + "\n";
		textBuffer += temp;
	}

	// show the introduction part of the story,
	// which only needs once
	void ShowIntro(ref string textBuffer){
		textBuffer += "You are Spike Spiegel.\n";
		textBuffer += "You are a space cowboy, a bounty hunter.\n";
		textBuffer += "\n";

		textBuffer += "When you don't have a target, your life is usually boring.\n";
		textBuffer += "But not this time...";
		textBuffer += "\n\n";

		textBuffer += "You are chasing a most-wanted, a dangerous dynamite scientist called Decker.\n";
		textBuffer += "All the evidence lead you here... Mars. The beautiful planet.\n";
		textBuffer += "\n";

		textBuffer += "press [SPACE] to land on Mars Space Station…\n";

		if(Input.GetKeyDown(KeyCode.Space)){
			currentRoom = "Space Station";
		}

	}

	void ShowStationIntro(ref string textBuffer){
		textBuffer +=   "Mars is the new hangout for humanity, " +
						"after the earth is heavily damaged by an accident " +
						"during the construction of Astral Gate.\n" +
						"\nMars Space Station is the transportation center. " +
						"This place is jammed with space shutters " +
						"which can take you anywhere on Mars, even to those borderlands.\n" +
						"\nWhen you are tracing someone, bars and markets are the places to go.\n" +
						"\npress [A] to go to the Bounty Hunter Bar…\n" +
						"press [D] to head for Mars Open Market…\n";

		if(Input.GetKeyDown(KeyCode.A)){
			currentRoom = "Bar";
		} else if(Input.GetKeyDown(KeyCode.D)){
			currentRoom = "Market";
		}

	} 

	void ShowBarBlocked(ref string textBuffer){
		textBuffer +=   "As soon as you step onto the stairs in front of Bounty Hunter Bar, " +
						"two sturdy guards get in your way and speak firmly:\n" +
						"“This is an restricted area. VIPs only.”\n" +
						"\n“Hah, a Bounty Hunter Bar blocks bounty hunters away,” you think.\n" +
						"As you are thinking, your space shutter takes off and flies away.\n" +
						"Now you have to wait hours for another shutter.\n" +
						"\npress [S] to head back to Mars Space Station…";
		
		if(Input.GetKeyDown(KeyCode.S))
			currentRoom = "Space Station";

	}

	void ShowBarEnter(ref string textBuffer){
		
	}

	void ShowMarket (ref string textBuffer){
		textBuffer += "Mars Open Market is the largest known market in the universe. " +
		"Crowds come and leave, dealing things ranging from rare vegetables to deadly weaponry.\n" +
		"\nThe Main Street is crowded with all kinds of people: " +
		"merchants, mercenaries, travelers, kids and of course, gangs. " +
		"At the corner of the street you can find Weapon Universe, " +
		"which is, literally, the universe of weapons.\n" +
		"\npress [A] to wander on the Main Street…" +
		"\npress [D] to enter Weapon Universe…" +
		"\npress [S] to return to Mars Space Station…";
		if(Input.GetKeyDown(KeyCode.A)){
			currentRoom = "Main Street";
		} else if(Input.GetKeyDown(KeyCode.D)){
			currentRoom = "Weapon Universe";
		} else if(Input.GetKeyDown(KeyCode.S)){
			currentRoom = "Space Station";
		}
	}

	void ShowMainStreet(ref string textBuffer){
		// wanderPos stores where the player is in the wander process
		textBuffer += "Your are wandering in the Main Street of the market.\n";
		if(wanderPos == 0){
			//Wander0();
		} else{
				
		}
	}


}
