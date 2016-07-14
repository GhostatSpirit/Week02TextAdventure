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
	// bool that stores whether the player knows the apperance of Decker
	bool knownAppearance;

	// bool that shows whether the player has finished searching in the Main Street
	bool visitedMainStreet;
	// bool that shows whether the player has finished searching in Weapon Universe
	bool visitedWeaponUniverse;
	// wanderPos shows where the player is in the wander process in the Main Street
	int wanderPos = 0;
	// shows where the player is in Weapon Universe
	int weaponPos = 0;

	// Use this for initialization
	void Start () {
		running = true;
		currentRoom = "Intro";

		hasBarAccess = false;
		knownAppearance = false;

		visitedMainStreet = false;
		visitedWeaponUniverse = false;

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
		else if(currentRoom == "Weapon Universe"){
			ShowRoomName(ref textBuffer);
			ShowWeaponUniverse(ref textBuffer);
		}

		// render out the text buffer
		GetComponent<Text>().text = textBuffer;
			
	}

	// add a line that shows the room name too the buffer,
	// then add another blank line
	void ShowRoomName(ref string textBuffer){
		string temp = "You are currently in: " + currentRoom + "\n\n";
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
						"\n“Hah, a Bounty Hunter Bar blocks bounty hunters away,” you grumble.\n" +
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
		"which is, literally, the universe of weapons.\n";
		
		if (!visitedMainStreet)
			textBuffer += "\npress [A] to wander on the Main Street…";
		if (!visitedWeaponUniverse)
			textBuffer += "\npress [D] to enter Weapon Universe…";
		textBuffer += "\npress [S] to return to Mars Space Station…";

		if(Input.GetKeyDown(KeyCode.A)){
			if (!visitedMainStreet)
				currentRoom = "Main Street";
		} else if(Input.GetKeyDown(KeyCode.D)){
			if (!visitedWeaponUniverse)
				currentRoom = "Weapon Universe";
		} else if(Input.GetKeyDown(KeyCode.S)){
			currentRoom = "Space Station";
		}
	}


	void ShowMainStreet(ref string textBuffer){
		// wanderPos stores where the player is in the wander process

		if(wanderPos == 0 || wanderPos == 1){
			textBuffer += "Your are wandering in the Main Street of the market.\n\n";
			textBuffer += "You start chatting with people and you are pretty good of it. " +
						  "You start asking people questions about your target, Decker.\n";
		}
		if (wanderPos == 0) {
			ShowWanderMsg0(ref textBuffer);
		}
		else if (wanderPos == 1){
			ShowWanderMsg1(ref textBuffer);
		}
		else if (wanderPos == 2){
			textBuffer += "Your are wandering in the Main Street of the market.\n\n";
			ShowWanderMsg2(ref textBuffer);
		}
		else if (wanderPos == 3){
			ShowWanderMsg3(ref textBuffer);
		}
	}

	void ShowWanderMsg0(ref string textBuffer){
		textBuffer +=   "A hippie with slovenly appearance answers: " +
						"“What, Decker? He seems to be two-meter-tall muscle nerd. " +
						"I heard that he used to play basketball.”\n" +
						"\nA merchant with an white headscarf and gold rings on his fingers says: " +
						"“I know Decker. I know about him. People call him ‘Decker the Demolition’. " +
						"A very charming girl, she is.” \n" +
						"\npress [D] to ask other people…";
		
		if (Input.GetKeyDown(KeyCode.D)) {
			wanderPos++;
		}
		
	}

	void ShowWanderMsg1(ref string textBuffer){
		textBuffer += "A beggar sitting on the sidewalk with a stick in his hand tells you: " +
				      "“No, no! Decker is just a college student who was expelled from school. " +
					  "Some said to me it’s because he wanted to blow his professor up.”\n" +
				   	  "\nA housewife who is petting her kitty mentions: " +
					  "“Someone told me that this Decker is a ladyboy.”\n" +
					  "\npress [D] to keep wandering on the street…";

		if (Input.GetKeyDown(KeyCode.D)) {
			wanderPos++;
		}
		
	}

	void ShowWanderMsg2(ref string textBuffer){
		textBuffer +=  "You meet a little boy selling newspaper, and you ask him " +
						"if he knows anything about Decker.\nThe boy says firmly: " +
						"“Decker must be an alien. All my friends say he is.”\n" +
						"Your head starts to ache.\n" +
						"“Now, could you please buy a copy of newspaper?”" +
						"\n“Ah…” you sigh, then you pull out a coin.\n" +
						"\n“Oh, and, are you a bounty hunter? Then this might be useful!”\n" +
						"The boy takes a letter out of his pocket and handed it to you. " +
						"Then just he disappears in the crowd. \n" +
						"\npress [D] to examine the letter.";
		
		if (Input.GetKeyDown(KeyCode.D)) {
			wanderPos++;
		}
	}

	void ShowWanderMsg3(ref string textBuffer){
		textBuffer +=   "On the front it reads “Invitation”, " +
						"the letters are printed with a beautiful handwritten font.\n" +
						"On the back it reads “Mars Bounty Hunter Bar”, " +
						"with its logo besides.\n" +
						"\n“I think we’ve done with searching on the main street,” you thought.\n" +
						"\npress [S] to return to Mars Space Station";
		
		if (Input.GetKeyDown(KeyCode.S)) {
			hasBarAccess = true;
			visitedMainStreet = true;
			currentRoom = "Space Station";
		}
	}


	void ShowWeaponUniverse(ref string textBuffer){
		if(weaponPos == 0){
			showWeapon0(ref textBuffer);
		} else if(weaponPos == 1){
			showWeapon1(ref textBuffer);
		}
	}

	void showWeapon0(ref string textBuffer){
		textBuffer +=   "You walk by shabby shelves and displays in Weapon Universe, " +
						"glancing from Japanese swords to cutting-edge labor cannons. " +
						"The owner of this gun shop is browsing " +
						"an pornographic magazine behind the counter.\n" +
						"\nChatting with the owner, you start mentioning your prey, Decker. " +
						"Yet the owner speaks to you impatiently, eyes still on that magazine:\n" +
						"“Bro, on Mars, everything has a price, no matter it is weapons or people’s lives. " +
						"You’ll need to pay something if you want information.”\n" +
						"\npress [D] to keep wandering in the shop";
		
		if (Input.GetKeyDown(KeyCode.D)) {
			weaponPos++;
		}
	}

	void showWeapon1(ref string textBuffer){
		textBuffer +=  "You walk at a slow pace, and eventually stop by " +
						"an interesting pair of nunchucks. \n\n" +
						"“This pair of nunchucks has an extremely long chain. " +
						"Is it the kind of pair Bruce Lee used in ‘Way of the Dragon’?” " +
						"you asked.\n“You know that?” " +
						"The shop owner moved his eyes off the magazine. " +
						"“It’s from the 21st century. Really rare ones.”\n\n" +
						"You start playing with the nunchucks, waving them here and there. " +
						"The shop owner looks like having a pleasure. " +
						"As you stop your performance, he opens his mouth:\n" +
						"“All I know is Decker is a guy with a Dragon tattoo. " +
						"One of my best friends at the police office told me.”\n\n" +
						"Well, at least the search scope is narrowed down a little.\n\n" +
						"press [S] to head back to Mars Space Station";
		if (Input.GetKeyDown(KeyCode.S)) {
			visitedWeaponUniverse = true;
			currentRoom = "Space Station";
		}
	}

}
