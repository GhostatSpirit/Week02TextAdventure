using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DuetGame : MonoBehaviour {
	// bool that controls whether this script will run
	bool running;

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
		beginTime = GenerateBeginTime();

		startReactMoment = -1f;
		playerReactTime = -1f;
		comReactTime = GenerateReactTime();

		running = false;
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "";
		textBuffer += "This is a duet Game.\n";



		if (Time.time < beginTime) {
			textBuffer += "READY...\n";
		} else {
			textBuffer += "Press [SPACE] now!\n";

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
				}
			}
		}

		GetComponent<Text>().text = textBuffer;

	}

	float GenerateBeginTime(){
		// generate a random time (in seconds)
		float temp = Random.Range(minSec, maxSec);
		Debug.Log(temp.ToString());
		return temp;
	}

	float GenerateReactTime(){
		float temp = Random.Range(averageComReactTime - 50f, averageComReactTime + 50f);

		return temp;
	}
		
}
