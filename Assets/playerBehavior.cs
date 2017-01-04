using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
using Assets.src.dialogue;

public class playerBehavior : MonoBehaviour {

	private DialogueSystem dialogueSys;
	private ArrayList scripts;
	public int max= 150;
	public int speed = 7;
	float i = 0;
	public GameObject door;
	public GameObject Box;
	private bool walk = true;
	private bool startedTeaching = false;
	private ThirdPersonCharacter thirdPersonScript;
	private Transform playerTransform;
	private bool completed;
	private bool openTheDoor = false;

	public GameObject gameControl;
	PluginScript ps ;


	private int State = 0;






	// Use this for initialization
	void Start () {
		//Link Scripts
		thirdPersonScript = gameObject.GetComponent<ThirdPersonCharacter>();
		//Link Objects
		playerTransform = gameObject.GetComponent<Transform> ();
		gameControl = GameObject.FindGameObjectWithTag("gamecont");
		ps = gameControl.GetComponent<PluginScript> ();

		dialogueSys = new DialogueSystem ();
		scripts=dialogueSys.getLearningScripts();


	}
	
	// Update is called once per frame
	void Update () {
		
		print (">>>>>>>>>>state" + State);
		if (State == 0) {
			movePlayer (door, 25, 0);

		} else if (State == 1) {
			openDoor (door);

		} else if (State == 2) {
			movePlayer (Box, 10, 1);
		} else if (State == 3) {
			speak ();
		} else if (State == 4) {
			speak ();
		}


/*
 state 0 = the player will walk form the coridor to the door and stops there
 state 1 = the door will open
 State 2 = go to the Box 
 State 3 = yanetu will tell talk to the kid
 State 4 = player will have the option of saying the number 
 */
			
		}


	// postion 0 for foreward 1 for backward
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

	void openDoor(GameObject gameObject){
		gameObject.transform.Translate (Vector3.forward * Time.deltaTime * 10f);
		if (gameObject.transform.position.x > 6) {
			State = 2;
		}

	}


	void speak(){
		string text = scripts [1].ToString ();
		print (text);
		ps.Speek (text);
		State = 4;
	}
}
