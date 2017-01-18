using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.src.states.interfaces;
using Assets.src.code.dialogue;
using System.Collections;


namespace Assets.src.states
{
	public class StateIntroduction : IState
	{
		public GameObject gameControl;
		private StateManager stateManager;
		private DialogueSystem dialogueSystem;
		private DialogueSys dialogueSys;
		private PluginScript plugin;
		private ArrayList introductionScripts;
		private string learnerName;
		private int learnerAge;
		private enum States
		{
			SPEAK,
			ASK,
			LISTEN,
			STOP
		}
		private States currentSate = States.SPEAK;

		public StateIntroduction (StateManager sm)
		{
			this.stateManager = sm;
			if(SceneManager.GetActiveScene().name != "scene0"){
				SceneManager.LoadScene ("scene0", LoadSceneMode.Single);
			}
			gameControl = stateManager.gameObject;
			plugin = gameControl.GetComponent<PluginScript> ();
			dialogueSys = gameControl.GetComponent<DialogueSys> ();
			dialogueSystem = dialogueSys.getDialogueSystem();
			introductionScripts = dialogueSystem.getIntroductionScripts();
			Debug.Log ("introduction state");
		}

		public void StateUpdate(){
//			Debug.Log (stateManager.gameData.test);
			if (currentSate == States.SPEAK) {
				plugin.Speek ("Hello, My name is YaaNetuuu");
				//Debug.Log (introductionScripts[2].ToString());
				currentSate = States.STOP;
				//playYanetu ();
			}

			IState learnState = new StateLearn (stateManager);
			stateManager.Switch (learnState);

		}

		public void OnGUI(){
		}
		void PlayYanetu(){
			plugin.Speek (introductionScripts[0].ToString());
			plugin.record ();
			string name = plugin.GetInText ();
			while(name.Equals (" ")) {
				plugin.Speek (introductionScripts [1].ToString());
				plugin.record ();
				name = plugin.GetInText ();
			} 
			plugin.Speek (introductionScripts[2].ToString() + dialogueSystem.getName(name));
			plugin.Speek (introductionScripts[3].ToString());
			string age = plugin.GetInText ();
			while(age.Equals (" ")) {
				plugin.Speek (introductionScripts [4].ToString());
				plugin.record ();
				age = plugin.GetInText ();
			} 
			plugin.Speek (introductionScripts[5].ToString() + dialogueSystem.getName(name));
			//plugin.ToastMessage (name);
			currentSate = States.STOP;
		}

	}
}

