using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour {
	public static int Answer = 0;
	public void onButtonClicked(Button button){
		if (button.name.Equals ("Button1")) {
			Answer = 1;
		} else if (button.name.Equals ("Button2")) {
			Answer = 2;

		} else if (button.name.Equals ("Button3")) {
			Answer = 3;
		}
		else if(button.name.Equals("Button4")){
			Answer = 4;
		}
	}
	void Update(){
		//if(isJump)
		//animator.transform.position =  Vector3.MoveTowards (monkey.transform.position, tree.transform.position,2 * Time.deltaTime);
	}
}
