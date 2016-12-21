using UnityEngine;
using System.Collections;


public class playerBehavior : MonoBehaviour {


	public int max= 150;
	public int speed = 7;
	float i = 0;
	public GameObject door;
	private bool walk = true;
	private bool startedTeaching = false;


	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;

		if (Physics.Raycast(transform.position, Vector3.forward, out hit)){
			//print("Found an object - distance: " + hit.distance);
			i = hit.distance;
		}

		// use onother way to move becouse its sooo lame 
		if(i>1 && walk==true){
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
		}else{
			walk = false;
			door.transform.Translate(Vector3.forward * Time.deltaTime * speed);
			//door.SetActive(false);
			if (startedTeaching == false) {
				teach ();
			}
		}






	}

	void teach()
	{
		startedTeaching = true;
		print("hello student");
		print("this is yanetu world i will be your teacher in this class we will learn about numbers");

	}
}
