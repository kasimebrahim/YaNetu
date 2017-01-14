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
	public GameObject gameControl;

	private Transform playerTransform;
	private bool completed;
	private bool openTheDoor = false;
	private bool walk = true;
	private bool startedTeaching = false;
	private bool talk = true;




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
		if (State == 0) 
		{
			movePlayer (door, 25, 0);
		}
		else if (State == 1) 
		{
			openDoor (door);
		}
		else if (State == 2) 
		{
			movePlayer (Box, 10, 1);
		} 
		else if (State == 3) 
		{
			speak ();
		}
		else if (State == 4) 
		{
			
		}



	}


	// postion 0 for foreward 1 for backward
	// this method moves the player given the game object 
	void movePlayer (GameObject gameobject,float distance,int postion)
	{
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


	void speak(){
		if(talk){
			ps.Speek ("Welcome to the class. In this class we are going to learn about numbers." +
				" Numbers are  a word or symbol (such as “five” or “16”) that represents a specific amount or quantity." +
				" : a number or a set of numbers and other symbols that is used to identify a person or thing." +
				"Now let us see each numbers individually.\nThe symbol displayed on the box is the first number." +
				"This number is called one.\nThis number represents a quantity of one real world object." +
				"Forexample, one bird, one lion, one orangeor one banana.\nTo see what is inside the box. Say One out loud. ");
			talk = false;

		}
	}
}
