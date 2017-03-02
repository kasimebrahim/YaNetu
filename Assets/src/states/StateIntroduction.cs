using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.src.states.interfaces;

namespace Assets.src.states
{
	public class StateIntroduction : IState
	{
		private StateManager stateManager;

		public StateIntroduction (StateManager sm)
		{
			this.stateManager = sm;
			if(SceneManager.GetActiveScene().name != "scene0"){
				SceneManager.LoadScene ("scene0", LoadSceneMode.Single);

			}

			Debug.Log ("introduction state");
			//SceneManager.LoadScene ("scene2", LoadSceneMode.Single);

		}

		public void StateUpdate(){
			//Debug.Log ("state");
			stateManager.Switch(new StateGame(stateManager));
		}

		public void OnGUI(){
		}
	}
}

