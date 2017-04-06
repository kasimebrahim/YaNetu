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
	public static float Speed = 2.5f;
	Transform targetPoint;
	void Start () {
		index = 0;
		targetPoint = pathParent.GetChild (index);
	}
	void Update () {
	
	}
	void FixedUpdate(){
		transform.position = Vector3.MoveTowards (transform.position, targetPoint.position, Speed * Time.deltaTime);
		var rotation = Quaternion.LookRotation (targetPoint.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Speed * Time.deltaTime);
		//transform.LookAt(targetPoint);
		if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f){
			index++;
			if (index < pathParent.childCount) {
					Speed = 2.5f;
					targetPoint = pathParent.GetChild (index);

			}
			if (index == pathParent.childCount) {
				Speed = 0f;
			}
		}
	}
}
