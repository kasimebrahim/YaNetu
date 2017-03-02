using System;
using UnityEngine;
using Assets.src.states.interfaces;
using UnityEngine.SceneManagement;

namespace Assets.src.states
{
	public class StateLearn : IState
	{
		private StateManager stateManager;

		public StateLearn (StateManager sm)
		{
			this.stateManager = sm;
			if(SceneManager.GetActiveScene().name != "scene1"){
				SceneManager.LoadScene ("scene1", LoadSceneMode.Single);
			}

			Debug.Log ("Learn state");
			SceneManager.LoadScene ("scene2", LoadSceneMode.Single);
		}

		public void StateUpdate(){
			
		}

		public void OnGUI(){
		}
	}
}

