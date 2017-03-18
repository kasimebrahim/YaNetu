using UnityEngine;
using System.Collections;

public class GameCtrl : MonoBehaviour {
	public Transform train;
	public Transform challanges;
	Transform puzzle;
	int puzzleIndex = 0;
	void Start () {
		puzzle = challanges.GetChild (puzzleIndex);
	}
	
	void Update () {
		if (ButtonScript.Answer == puzzle.childCount) {
			for (int i = 0; i < puzzle.childCount; i++) {
				GameObject monkey = puzzle.GetChild (i).gameObject;
				monkey.GetComponent<Animator> ().Play ("long_Jump");
			}
		} 
		if (Vector3.Distance (train.position, puzzle.GetChild(0).position) < 0.3f) {
			puzzleIndex++;
			if (ButtonScript.Answer != puzzle.childCount) {
				TrainController.Speed = 0f;
			}
			else if (puzzleIndex < challanges.childCount) {
				puzzle = challanges.GetChild (puzzleIndex);
			}
		}
}
}
