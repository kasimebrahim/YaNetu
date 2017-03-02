using UnityEngine;
using System.Collections;

public class audioPlaye : MonoBehaviour {
	public AudioClip soundFile;
	public AudioClip soundFile2;
	AudioSource mySound;

	void Awake(){
		mySound = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MyInput ();
	}

	void MyInput(){
		if (Input.GetKey (KeyCode.Space)) {
			mySound.PlayOneShot (soundFile);
		}

		
	}
}
