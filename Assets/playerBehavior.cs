using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
using Assets.src.dialogue;

public class playerBehavior : MonoBehaviour {

	private DialogueSystem dialogueSys;
	private ThirdPersonCharacter thirdPersonScript;
	PluginScript ps ;

	public int max= 150;
	public int speed = 7;
	private int State = 0;

	private ArrayList scripts;

	float i = 0;
	public GameObject door;
	public GameObject Box;
	public GameObject Boxtwo;
	public GameObject gameControl;
	public GameObject ButtonObj;

	private Transform playerTransform;
	private bool completed;
	private bool openTheDoor = false;
	private bool walk = true;

	private bool talk = true;
	private bool talk2 = true;
	private bool talk3 = true;


	// Use this for initialization
	void Start () {
		
		//Link Scripts
		thirdPersonScript = gameObject.GetComponent<ThirdPersonCharacter>();

		//Link Objects
		playerTransform = gameObject.GetComponent<Transform> ();

		// integrate the STT/TTS module
		gameControl = GameObject.FindGameObjectWithTag("gamecont");
		ps = gameControl.GetComponent<PluginScript> ();

		// interate the Dialogue System
		dialogueSys = new DialogueSystem ();
			
	}
	
	// Update is called once per frame
	void Update () {
		/*
	 The Main Game logic works in simple State Machine Approch
		 state 0 = the player will walk form the coridor to the door and stops there
		 state 1 = the door will open
		 State 2 = go to the Box 
		 State 3 = yanetu will tell talk to the kid
		 State 4 = player will have the option of saying the number 
 		*/
		print (">>>>>>>>>>state" + State);
		if (State == 0) {
			movePlayer (door, 25, 0);
		}else if (State == 1) {
			openDoor (door);
		}else if (State == 2) {
			movePlayer (Box, 10, 1);
		}else if (State == 3) {
			Learn1speak ();
		}else if (State == 4) {
			showButton ();
		}else if (State == 5) {
			Learn1speak2 ();
		}else if (State == 6) {
			Learn2speak ();
		}else if (State == 7) {
			Learn2speak2 ();
		}
	}

	 // postion 0 for foreward 1 for backward
	// this method moves the player given the game object 
	void movePlayer (GameObject gameobject,float distance,int postion){
		Vector3 finalPos;
		if (postion == 0) {
			finalPos = -gameobject.transform.position;
		} else {
			finalPos = gameobject.transform.position;
		}
		completed = false;
		float journyLeangth = Vector3.Distance (playerTransform.position, finalPos	);
		if (journyLeangth > distance) {
			thirdPersonScript.Move (Vector3.Lerp (playerTransform.position, finalPos, 10f), false, false);
			// looging
			Debug.Log (gameobject.transform.position + "->" + playerTransform.position);
			Debug.Log (">>>>" + journyLeangth);
		} else if (State == 0) {
			openTheDoor = true;
			State = 1;
		} else {
			State = 3;
		}
		Debug.Log ("Done");
	}

	// this method opens the door
	void openDoor(GameObject gameObject){
		gameObject.transform.Translate (Vector3.forward * Time.deltaTime * 10f);
		if (gameObject.transform.position.x > 6) {
			State = 2;
		}
	}

	// Here begins the code that teach the kid about number 1
	void Learn1speak(){
		if(talk){
			ps.Speek ("Welcome to the class. In this class we are going to learn about numbers." +
				" Numbers are  a word or symbol such as five or 16 that represents a specific amount or quantity." +
				" a number or a set of numbers and other symbols that is used to identify a person or thing." +
				" Now let us see each numbers individually. The symbol displayed on the box is the first number." +
				" This number is called one. This number represents a quantity of one real world object." +
				" Forexample, one bird, one lion, one orangeor one banana.To see what is inside the box." +
				" BREAK THE BOX using the hammer.");
			talk = false;
			State = 4;
		}
	}

	void showButton(){
		ButtonObj.SetActive(true);
		if (Box == null) {
			State = 5;
		}
	}

	void Learn1speak2(){
		if (talk2) {
			ps.Speek (" well Done. you have got One Bird. As you can see the number one represents One bird." +
					  " good let us see the next number.");
			talk2 = false;
			State = 6;
		}
	}


	// Here begins the code that teach the kid about number 2
	void Learn2speak(){
		Boxtwo.SetActive(true);
		State = 7;
	}

	void Learn2speak2(){
		if (talk3) {
			ps.Speek ("The symbol displayed on the box is the second number. It is name is Two." +
				      "this number represents two real objects. Two birds, two bananas and so on." +
				      "To see what is inside the box or to know what the number two represents say Two out loud.");
			talk3 = false;
			State = 8;
		}
	}
}
