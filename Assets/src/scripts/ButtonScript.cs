using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour {
	public GameObject monkey;
	private Animator animator;
	public GameObject tree;
	private bool isJump = false;
	public void onClicked(Button b){
		animator = monkey.GetComponent<Animator> ();
		if (b.name.Equals ("Button1")) {
			animator.Play ("long_Jump");
			isJump = true;
		}

	}
	void Update(){
		//if(isJump)
		//animator.transform.position =  Vector3.MoveTowards (monkey.transform.position, tree.transform.position,2 * Time.deltaTime);
	}
}
