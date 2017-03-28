using UnityEngine;
using System.Collections;

public class NumberController : MonoBehaviour {
	public GameObject Numbers;
	public GameObject operations;
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
	static bool isTwoDigit = false;
	static int firstDigitIndex = 0;
	static int secondDigitIndex = 0;
	static bool isTwoDigitCalled = false;
	GameObject numberGameObject1;
	GameObject numberGameObject2;
	enum EducationType{ COUNTING, ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION};
	static EducationType eduType = EducationType.COUNTING;
	static Vector3 firstNumPos = new Vector3(-0.8f,3.555f,10.05f);
	static Vector3 secondNumPos = new Vector3 (1.69f, 3.555f, 10.05f);
	static Vector3 ansPos = new Vector3 (5.83f, 3.555f, 10.05f);
	static GameObject firstNum;
	static GameObject secondNum;
	static GameObject answerNum;
	static GameObject operationBlock;
	static bool isArtimetic = true;
	static int num1 = 0;
	static int num2 = 0;
	static int answer;
	static bool isAnswerSet = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (eduType == EducationType.COUNTING) {
			if (isTwoDigit) {
				twoDigit ();
			}
			else 
				oneDigit ();
			detailTeach ();	
		}
		else {
			if (isArtimetic) {
				setPositionOfNumbers ();
				isArtimetic = false;
			}
		}
		if (isAnswerSet) {
			answerNum = Numbers.transform.GetChild (answer).gameObject;
			answerNum.transform.position = ansPos;
			isAnswerSet = false;
		}

	}
	public void detailTeach(){
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
		if (numberIndex > 9 && numberIndex < 100) {
			isTwoDigit = true;
			firstDigitIndex = index / 10;
			secondDigitIndex = index % 10;
			isTwoDigitCalled = false;
		} else if (index < 10) {
			isTwoDigit = false;
		}
	}
	public static void remove(){
		if (eduType == EducationType.COUNTING) {
			NumberState = States.Hide;	
		} else {
			clearArtimeticNumbers ();
		}


	}
	public static void clearArtimeticNumbers(){
		firstNum.SetActive (false);
		secondNum.SetActive (false);
		answerNum.SetActive (false);
		operationBlock.SetActive (false);
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
	public void oneDigit(){
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
	}
	public void twoDigit(){
		
		if (!isTwoDigitCalled) {
			
			numberGameObject1 = Numbers.transform.GetChild (firstDigitIndex).gameObject;
			numberGameObject1.transform.Translate (Vector3.right);
			numberGameObject2 = Numbers.transform.GetChild (secondDigitIndex).gameObject;

			isTwoDigitCalled =  true;
		}

		if (NumberState == States.Down) {
			if (numberGameObject1.transform.position.y > 4) {
				numberGameObject1.transform.Translate (MovingDirrection * Time.deltaTime * speed);
				numberGameObject2.transform.Translate (MovingDirrection * Time.deltaTime * speed);
			} 
		}
		else if (NumberState == States.Hide) {
			StartCoroutine (WaitForIt(5));
			ballState = BallSteates.IDLE;
			numberGameObject1.SetActive (false);
			numberGameObject2.SetActive (false);
			for (int i = 0; i < balls.Count; i++) {
				GameObject b = balls [i] as GameObject;
				Destroy (b);
			}
			ballNumber = 0;
			gap = 0f;
			NumberState = States.Stop;
		}

	}
	public static void teachArtimetic(int n1, int n2, string operation){
		num1 = n1;
		num2 = n2;
		if (operation.Equals ("+")) {
			eduType = EducationType.ADDITION;	
		} else if (operation.Equals ("-")) {
			eduType = EducationType.SUBTRACTION;
		} else if (operation.Equals ("*")) {
			eduType = EducationType.MULTIPLICATION;
		} else if (operation.Equals ("/")) {
			eduType = EducationType.DIVISION;
		}
		isArtimetic = true;

	}
	public void setPositionOfNumbers(){
		firstNum = Numbers.transform.GetChild (num1).gameObject;
		firstNum.SetActive (true);
		firstNum.transform.position = firstNumPos;
		secondNum = Numbers.transform.GetChild (num2).gameObject;
		secondNum.transform.position = secondNumPos;
		secondNum.SetActive (true);
		if (eduType == EducationType.ADDITION) {
			operationBlock = operations.transform.GetChild (0).gameObject;
			answer = num1 + num2;
		}
		else if (eduType == EducationType.SUBTRACTION) {
			operationBlock = operations.transform.GetChild (1).gameObject;
			answer = num1 - num2;
		}
		else if (eduType == EducationType.MULTIPLICATION) {
			operationBlock = operations.transform.GetChild (2).gameObject;
			answer = num1 * num2;
		}
		if (eduType == EducationType.DIVISION) {
			operationBlock = operations.transform.GetChild (3).gameObject;
			answer = num1 / num2;
		}
		operationBlock.SetActive (true);

	}
	public static void setAnswer(){
		isAnswerSet = true;

	}
}
