﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// GetComponet<TextAdvController>().currentRoom 

public class TextAdvController : MonoBehaviour {
	// member variables:

	// string that stores the current room name
	public string currentRoom;
	// bool that controls whether this script will be running
	public bool active;


	// bool that decides if the hero can enter the bar
	bool hasBarAccess;
	// bool that stores whether the player knows the apperance of Decker
	bool knownAppearance;

	// bool that shows whether the player has finished searching in the Main Street
	bool visitedMainStreet;
	// bool that shows whether the player has finished searching in Weapon Universe
	bool visitedWeaponUniverse;
	// bool that shows whether the player has finished the duel game
	bool visitedDuelGame;
	// wanderPos shows where the player is in the wander process in the Main Street
	int wanderPos = 0;
	// shows where the player is in Weapon Universe
	int weaponPos = 0;

	int punchNum = 0;
	// Use this for initialization
	void Start () {
		active = true;
		currentRoom = "Intro";

		hasBarAccess = false;
		knownAppearance = false;

		visitedMainStreet = false;
		visitedWeaponUniverse = false;
		visitedDuelGame = false;

	}
	
	/* Rooms:
	 * Intro
	 * Space Station
	 * Bar
	 * Market
	 * Main Street
	 * Weapon Universe
	 * Duel Game
	 * Duel Game Won
	 * Shady Treasure
	 * Outro
	 */


	void Update () {
		// if the script is not active, do not execute the following lines
		if (!active)
			return;

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
		else if (currentRoom == "Duel Game Won"){
			textBuffer += "You are currently in: Bar\n\n";
			ShowDuelWon(ref textBuffer);
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
		else if(currentRoom == "Shady Treasure"){
			ShowRoomName(ref textBuffer);
			ShowShadyTreasure(ref textBuffer);
		}
		else if(currentRoom == "Outro"){
			ShowOutro(ref textBuffer);
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

		if (visitedDuelGame)
			textBuffer += "press [W] to try to find Shady Treasure…\n";

		if(Input.GetKeyDown(KeyCode.A)){
			currentRoom = "Bar";
		} else if(Input.GetKeyDown(KeyCode.D)){
			currentRoom = "Market";
		} else if(Input.GetKeyDown(KeyCode.W)){
			if (visitedDuelGame)
				currentRoom = "Shady Treasure";
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
		textBuffer +=   "Just as the security guards try to block you from getting into the bar, " +
						"you show them the invitation letter. The guards check your letter, " +
						"then they move aside to let you in.\n\n";
		if (!visitedDuelGame) {
			textBuffer +=   "A group of bounty hunters are gathering around " +
							"a mid-aged women cargo shutter drive who seems to have " +
							"some really rare information about Decker. " +
							"Only the first one who can beat her in the duel game can get that prize. \n" +
							"(It’s okay. They are only using laser toy guns so no on can get hurt.)\n\n" +
							"press [D] to play the duel game with the driver…\n";
		}
		else {
			textBuffer +=   "You walk into the Bounty Hunter Bar. " +
							"You see a lot of bounty hunter celebrities, " +
							"whose faces always appear on the Celestial TV. " +
							"Some of them are speaking to the cameras, " +
							"claiming that they are just about to catch that most-wanted Decker.\n\n";
			textBuffer +=   "“Huh, a bunch of kids. Do nothing but alarm my target. " +
							"They have made my job a lot harder.” You grumble.\n\n";
		}

		textBuffer += "press [S] to return to Mars Space Station…\n";

		if (Input.GetKeyDown(KeyCode.D)) {
			if(!visitedDuelGame)
				currentRoom = "Duel Game";
		}
		if(Input.GetKeyDown(KeyCode.S)){
			currentRoom = "Space Station";
		}
	}

	void ShowDuelWon(ref string textBuffer){
		textBuffer += "You enjoy looking at this women’s surprised face. " +
			"Then the driver leads you out of the crowd to a private room, " +
			"with guards blocking other curious bounty hunters away.\n\n" +
			"She tells you: “Go to Kai Feng Road and you will see " +
			"a black market called ‘Shady Treasure’. " +
			"Maybe you can find something there.\n\n" +
			"press [S] to return to Mars Space Station…";

		if(Input.GetKeyDown(KeyCode.S)){
			currentRoom = "Space Station";
			visitedDuelGame = true;
		}
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
						"Well, at least the search scope is narrowed down a little.\n" +
						"press [S] to head back to Mars Space Station";
		if (Input.GetKeyDown(KeyCode.S)) {
			visitedWeaponUniverse = true;
			knownAppearance = true;
			currentRoom = "Space Station";
		}
	}

	void ShowShadyTreasure(ref string textBuffer){
		textBuffer +=   "You entered the gloomy black market, " +
						"crowded with merchants and criminals dealing illegal drugs and weapons. \n";
		
		if (!knownAppearance){
			textBuffer += 
				"\nYou want to search for your prey Decker, " +
				"but then you realize you know nothing about his appearance. " +
				"According to those sources from the Main Street, " +
				"it seems like Decker is a two-meter-tall child beauty " +
				"who used to be a basketball player, or some kind of transsexual alien.\n" +
				"\nAh… Maybe you need more clues to trace this Decker. " +
				"Heading for the market again sounds like a good idea.\n" +
				"press [S] to go back to Mars Space Station…\n";
			if(Input.GetKeyDown(KeyCode.S)){
				currentRoom = "Space Station";
			}
		} else {
			textBuffer +=   "You search everywhere for a person with the dragon tattoo. " +
							"You are scanning people’s skins: you find snake tattoo, bear tattoo, " +
							"Chinese character tattoo, but no dragon tattoo.\n" +
							"\nYou feel tired, so you head for the restroom to wash your face. " +
							"Through the mirror you see a timid student-like young man with…\n" +
							"A dragon tattoo on his upper shoulder! " +
							"That’s him!\n" +
							"\nYour start to punch him in his face, trying to knock him off.\n" +
							"\n(press [Space] to land on punches)\nPunches: " + punchNum.ToString();
			if(punchNum >= 30){
				currentRoom = "Outro";
			}
			
			if(Input.GetKeyDown(KeyCode.Space)){
				punchNum++;
			}
		}
	}

	void ShowOutro(ref string textBuffer){
		textBuffer +=   "You beat Decker down and send him to the Mars Police Department. " +
						"1000000 credits are immediately added to your account. " +
						"The beggar in the Main Street appears in your mind: " +
						"he said Decker is a student expelled from school, " +
						"looks like he’s right.\n\n" +
						"“Maybe I owe him a meal. I’ll take him to have some Peking Duck with me!”\n" +
						"\nTime for celebration!\nYOU WON!";
	}


}
