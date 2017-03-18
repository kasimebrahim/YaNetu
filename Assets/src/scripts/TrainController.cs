using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.src.states.interfaces;
using Assets.src.states;
public class TrainController : MonoBehaviour {
	int index;
	public Transform pathParent;
	public static float Speed = 3f;
	Transform targetPoint;
	void Start () {
		index = 0;
		targetPoint = pathParent.GetChild (index);
	}
	void Update () {
	
	}
	void FixedUpdate(){
		transform.position = Vector3.MoveTowards (transform.position, targetPoint.position, Speed * Time.deltaTime);
		Quaternion rot = targetPoint.rotation;
		transform.LookAt(targetPoint);
		if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f){
			index++;
			if (index < pathParent.childCount) {
				if (index > 2000) {
					Speed = 0;
				} else {
					Speed = 3f;
					targetPoint = pathParent.GetChild (index);
				}					
			}
		}
	}
}
