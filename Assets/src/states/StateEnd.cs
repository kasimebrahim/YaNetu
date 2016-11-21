using System;
using UnityEngine;
using Assets.src.states.interfaces;
using UnityEngine.SceneManagement;

namespace Assets.src.states
{
	public class StateEnd : IState
	{
		private StateManager stateManager;

		public StateEnd (StateManager sm)
		{
			this.stateManager = sm;
			if(SceneManager.GetActiveScene().name != "scene3"){
				SceneManager.LoadScene ("scene3", LoadSceneMode.Single);
			}
			Debug.Log ("End state");
		}

		public void StateUpdate(){
			
		}

		public void OnGUI(){
			if(GUI.Button(new Rect(10,10,120,30),"Quit")){
				Application.Quit ();
			}
		}
	}
}

