﻿using UnityEngine;
using System.Collections;

public class PluginScript : MonoBehaviour {
	private string inText;
	private string lastText;
	private bool toast;

	public void setInText(string txt){
		inText = txt;
	}

	public string GetInText(){
		string txt = inText;
		inText = null;
		return txt;
	}
	void Start(){
	}

	/*record*/
	public void record(){
		using(AndroidJavaClass activityClass = new AndroidJavaClass("com.example.mylibrary.MainActivity")){
			using(AndroidJavaObject activity = activityClass.GetStatic<AndroidJavaObject>("myContext")){
				activity.Call ("getSpeech");
			}
		}
	}

	/*Toast a message*/
	public void ToastMessage(string text){
		using(AndroidJavaClass activityClass = new AndroidJavaClass("com.example.mylibrary.MainActivity")){
			using(AndroidJavaObject activity = activityClass.GetStatic<AndroidJavaObject>("myContext")){
				activity.Call ("toast", text);
			}
		}
	}

	/*speek*/
	public void Speek(string text){
		using(AndroidJavaClass activityClass = new AndroidJavaClass("com.example.mylibrary.MainActivity")){
			using(AndroidJavaObject activityObject = activityClass.GetStatic<AndroidJavaObject>("myContext")){
				activityObject.Call ("speak", text);
			}
		}
	}
}
