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
		dialogueSystem = dialogueSys.dialogue;
		introductionScripts = dialogueSystem.getIntroductionScripts();
	}

    void Update () {
		if (currentSate == States.SPEAK) {
			playYanetu ();
		}
	}
	void playYanetu(){
		plugin.Speek (introductionScripts[0].ToString());
		plugin.record ();
		string name = plugin.GetInText ();
		plugin.ToastMessage (name);
		currentSate = States.STOP;
	}
}
