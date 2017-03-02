using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainGameController : MonoBehaviour {
	public GameObject puzzleBldg1;
	int puzzleIndex = 1;
	int answer = 0;
	void Start () {
	
	}
	
	void Update () {
		if (puzzleIndex == 1) {
			if (Vector3.Distance (transform.position, puzzleBldg1.transform.position) > 0 && Vector3.Distance (transform.position, puzzleBldg1.transform.position) < 1) {
				puzzleIndex++;
				answer = 0;
			};
		} else if (puzzleIndex == 2) {
			
		}
		if (puzzleIndex == 1) {
			if (answer == 3) {
				GameObject monkey1 = puzzleBldg1.transform.GetChild (0).gameObject;
				GameObject monkey2 = puzzleBldg1.transform.GetChild (1).gameObject;
				GameObject monkey3 = puzzleBldg1.transform.GetChild (2).gameObject;
				monkey1.GetComponent<Animator> ().Play ("long_Jump");
				monkey2.GetComponent<Animator> ().Play ("long_Jump");
				monkey3.GetComponent<Animator> ().Play ("long_Jump");
				Debug.Log ("Correct");
			} else if (Vector3.Distance (transform.position, puzzleBldg1.transform.position) <1 && answer == 0) {
				Debug.Log ("You miss");
			}
			else if(answer ==1 || answer == 2 || answer == 4) {
				Debug.Log ("Incorrect");
			}
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
}
