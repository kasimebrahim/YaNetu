using UnityEngine;
using System.Collections;

public class playerBehavior : MonoBehaviour {




	public int max= 150;
	public int speed = 7;
	int i = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(i<max)
		{
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
			i++;
		}
	}



	
}
