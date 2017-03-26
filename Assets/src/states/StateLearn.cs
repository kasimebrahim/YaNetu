using System;
using UnityEngine;
using Assets.src.states.interfaces;
using UnityEngine.SceneManagement;
namespace Assets.src.states
{
	public class StateLearn : IState
	{
		private StateManager stateManager;
		enum States {LEARN, STOP, START, DETAIL};
		States currentState = States.START;
		int number = 1;

		public StateLearn (StateManager sm)
		{
			this.stateManager = sm;
			if(SceneManager.GetActiveScene().name != "scene1"){
				SceneManager.LoadScene ("scene1", LoadSceneMode.Single);
			}
		}


		public void StateUpdate(){
			if (currentState == States.LEARN) {
				YanetuController.Animate ("EvaAnimation2");
				TeachingManager.teachCounting (number);
				YanetuController.Speak ("Sound/1");
				currentState = States.DETAIL;
			} else if (currentState == States.DETAIL) {
				if (YanetuController.IS_finished) {
					TeachingManager.detailTeaching ();
					YanetuController.Speak ("Sound/3");
					currentState = States.STOP;
				}
			
			} else if (currentState == States.STOP) {
				if (YanetuController.IS_finished) {
					if (number < 4) {
						number++;
					}
					TeachingManager.readyForNext ();
					currentState = States.LEARN;
				}
			}


		}

		public void OnGUI(){
			if (GUI.Button (new Rect (300, 300, 100, 100), "Button")) {
				currentState = States.LEARN;	
			}
		}
	}
}

