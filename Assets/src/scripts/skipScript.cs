using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.src.states.interfaces;
using Assets.src.states;

public class skipScript : MonoBehaviour {

	public Button yourButton;


	//public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);



	}

	// Update is called once per frame
	void TaskOnClick(){
		GameObject controller = GameObject.FindGameObjectWithTag("gamecont");
		StateManager stateManager = controller.GetComponent<StateManager> ();
		IState testState = new StateGame (stateManager);
		stateManager.Switch (testState);
	}
}
