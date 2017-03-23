using System;
using UnityEngine;
using Assets.src.states.interfaces;
using UnityEngine.SceneManagement;

namespace Assets.src.states
{
	public class StateGame : IState
	{
		private StateManager stateManager;
		public StateGame (StateManager sm)
		{
			this.stateManager = sm;
			if(SceneManager.GetActiveScene().name != "scene2"){
				SceneManager.LoadScene ("scene2", LoadSceneMode.Single);
			}

		}

		public void StateUpdate(){
			
			
		}

		public void OnGUI(){
//			if (GUI.Button (new Rect (300, 300, 350, 330), "Button")) {
//				Debug.Log ("This code is executed when the Button is clicked");
//			}
			
		}
	}
}

