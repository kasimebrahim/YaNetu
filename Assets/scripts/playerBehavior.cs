using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
using Assets.src.dialogue;
using Assets.src.states.interfaces;
using Assets.src.states;
public class playerBehavior : MonoBehaviour {

	private DialogueSystem dialogueSys;
	private ThirdPersonCharacter thirdPersonScript;
	PluginScript ps ;

	public int max= 150;
	public int speed = 7;
	private int State = 0;
	public float sspeed = 0.5f;

	private ArrayList scripts;

	float i = 0;
	public GameObject door;
	public GameObject Box;
	public GameObject Boxtwo;
	public GameObject Box3;

	public GameObject gameControl;
	public GameObject ButtonObj;
	public GameObject ButtonObj2;
	public GameObject ButtonObj3;
	public GameObject Birdobj;
	public GameObject Birdobj2;
	public GameObject Birdobj3;
	public GameObject Yanetu;

	private Transform playerTransform;
	private bool completed;
	private bool openTheDoor = false;
	private bool walk = true;

	private bool talk = false;
	private bool talk2 = false;
	private bool talk3 = false;
	private bool talk4 = false;
	private bool talk5 = false;
	private bool talk6 = false;
	private bool talk7 = false;

	public AudioClip soundFile;
	public AudioClip soundFile2;
	public AudioClip soundFile3;
	public AudioClip soundFile4;
	public AudioClip soundFile5;
	public AudioClip soundFile6;
	AudioSource mySound;

	private float startTime;
	Animator yanetuAnim;




	void Awake(){
		mySound = GetComponent<AudioSource> ();
		yanetuAnim = Yanetu.GetComponent<Animator> ();
	}
		


	

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
		}else if (State == 8) {
			showButton2 ();
		}else if (State == 9) {
			Learn2speak3 ();
		}else if (State == 10) {
			showBox3 ();
		}else if (State == 11) {
			learn3Speak();
		}else if (State == 12) {
			showButton3 ();
		}else if (State == 13) {
			learn3Speak2();
		}else if (State == 14) {
			goAway();
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
		if (talk == false) {
			mySound.PlayOneShot (soundFile, 0.7F);
			talk = true;
			startTime = Time.time;
		}
//		print (soundFile.length); 
		yanetuAnim.Play("EvaAnimation2");
		print(isPlaying (soundFile));
		if (!isPlaying (soundFile)) {
			State = 4;
			yanetuAnim.Play("EvaAnimation");
		}
			
	}

	void showButton(){
			ButtonObj.SetActive (true);
			if (Box == null) {
				State = 5;
				ButtonObj.SetActive (false);
			}
	}

	void Learn1speak2(){
		if (talk2 == false) {
			mySound.PlayOneShot (soundFile2, 0.7F);
			talk2 = true;
			startTime = Time.time;
		}
		yanetuAnim.Play("EvaAnimation2");
		if (!isPlaying (soundFile2)) {
			State = 6;
			yanetuAnim.Play("EvaAnimation");
		}

	}


	// Here begins the code that teach the kid about number 2
	void Learn2speak(){
			Boxtwo.SetActive (true);
			State = 7;

	}

	void Learn2speak2(){
		if (talk3 == false) {
			mySound.PlayOneShot (soundFile3, 0.7F);
			talk3 = true;
			startTime = Time.time;
		}
		yanetuAnim.Play("EvaAnimation2");
		if (!isPlaying (soundFile3)) {
			State =8;
			yanetuAnim.Play("EvaAnimation");
		}
		}

	void showButton2(){
			ButtonObj2.SetActive (true);
			if (Boxtwo == null) {
				State = 9;
				ButtonObj2.SetActive (false);
			}

	}

	void Learn2speak3(){
		if (talk4 == false) {
			mySound.PlayOneShot (soundFile4, 0.7F);
			talk4 = true;
			startTime = Time.time;
		}
		yanetuAnim.Play("EvaAnimation2");
		if (!isPlaying (soundFile4)) {
			State =10;
			yanetuAnim.Play("EvaAnimation");
		}
	}

	void showBox3(){
		
			Box3.SetActive(true);
			State = 11;

	}

	void learn3Speak(){
		if (talk5 == false) {
			mySound.PlayOneShot (soundFile5, 0.7F);
			talk5 = true;
			startTime = Time.time;
		}
		yanetuAnim.Play("EvaAnimation2");
		if (!isPlaying (soundFile5)) {
			State =12;
			yanetuAnim.Play("EvaAnimation");
		}
	}

	void showButton3(){
		
			ButtonObj3.SetActive (true);
			if (Box3 == null) {
				State = 13;
				ButtonObj3.SetActive (false);
			}
	
	}

	void learn3Speak2(){
		if (talk6 == false) {
			mySound.PlayOneShot (soundFile6, 0.7F);
			talk6 = true;
			startTime = Time.time;
		}
		yanetuAnim.Play("EvaAnimation2");
		if (!isPlaying (soundFile6)) {
			State =14;
			yanetuAnim.Play("EvaAnimation");
		}
	}

	void goAway(){
		GameObject controller = GameObject.FindGameObjectWithTag("gamecont");
		StateManager stateManager = controller.GetComponent<StateManager> ();
		IState testState = new StateGame (stateManager);
		stateManager.Switch (testState);
	}

	public bool isPlaying(AudioClip clip){
		if((Time.time - startTime) >= clip.length){
			return false;
		}
		return true;
		
	}
}
