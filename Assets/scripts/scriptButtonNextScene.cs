using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.src.states;
using Assets.src.states.interfaces;
public class scriptButtonNextScene : MonoBehaviour {
	public Button yourButton;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		GameObject controller = GameObject.FindGameObjectWithTag("gamecont");
		StateManager stateManager = controller.GetComponent<StateManager> ();
		IState learnState = new StateLearn (stateManager);
		stateManager.Switch (learnState);
	}
}
