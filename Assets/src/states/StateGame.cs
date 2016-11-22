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
			Debug.Log ("Game state");
		}

		public void StateUpdate(){
			
		}

		public void OnGUI(){
			if(GUI.Button(new Rect(10,10,120,30),"Skip")){
				stateManager.Switch (new StateEnd(stateManager));
			}
			if(GUI.Button(new Rect(10,45,120,30),"Lose")){
				stateManager.Switch (new StateLost(stateManager));
			}
			Debug.Log (stateManager.gameData.test);
		}
	}
}

