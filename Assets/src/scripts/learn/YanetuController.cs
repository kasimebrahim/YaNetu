using UnityEngine;
using System.Collections;

public class YanetuController : MonoBehaviour {
	private static Animator yanetuAnimator;
	private static AudioSource audioSource;
	static ArrayList AudioClips = new ArrayList();
	static bool isPlayStarted = false;
	public static bool IS_finished = false;
	void Start () {
		yanetuAnimator = GetComponent<Animator> ();
		audioSource = gameObject.AddComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audioSource.isPlaying) {
			if (AudioClips.Count > 0) {
				AudioClip clip = (AudioClip)AudioClips [0];
				play (clip);
				AudioClips.RemoveAt (0);
			}
		}
		IS_finished = !audioSource.isPlaying;
	}
	public static void Animate(string animationName){
		yanetuAnimator.Play (animationName);
	}
	public static void Speak(string audioName){
		AudioClip clip = Resources.Load(audioName, typeof(AudioClip)) as AudioClip;
		AudioClips.Add (clip);
	}
	private void play(AudioClip clip)
	{
		isPlayStarted = true;
		audioSource.PlayOneShot (clip);

	}
	public static bool isFinished(){
		if (AudioClips.Count == 0) {
			if(isPlayStarted)
			return audioSource.isPlaying;
		}
		return false;
	}
}
