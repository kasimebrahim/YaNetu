using System;
using UnityEngine;
using Assets.src.states.interfaces;
using UnityEngine.SceneManagement;

namespace Assets.src.states
{
	public class StateGameHowTo : IState
	{
		private StateManager stateManager;

		public StateGameHowTo (StateManager sm)
		{
			this.stateManager = sm;
			if(SceneManager.GetActiveScene().name != "scene2"){
				SceneManager.LoadScene ("scene2", LoadSceneMode.Single);
			}
			Debug.Log ("Game How to state");
		}

		public void StateUpdate(){
			
		}

		public void OnGUI(){
		}
	}
}

