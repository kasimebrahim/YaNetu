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
		}

		public void StateUpdate(){
			
		}

		public void OnGUI(){
			if(GUI.Button(new Rect(10,10,120,30),"Skip")){
				stateManager.Switch (new StateIntroduction(stateManager));
			}
		}
	}
}

