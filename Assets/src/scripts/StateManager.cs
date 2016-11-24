using UnityEngine;
using System.Collections;
using Assets.src.states.interfaces;
using Assets.src.states;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour {

	private static StateManager instance;
	private IState activeState;
	[HideInInspector]
	public GameData gameData;
	// Use this for initialization
	void Start () {
		activeState = new StateIntroduction (this);
		gameData = GetComponent<GameData> ();
	}

	// onawake
	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			DestroyImmediate (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(activeState!=null){
			activeState.StateUpdate ();
		}
	}

	// ONGUI
	void OnGUI(){
		if(activeState!=null){
			activeState.OnGUI ();
		}
	}

	public void Switch(IState newState){
		activeState = newState;
	}

	public void Restart(){
		Destroy (gameObject);
		SceneManager.LoadScene ("scene0", LoadSceneMode.Single);
	}
}
