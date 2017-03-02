using UnityEngine;
using System.Collections;

public class MonkeyScript : MonoBehaviour {

	public float speed = 1f;

	void Start () {
		gameObject.GetComponent<Animator> ().speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
