using UnityEngine;
using System.Collections;
using Assets.src.code.dialogue;
public class DialogueSys : MonoBehaviour {
	[HideInInspector]
	private DialogueSystem  dialogue = new DialogueSystem(); 
	void Start () {

	}
	void Update () {

	}
	public DialogueSystem getDialogueSystem(){
		return this.dialogue;
	}
}
