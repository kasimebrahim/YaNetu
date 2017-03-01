﻿using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {

	public float speed = 2f;
	public Transform pathParent;
	Transform targetPoint;
	int index;
	void Start () {
		index = 0;
		targetPoint = pathParent.GetChild (index);
	
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
			//index %= pathParent.childCount;

		}
	}

	void Update () {
		
	}

}
