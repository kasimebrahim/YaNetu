using UnityEngine;
using System.Collections;
using Assets.src.dialogue;
public class IntroductionScript : MonoBehaviour {
    private DialogueSystem dialogue;
    private ArrayList introductionScripts;
	void Start () {
        dialogue = new DialogueSystem();
        introductionScripts = dialogue.getIntroductionScripts();
        for (int i = 0; i < introductionScripts.Count; i++)
        {
            Debuge.Log(introductionScripts[i]);
        }
	}

    void Update () {
	
	}
}
