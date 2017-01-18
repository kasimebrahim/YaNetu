using UnityEngine;
using System.Collections;
using Assets.src.code.dialogue;
using System;
public class IntroductionScript : MonoBehaviour {
	public GameObject gameControl;
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
	void Start () {
		plugin = gameControl.GetComponent<PluginScript> ();
		dialogueSys = gameControl.GetComponent<DialogueSys> ();
		dialogueSystem = dialogueSys.getDialogueSystem();
		introductionScripts = dialogueSystem.getIntroductionScripts();
	}

    void Update () {
		if (currentSate == States.SPEAK) {
			//playYanetu ();
		}
	}
	void playYanetu(){
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
