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
		}

		public void StateUpdate(){
			
		}

		public void OnGUI(){
			if (GUI.Button (new Rect (300, 300, 100, 100), "Button")) {
				YanetuController.Animate ("EvaAnimation2");
				YanetuController.Speak ("Sound/1");
				YanetuController.Speak ("Sound/2");
				YanetuController.Speak ("Sound/3");
				YanetuController.Speak ("Sound/4");
		}
		}
	}
}

