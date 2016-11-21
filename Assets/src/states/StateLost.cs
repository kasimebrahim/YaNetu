using System;
using UnityEngine;
using Assets.src.states.interfaces;
using UnityEngine.SceneManagement;

namespace Assets.src.states
{
	public class StateLost : IState
	{
		private StateManager stateManager;

		public StateLost (StateManager sm)
		{
			this.stateManager = sm;
			if(SceneManager.GetActiveScene().name != "scene0"){
				SceneManager.LoadScene ("scene0", LoadSceneMode.Single);
			}
			Debug.Log ("Lost state");
		}

		public void StateUpdate(){
			
		}

		public void OnGUI(){
			if(GUI.Button(new Rect(10,10,120,30),"Skip")){
				stateManager.Switch (new StateLearn(stateManager));
			}
		}
	}
}

