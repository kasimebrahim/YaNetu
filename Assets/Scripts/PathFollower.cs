using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {

	public float speed = 1f;
	public Transform pathParent;
	Transform targetPoint;
	int index;
	void Start () {
		index = 0;
		targetPoint = pathParent.GetChild (index);
	
	}
	

	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, targetPoint.position, speed * Time.deltaTime);
//		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetPoint.rotation, speed * Time.deltaTime);
		transform.LookAt(targetPoint);
		if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f){
			index++;
			if (index < pathParent.childCount) {
				targetPoint = pathParent.GetChild (index);	
			}
			//index %= pathParent.childCount;

		}
	}
}
