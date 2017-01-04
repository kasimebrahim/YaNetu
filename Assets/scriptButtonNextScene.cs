using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptButtonNextScene : MonoBehaviour {
	public Button yourButton;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
		Application.LoadLevel ("scene1");
	}
}
