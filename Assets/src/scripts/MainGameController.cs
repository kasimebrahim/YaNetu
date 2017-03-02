using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainGameController : MonoBehaviour {
	public float speed = 2f;
	public Transform pathParent;
	Transform targetPoint;
	int index;
	public GameObject learnButton;
	public GameObject exitButton;
	public GameObject statusText;
	public GameObject puzzleBldg1;
	public GameObject puzzleBldg2;
	public GameObject puzzleBldg3;
	public GameObject puzzleBldg4;
	AudioSource puzzle3Audio;
	AudioSource puzzle2Audio;
	AudioSource puzzle4Audio;
	int puzzleIndex = 1;
	int answer = 0;
	AudioSource sound;
	int currentCorrectAnswer = 3;
	bool isIncrement = false;
	bool isIncrement2 = false;
	bool isIncrement3 = false;
	void Start () {
		index = 0;
		targetPoint = pathParent.GetChild (index);
		learnButton.gameObject.SetActive(false);
		exitButton.gameObject.SetActive (false);
		statusText.gameObject.SetActive (false);
		sound = GetComponent<AudioSource> ();
		puzzle2Audio = puzzleBldg2.GetComponent<AudioSource> ();
		puzzle2Audio.Stop ();
		puzzle3Audio = puzzleBldg3.GetComponent<AudioSource> ();
		puzzle3Audio.Stop ();
		puzzle4Audio = puzzleBldg4.GetComponent<AudioSource> ();
		puzzle4Audio.Stop ();
	}
	
	void Update () {
		//Debug.Log (puzzleIndex);
		if (puzzleIndex == 1) {
			if (answer == currentCorrectAnswer) {
				GameObject monkey1 = puzzleBldg1.transform.GetChild (0).gameObject;
				GameObject monkey2 = puzzleBldg1.transform.GetChild (1).gameObject;
				GameObject monkey3 = puzzleBldg1.transform.GetChild (2).gameObject;
				monkey1.GetComponent<Animator> ().Play ("long_Jump");
				monkey2.GetComponent<Animator> ().Play ("long_Jump");
				monkey3.GetComponent<Animator> ().Play ("long_Jump");

				//answer = 0;
				//Debug.Log ("Correct");
			} if (Vector3.Distance (transform.position, puzzleBldg1.transform.position) < 1f & (answer != currentCorrectAnswer)) {
				speed = 0f;
				sound.Stop ();
				learnButton.gameObject.SetActive(true);
				exitButton.gameObject.SetActive (true);
				statusText.gameObject.SetActive (true);
				//Debug.Log ("You miss");
			}
			else if(answer ==1 || answer == 2 || answer == 4) {
				//Debug.Log ("Incorrect");
			}
		}
		else if (puzzleIndex == 2) {
			
			if (Vector3.Distance (transform.position, puzzleBldg2.transform.position) <= 10) {
				if (!isIncrement) {
					puzzle2Audio.Play ();
					isIncrement = true;
				}

			}
			if (answer == currentCorrectAnswer) {
				GameObject monkey1 = puzzleBldg2.transform.GetChild (0).gameObject;
				monkey1.GetComponent<Animator> ().Play ("long_Jump");
				//Debug.Log ("Correct");
			} if (Vector3.Distance (transform.position, puzzleBldg2.transform.position) < 1f & (answer == 0 || answer != currentCorrectAnswer)) {
				speed = 0f;
				sound.Stop ();
				learnButton.gameObject.SetActive(true);
				exitButton.gameObject.SetActive (true);
				statusText.gameObject.SetActive (true);
				//Debug.Log ("You miss");
			}
			else if(answer ==3 || answer == 2 || answer == 4) {
				//Debug.Log ("Incorrect");
			}
		}
		else if (puzzleIndex == 3) {
			if (Vector3.Distance (transform.position, puzzleBldg3.transform.position) <= 10) {
				if (!isIncrement2) {
					puzzle3Audio.Play ();
					isIncrement2 = true;
				}

			}
			//Debug.Log ("this is the point");
			if (answer == currentCorrectAnswer) {
				GameObject monkey1 = puzzleBldg3.transform.GetChild (0).gameObject;
				GameObject monkey2 = puzzleBldg3.transform.GetChild (1).gameObject;
				GameObject monkey3 = puzzleBldg3.transform.GetChild (2).gameObject;
				GameObject monkey4 = puzzleBldg3.transform.GetChild (3).gameObject;
				monkey1.GetComponent<Animator> ().Play ("long_Jump");
				monkey2.GetComponent<Animator> ().Play ("long_Jump");
				monkey3.GetComponent<Animator> ().Play ("long_Jump");
				monkey4.GetComponent<Animator> ().Play ("long_Jump");
				//answer = 0;
				//Debug.Log ("Correct");
			} if (Vector3.Distance (transform.position, puzzleBldg3.transform.position) < 1f & (answer != currentCorrectAnswer)) {
				speed = 0f;
				sound.Stop ();
				learnButton.gameObject.SetActive(true);
				exitButton.gameObject.SetActive (true);
				statusText.gameObject.SetActive (true);
				//Debug.Log ("You miss");
			}
			else if(answer ==1 || answer == 2 || answer == 3) {
				//Debug.Log ("Incorrect");
			}
		}
		else if (puzzleIndex == 4) {
			if (Vector3.Distance (transform.position, puzzleBldg4.transform.position) <= 10) {
				if (!isIncrement3) {
					puzzle4Audio.Play ();
					isIncrement3 = true;
				}
			}
			Debug.Log ("this is the point");
			if (answer == currentCorrectAnswer) {
				GameObject monkey1 = puzzleBldg4.transform.GetChild (0).gameObject;
				GameObject monkey2 = puzzleBldg4.transform.GetChild (1).gameObject;
				monkey1.GetComponent<Animator> ().Play ("long_Jump");
				monkey2.GetComponent<Animator> ().Play ("long_Jump");

				//Debug.Log ("Correct");
			} if (Vector3.Distance (transform.position, puzzleBldg4.transform.position) < 1f & (answer != currentCorrectAnswer)) {
				speed = 0f;
				sound.Stop ();
				learnButton.gameObject.SetActive(true);
				exitButton.gameObject.SetActive (true);
				statusText.gameObject.SetActive (true);
				//Debug.Log ("You miss");
			}
			else if(answer ==1 || answer == 2 || answer == 3) {
				//Debug.Log ("Incorrect");
			}
		}
		if (puzzleIndex == 1) {
			if (Vector3.Distance (transform.position, puzzleBldg1.transform.position) > 0 && Vector3.Distance (transform.position, puzzleBldg1.transform.position) < 1) {
				puzzleIndex++;
				currentCorrectAnswer = 1;
				//puzzle2Audio.Play ();
			};
		} 
		else if (puzzleIndex == 2) {
			if (Vector3.Distance (transform.position, puzzleBldg2.transform.position) > 0 && Vector3.Distance (transform.position, puzzleBldg2.transform.position) < 1) {
				puzzleIndex++;
				currentCorrectAnswer = 4;

			};

		} 
		else if (puzzleIndex == 3) {
			
			if (Vector3.Distance (transform.position, puzzleBldg3.transform.position) > 0 && Vector3.Distance (transform.position, puzzleBldg3.transform.position) < 1) {
				puzzleIndex++;
				currentCorrectAnswer = 2;
				//puzzle4Audio.Play ();
			};
		}
		else if (puzzleIndex == 4) {
			
			if (Vector3.Distance (transform.position, puzzleBldg4.transform.position) > 0 && Vector3.Distance (transform.position, puzzleBldg4.transform.position) < 1) {
				puzzleIndex++;
				currentCorrectAnswer = 2;

			};
		} 

	}
	void checkGameOver(){
		
	}

	public void onButtonClicked(Button button){
		if (button.name.Equals ("Button1")) {
			answer = 1;
		} else if (button.name.Equals ("Button2")) {
			answer = 2;
			
		} else if (button.name.Equals ("Button3")) {
			answer = 3;
		}
		else if(button.name.Equals("Button4")){
			answer = 4;
		}
	}
	void FixedUpdate(){
		transform.position = Vector3.MoveTowards (transform.position, targetPoint.position, speed * Time.deltaTime);
		//transform.position = Vector3.Lerp (transform.position, targetPoint.position,speed * Time.deltaTime);
		//		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetPoint.rotation, speed * Time.deltaTime);
		transform.LookAt(targetPoint);
		//transform.rotation = Quaternion.Slerp (transform.rotation, targetPoint.rotation, Time.deltaTime);
		if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f){
			index++;
			if (index < pathParent.childCount) {
				if (index > 2000) {
					speed = 0;
				} else {
					speed = 3f;
					targetPoint = pathParent.GetChild (index);
				}


			}
			if (index == pathParent.childCount) {
				Debug.Log ("shit");
				sound.Stop ();
				puzzle4Audio.Stop ();
			}
			//index %= pathParent.childCount;

		}
	}
}
