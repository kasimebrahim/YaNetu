using UnityEngine;
using System.Collections;

public class TeachingManager : MonoBehaviour {
	static bool isWait = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isWait) {
			StartCoroutine (WaitForIt(20));
			isWait = false;
		}
	}
	public static void teachCounting(int number){
		NumberController.setNumberIndex (number);

	}
	public static void readyForNext(){
		isWait = true;

		NumberController.remove ();
	}
	public static void detailTeaching(){
		NumberController.addBalls ();
	}
	IEnumerator WaitForIt(int sec){
		yield return new WaitForSeconds (sec);
	}
}
