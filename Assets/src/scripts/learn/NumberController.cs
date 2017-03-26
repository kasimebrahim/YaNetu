using UnityEngine;
using System.Collections;

public class NumberController : MonoBehaviour {
	public GameObject Numbers;
	public enum States {Stop,Down,Hide};
	public static States NumberState = States.Stop;
	public float speed = 5f;
	Vector3 MovingDirrection = Vector3.down;
	static int numberIndex = 0;
	GameObject numberGameObject;
	public GameObject ballPrefab;
	static ArrayList balls = new ArrayList();
	public float motionMagnitude = 0.003f;
	static bool isDetailed = false;
	float gap = 0f;
	GameObject ball;
	enum BallSteates{UP, Down, IDLE};
	static BallSteates ballState = BallSteates.IDLE;
	static int ballNumber = 0;
	public float MaxHightOfBall = 10f;
	public float MinHightOfBall = 8f;
	public bool isUp = true;
	public bool isDown = false;
	public bool isNext = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		numberGameObject = Numbers.transform.GetChild (numberIndex).gameObject;
		if (NumberState == States.Down) {
			if (numberGameObject.transform.position.y > 4) {
				numberGameObject.transform.Translate (MovingDirrection * Time.deltaTime * speed);
			} 
		}
		else if (NumberState == States.Hide) {
			StartCoroutine (WaitForIt(5));
			ballState = BallSteates.IDLE;
			numberGameObject.SetActive (false);
			for (int i = 0; i < balls.Count; i++) {
				GameObject b = balls [i] as GameObject;
				Destroy (b);
			}
			ballNumber = 0;
			gap = 0f;
			NumberState = States.Stop;
		}
		if (isDetailed) {
			
			for (int i = 0; i < numberIndex; i++) {
				ball = Instantiate (ballPrefab);
				balls.Add (ball);
				ball.transform.Translate (Vector3.right * gap);;
				gap += 1;
			}
			StartCoroutine (WaitForIt(5));
			ballState = BallSteates.UP;
			isDetailed = false;

		}
		if (ballState == BallSteates.UP) {
			Debug.Log ("ball");
			Debug.Log (ballNumber);
			if ((balls [ballNumber] as GameObject).transform.position.y >= MaxHightOfBall) {
				isUp = false;
				isDown = true;
			}
			else if ((balls [ballNumber] as GameObject).transform.position.y <= MinHightOfBall) {
				if (isDown == true) {
					isNext = true;
					isDown = false;
					isUp = false;
				}

			}
			if (isUp) {

				(balls [ballNumber] as GameObject).transform.Translate (Vector3.up * Time.deltaTime * speed);
			}
			else if (isDown) {
				(balls [ballNumber] as GameObject).transform.Translate (Vector3.down * Time.deltaTime * speed);

			}
			else if (isNext) {
				if (ballNumber < balls.Count-1) {
					ballNumber++;
					isNext = false;
					isUp = true;
				} else {
					ballNumber = 0;
					isDown = false;
					isUp = true;
					ballState = BallSteates.IDLE;


				}
			}

		}

	}
	public static void setNumberIndex(int index){
		numberIndex = index;
		NumberState = States.Down;
	}
	public static void remove(){
		NumberState = States.Hide;

	}
	public static void addBalls(){
		balls = new ArrayList ();
		isDetailed = true;
			

	}
	IEnumerator WaitForIt(int sec){
		yield return new WaitForSeconds (sec);
	}
	void FixedUpdate(){
		
	}
}
