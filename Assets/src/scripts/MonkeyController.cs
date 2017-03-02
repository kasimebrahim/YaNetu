using UnityEngine;
using System.Collections;

public class MonkeyController : MonoBehaviour {

	public Animator animator;
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Game state");
	}
}
