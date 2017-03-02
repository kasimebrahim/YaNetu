using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BreakButton3 : MonoBehaviour {

	public Button yourButton;
	public GameObject Box;
	public GameObject bird;
	public GameObject bird2;
	public GameObject bird3;
	//public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);



	}

	// Update is called once per frame
	void TaskOnClick(){
		Destroy(Box);
		bird.SetActive(true);
		bird2.SetActive(true);
		bird3.SetActive(true);
		//Instantiate (explosionPrefab);
}
}