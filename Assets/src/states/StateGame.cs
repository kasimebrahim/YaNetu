using System;
using UnityEngine;
using Assets.src.states.interfaces;
using UnityEngine.SceneManagement;

namespace Assets.src.states
{
	public class StateGame : IState
	{
		private GameObject gameController;
		private StateManager stateManager;
		private GameObject train;
		public StateGame (StateManager sm)
		{
			this.stateManager = sm;
			if(SceneManager.GetActiveScene().name != "scene2"){
				SceneManager.LoadScene ("scene2", LoadSceneMode.Single);
			}
			gameController = GameObject.FindGameObjectWithTag("gamecont");
			//gameController.AddComponent<GameCtrl> ();

		}

		public void StateUpdate(){
			
			
		}

		public void OnGUI(){
//			if (GUI.Button (new Rect (100, 100, 150, 130), "Button")) {
//				Debug.Log ("This code is executed when the Button is clicked");
//			}
//			
		}
	}
}

