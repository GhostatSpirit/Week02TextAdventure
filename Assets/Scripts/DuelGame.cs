using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DuelGame : MonoBehaviour {
	// bool that controls whether this script will run
	public bool active;
	bool lastActive;

	float beginTime;
	// the shortest time that the reaction moment starts
	public float minSec = 5f;
	// the longest time that the reaction moment 
	public float maxSec = 10f;

	// the average time for the NPC to react (in milliseconds)
	// the real time will be randomized (+- 50 milliseconds)
	public float averageComReactTime = 400f;

	// the moment that the reaction test starts
	float startReactMoment;
	// stores the time for the player to react (in milliseconds)
	float playerReactTime;
	// stores the time for NPC to react (in milliseconds)
	float comReactTime;

	// Use this for initialization
	void Start () {
		//hasBegun = false;
		beginTime = -1;

		startReactMoment = -1f;
		playerReactTime = -1f;
		comReactTime = GenerateReactTime();

		active = false;
		lastActive = false;
	}
	
	// Update is called once per frame
	void Update () {

		// make sure that this part will only be executed once
		if(active && (lastActive == false)){
			beginTime = GenerateBeginTime();
		}


		// if the script is not active, do not execute main game chunk
		// save the lastActive
		if (!active) {
			lastActive = active;
			return;
		} else{
			lastActive = active;
		}

		// main game chunk
		string textBuffer = "";
		textBuffer += "This is a duel Game between you and the driver.\n";
		textBuffer += "When the reference shouts “FIRE”, press [SPACE] as soon as possible.\n\n";



		if (Time.time < beginTime) {
			textBuffer += "READY...\n";
		} else {
			textBuffer += "FIRE! Press [SPACE] now!\n";

			if (startReactMoment == -1f)
				startReactMoment = Time.time;

			if (Input.GetKeyDown(KeyCode.Space) && playerReactTime == -1f) {
				playerReactTime = (Time.time - startReactMoment) * 1000f;
				Debug.Log(playerReactTime.ToString());
			}

			if (playerReactTime != -1f) {
				textBuffer += "\nYour reaction time: " + playerReactTime.ToString();
				textBuffer += "\nComp reaction time: " + comReactTime.ToString();
				if (playerReactTime <= comReactTime) {
					textBuffer += "\nYou won!\n";
				} else {
					textBuffer += "\nYou lose!\n";
					textBuffer +=   "The women driver seems bored. " +
									"She takes a sip of wine and says: " +
									"“No one can ever beat me in this game. " +
									"But if you want, we can just play again.”\n" +
									"\npress [D] to play the duel game again…";
					
					if(Input.GetKeyDown(KeyCode.D)){
						// generate the begin time again
						beginTime = GenerateBeginTime();
						// set the game to be a bit easier
						averageComReactTime += 50f;
						// generate the com reaction time again
						comReactTime = GenerateReactTime();
						// reset the variables
						startReactMoment = -1f;
						playerReactTime = -1f;
					}
				}
			}
		}

		GetComponent<Text>().text = textBuffer;

	}

	float GenerateBeginTime(){
		// generate a random time (in seconds)

		// get current time
		float current = Time.time;

		float temp = Random.Range(current + minSec, current + maxSec);
		Debug.Log(temp.ToString());
		return temp;
	}

	float GenerateReactTime(){
		float temp = Random.Range(averageComReactTime - 50f, averageComReactTime + 50f);

		return temp;
	}
		
}
