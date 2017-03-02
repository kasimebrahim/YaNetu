using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour {
	public GameObject monkey;
	private Animator animator;

	public void onClicked(Button b){
		animator = monkey.GetComponent<Animator> ();
		if (b.name.Equals ("Button1")) {
			animator.Play ("long_Jump");

		}
	}
}
